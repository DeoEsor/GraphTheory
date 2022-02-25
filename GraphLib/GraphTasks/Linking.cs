using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
namespace GraphLib.GraphTasks
{
	public partial class GraphTasks
	{
		public static bool Linking(this Graph graph) => graph.IsWeakLinking();

		public static bool IsWeakLinking(this Graph graph)
		{
			
			var UnOrientedMatrix = graph.FillAdjacencyMatrix();
			
			foreach (var i in graph.Vertices)
				foreach (var j in graph.Vertices)
					UnOrientedMatrix[i][j] = Math.Min(UnOrientedMatrix[i][j], UnOrientedMatrix[j][i]);
			
			_FloydAlgo(graph, ref UnOrientedMatrix);
			return CheckLinking(UnOrientedMatrix);
		}

		public static bool IsStrongLinking(this Graph graph)
		{
			Dictionary<Vertex, Dictionary<Vertex, double>> matrix = graph.FillAdjacencyMatrix();
			_FloydAlgo(graph, ref matrix);
			return CheckLinking(matrix);
		}

		public static bool CheckLinking(Dictionary<Vertex, Dictionary<Vertex, double>> matrix)
		{
			foreach (var my in matrix)
				foreach (var path in my.Value)
					if (path.Value == double.PositiveInfinity)
						return false;
			
			return true;
		}
		
		public static void _FloydAlgo(Graph _graph, ref Dictionary<Vertex, Dictionary<Vertex, double>> matrix )
		{
			for (int k = 0; k < matrix.Count; k++)
				foreach (var i in _graph.Vertices)
					foreach (var j in _graph.Vertices)
						matrix[i][j] =
							Math.Min(
								matrix[i][j],
								matrix[i][_graph.Vertices[k]] + matrix[_graph.Vertices[k]][j]
							);
		}


		public static bool IsOriented(Graph graph) 
			=> graph.Edges.Where(e => e.IsDirected).Any();

		public static (int, List<List<Vertex>>) ComponentLinking(this Graph graph)
		{
			static void linkdfs 
			(
				ref Graph graph,
				Vertex v,
				ref HashSet<Vertex> used,
				ref List<Vertex> comp, 
				ref Dictionary<Vertex, List<Vertex>> g 
			) 
			{
				used.Add(v);
				comp.Add(v);
				foreach (var V in g[v])
					if (!used.Contains(V))
						linkdfs(ref graph, V, ref used,ref  comp,ref  g);
			}
			int counter = 0;
			int n = 0;
			Dictionary<Vertex, List<Vertex>> g = graph.ReturnAdjacencyList();
			var used = new HashSet<Vertex>();
			var res = new List<List<Vertex>>();

			foreach (var i in g.Keys)
			{
				
				var comp = new List<Vertex>();
				if (used.Contains(i)) continue;

				linkdfs(ref graph, i,ref  used,ref  comp,ref g );
				
				res.Add(comp);
				counter++;
			}
			return (counter, res);
		}
	}
}
