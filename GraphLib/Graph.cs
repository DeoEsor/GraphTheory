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
		
		public List<Edge> Edges { get; internal set; }
		
		public List<Vertex> Vertices { get; internal set; }
		
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

		public Vertex CreateVertex(int x, int y)
		{
			Vertex result;
			Vertices.Add(result = new Vertex(_verticalid++,new Point(x, y)));
			return result;
		}
		public Edge CreateEdge(Vertex x, Vertex y)
		{
			Edge res;
			Edges.Add(res = new Edge(_edgeid++, x, y));
			return res;
		}

		public void ClearGraph()
		{
			Edges.Clear(); 
			Vertices.Clear();
			_edgeid = 0;
			_verticalid = 0;
		}
	}

}
