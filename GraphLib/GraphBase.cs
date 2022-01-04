using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLib
{

	public sealed class Graph
	{
		private int _edgeid = 0;
		
		private int _verticalid = 0;
		
		public List<Edge> Edges;
		
		public List<Vertex> Vertices;
		
		/// <summary>
		/// заполняет матрицу смежности
		/// </summary>
		/// <param name="numberV"></param>
		/// <param name="e"></param>
		/// <param name="matrix"></param>
		public static void FillAdjacencyMatrix(int numberV, List<Edge> e, int[,] matrix)
		{
			for (var i = 0; i < numberV; i++)
				for (var j = 0; j < numberV; j++)
					matrix[i, j] = 0;

			for (var i = 0; i < e.Count; i++)
			{
				matrix[e[i].StartVertex.Id, e[i].EndVertex.Id] = 1;
				matrix[e[i].EndVertex.Id, e[i].StartVertex.Id] = 1;
			}
		}
		
		/// <summary>
		/// заполняет матрицу инцидентности
		/// </summary>
		/// <param name="numberV"></param>
		/// <param name="e"></param>
		/// <param name="matrix"></param>
		public static void FillIncidenceMatrix(int numberV, List<Edge> e, int[,] matrix)
		{
			for (var i = 0; i < numberV; i++)
				for (var j = 0; j < e.Count; j++)
					matrix[i, j] = 0;

			for (var i = 0; i < e.Count; i++)
			{
				matrix[e[i].StartVertex.Id, i] = 1;
				matrix[e[i].EndVertex.Id, i] = 1;
			}
		}

		public void CreateVertex(int x,int y) => Vertices.Add(new Vertex(_verticalid++,new Point(x, y)));
		public void CreateEdge(Vertex x,Vertex y) => Edges.Add(new Edge(_edgeid++, x, y));
	}

}
