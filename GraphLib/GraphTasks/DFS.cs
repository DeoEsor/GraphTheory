using System.Collections.Generic;
namespace GraphLib.GraphTasks
{

	public static partial class GraphTasks
	{
		public static void DFS(this Graph _graph, Vertex vertex,HashSet<Vertex> visited = null)
		{
			visited ??= new HashSet<Vertex>();
			var graph = _graph.ReturnAdjacencyList();
			visited.Add(vertex);
			foreach (var vertexGoing in vertex.AchievableVertexes)
				DFS(_graph,vertexGoing);
			
		}
	}
}
