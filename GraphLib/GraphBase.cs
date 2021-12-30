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
	/// </summary>
	public class Vertex
	{
		public int x, y;
		private List<Edge> _edges;

		public Vertex(int x, int y)
		{
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

	public class Edge
	{
		public int v1, v2;

		public Edge(int v1, int v2)
		{
			this.v1 = v1;
			this.v2 = v2;
		}
	}

	public static class DrawGraph
	{
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

		public static void СlearSheet()
		{
			gr.Clear(Color.White);
		}

		public static void drawVertex(int x, int y, string number)
		{
			gr.FillEllipse(Brushes.White, x - R, y - R, 2 * R, 2 * R);
			gr.DrawEllipse(blackPen, x - R, y - R, 2 * R, 2 * R);
			point = new PointF(x - 9, y - 9);
			gr.DrawString(number, fo, br, point);
		}

		public static void drawSelectedVertex(int x, int y)
		{
			gr.DrawEllipse(redPen, x - R, y - R, 2 * R, 2 * R);
		}

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
		}

		public static void drawALLGraph(List<Vertex> V, List<Edge> E)
		{
			//рисуем ребра
			for (var i = 0; i < E.Count; i++)
				if (E[i].v1 == E[i].v2)
				{
					gr.DrawArc(darkGoldPen, V[E[i].v1].x - 2 * R, V[E[i].v1].y - 2 * R, 2 * R, 2 * R, 90, 270);
					point = new PointF(V[E[i].v1].x - (int)(2.75 * R), V[E[i].v1].y - (int)(2.75 * R));
					gr.DrawString(((char)('a' + i)).ToString(), fo, br, point);
				}
				else
				{
					gr.DrawLine(darkGoldPen, V[E[i].v1].x, V[E[i].v1].y, V[E[i].v2].x, V[E[i].v2].y);
					point = new PointF((V[E[i].v1].x + V[E[i].v2].x) / 2, (V[E[i].v1].y + V[E[i].v2].y) / 2);
					gr.DrawString(((char)('a' + i)).ToString(), fo, br, point);
				}

			//рисуем вершины
			for (var i = 0; i < V.Count; i++)
				drawVertex(V[i].x, V[i].y, (i + 1).ToString());
		}

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
				matrix[E[i].v1, E[i].v2] = 1;
				matrix[E[i].v2, E[i].v1] = 1;
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
				matrix[E[i].v1, i] = 1;
				matrix[E[i].v2, i] = 1;
			}
		}


	}
}
