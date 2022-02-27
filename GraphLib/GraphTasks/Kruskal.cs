using System.Collections.Generic;
using System.Xml;
namespace GraphLib.GraphTasks
{
	public static partial class GraphTasks
	{

		public static Graph Kruskal(Graph graph)
		{
			int m;
			List<  Edge > g = new List<Edge>(); // вес - вершина 1 - вершина 2
			Dictionary<Vertex, int> tree_id  = new Dictionary<Vertex, int>();
			List < Edge > res = new List<Edge>();
			var gra = new Graph();
			double cost = 0;
			foreach (var VARIABLE in graph.Vertices)
				gra.CreateVertex(new Vertex(gra, VARIABLE.Id, VARIABLE.Point));

			foreach (var VARIABLE in graph.Edges)
				g.Add(VARIABLE);

			g.Sort();
			
			
			int Z = 0;
			foreach (var VARIABLE in graph.Vertices)
				tree_id.Add(VARIABLE, Z++);
			
			for (int i=0; i<g.Count; ++i)
			{
				Vertex a = g[i].StartVertex, b = g[i].EndVertex;
				double l = g[i].Weight;
				if (tree_id[a] != tree_id[b])
				{
					cost += l;
					res.Add (a.EdgeWithVertex(b));
					int old_id = tree_id[b],  new_id = tree_id[a];
					foreach (var vertex in graph.Vertices)
						if (tree_id[vertex] == old_id)
							tree_id[vertex] = new_id;
				}
			}

			foreach (var edge in res)
				gra.CreateEdge(gra.FindVertexByID(edge.StartVertex.Id), gra.FindVertexByID(edge.EndVertex.Id));
			return gra;
		}
	}
	
}
