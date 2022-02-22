using System;
using System.Collections.Generic;
using System.Data;
namespace GraphLib.GraphTasks
{


	public static partial class GraphTasks
	{
		public static Dictionary<Vertex, double>  Djkstra(Graph _graph, Vertex Start)
		{
			var dist = new Dictionary<Vertex, double>();
	
			_graph.ReturnAdjacencyList(out Dictionary<Vertex, List<Vertex>> graph);

			var used = new HashSet<Vertex>();	
	
			foreach (var vertex in _graph.Vertices)
				dist.Add(vertex, Double.PositiveInfinity);
			
			dist[Start] = 0;

			for (int i = 0; i < _graph.Vertices.Count; i++)
			{
				Vertex v = null;

				foreach (var to in _graph.Vertices)
					if (!used.Contains(to) && (v == null || dist[to] < dist[v]))
						v = to;
				
				if (dist[v] == Double.PositiveInfinity)
					break;
				used.Add(v);
				foreach (var to in graph[v])
					if (dist[v] + v.EdgeWithVertex(to).Weight < dist[to])
						dist[to] = dist[v] + v.EdgeWithVertex(to).Weight;
			}
			return dist;
		}
	}
}
