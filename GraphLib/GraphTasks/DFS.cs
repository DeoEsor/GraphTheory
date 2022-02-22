using System.Collections.Generic;
namespace GraphLib.GraphTasks
{

	public static partial class GraphTasks
	{
		public static void DFS(this Graph _graph, Vertex vertex,HashSet<Vertex> visited = null)
		{
			visited ??= new HashSet<Vertex>();
			_graph.ReturnAdjacencyList(out var graph);
			visited.Add(vertex);
			foreach (var vertexGoing in vertex.GoingToVertexes)
				DFS(_graph,vertexGoing);
			
		}
	}
}
