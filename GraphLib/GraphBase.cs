using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLib
{
	/// <summary>
	/// Vertex representation
	/// Вершина
	/// </summary>
	public class Vertex
	{
		public int id;
		public int x, y;
		public List<Edge> _edges;
		Random random = new Random();
		
		public int Weight { get; set; } = 1;

		public Vertex(int id, int x , int y)
		{
			this.id = id;
			this.x = x;
			this.y = y;
		}

		public List<Edge> Edges
		{
			get => _edges;
		}

		public void AddEdge(Edge e)
		{
			_edges.Add(e);
		}
	}

	/// <summary>
	/// Ребер
	/// </summary>
	public class Edge
	{
		public int id;
		public  bool isDirected { get; set; }
		/// <summary>
		/// V1 - out vertex (from)
		/// V2 - in Vertex (to)
		/// </summary>
		public Vertex v1, v2;

		public int Weight { get; set; } = 1;

		public Edge(int id, Vertex v1, Vertex v2)
		{
			this.id = id;
			this.v1 = v1;
			this.v2 = v2;
		}
	}

	public sealed class Graph
	{
		public List<Edge> _edges;
		private int edgeid = 0;

		private int verticalid = 0;
		public List<Vertex> _vertices;
		
		/// <summary>
		/// заполняет матрицу смежности
		/// </summary>
		/// <param name="numberV"></param>
		/// <param name="E"></param>
		/// <param name="matrix"></param>
		public static void fillAdjacencyMatrix(int numberV, List<Edge> E, int[,] matrix)
		{
			for (var i = 0; i < numberV; i++)
				for (var j = 0; j < numberV; j++)
					matrix[i, j] = 0;

			for (var i = 0; i < E.Count; i++)
			{
				matrix[E[i].v1.id, E[i].v2.id] = 1;
				matrix[E[i].v2.id, E[i].v1.id] = 1;
			}
		}
		
		/// <summary>
		/// заполняет матрицу инцидентности
		/// </summary>
		/// <param name="numberV"></param>
		/// <param name="E"></param>
		/// <param name="matrix"></param>
		public static void fillIncidenceMatrix(int numberV, List<Edge> E, int[,] matrix)
		{
			for (var i = 0; i < numberV; i++)
				for (var j = 0; j < E.Count; j++)
					matrix[i, j] = 0;

			for (var i = 0; i < E.Count; i++)
			{
				matrix[E[i].v1.id, i] = 1;
				matrix[E[i].v2.id, i] = 1;
			}
		}

		public void CreateVertex(int x,int y) => _vertices.Add(new Vertex(verticalid++, x, y));
		public void CreateEdge(Vertex x,Vertex y) => _edges.Add(new Edge(edgeid++, x, y));
	}

	public static class DrawGraph
	{
		private static Graph _graph;
		private static Bitmap bitmap;
		private static Pen blackPen = new Pen(Color.Black);
		private static Pen redPen = new Pen(Color.Red);
		private static Pen darkGoldPen = new Pen(Color.DarkGoldenrod);
		private static Graphics gr;
		private static Font fo = new Font("Arial", 15);
		private static Brush br = Brushes.Black;
		private static PointF point;
		public static int R = 20; //радиус окружности вершины

		static DrawGraph()
		{
			bitmap = new Bitmap(100, 100);
			gr = Graphics.FromImage(bitmap);
			СlearSheet();
			blackPen.Width = 2;
			redPen.Width = 2;
			darkGoldPen.Width = 2;
		}

		public static Bitmap Bitmap
		{
			get => bitmap;
			set
			{
				bitmap = value;	
				gr = Graphics.FromImage(bitmap);
			}
		}

		public static void СlearSheet() =>  gr.Clear(Color.White);

		public static void drawVertex(int x, int y, string number)
		{
			gr.FillEllipse(Brushes.White, x - R, y - R, 2 * R, 2 * R);
			gr.DrawEllipse(blackPen, x - R, y - R, 2 * R, 2 * R);
			point = new PointF(x - 9, y - 9);
			gr.DrawString(number, fo, br, point);
		}

		public static void drawSelectedVertex(int x, int y) =>  gr.DrawEllipse(redPen, x - R, y - R, 2 * R, 2 * R);

		/*
		public static void drawEdge(Vertex V1, Vertex V2, Edge E, int numberE)
		{
			if (E.v1 == E.v2)
			{
				gr.DrawArc(darkGoldPen, V1.x - 2 * R, V1.y - 2 * R, 2 * R, 2 * R, 90, 270);
				point = new PointF(V1.x - (int)(2.75 * R), V1.y - (int)(2.75 * R));
				gr.DrawString(((char)('a' + numberE)).ToString(), fo, br, point);

				drawVertex(V1.x, V1.y, (E.v1 + 1).ToString());
			}
			else
			{
				gr.DrawLine(darkGoldPen, V1.x, V1.y, V2.x, V2.y);
				point = new PointF((V1.x + V2.x) / 2, (V1.y + V2.y) / 2);
				gr.DrawString(((char)('a' + numberE)).ToString(), fo, br, point);
				drawVertex(V1.x, V1.y, (E.v1 + 1).ToString());
				drawVertex(V2.x, V2.y, (E.v2 + 1).ToString());
			}
		}*/

	}
}
