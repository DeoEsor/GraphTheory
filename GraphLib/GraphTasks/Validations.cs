using System.Collections.Generic;
namespace GraphLib.GraphTasks
{
	public partial class GraphTasks
	{
		public static bool IsGraphWeighted(this Graph graph)
		{
			foreach (var edge in graph.Edges)
			{
				if (edge.Weight != 1)
					return true;
			}
			return false;
		}
		
		public static bool IsIsomorphWith(this Graph graph, Graph other)
		{
			var first = graph.FillAdjacencyMatrix();
			var second = graph.FillAdjacencyMatrix();

			//TODO
			
			return true;
		}
		
		public static bool IsConnected(  this Graph graph, List<Vertex> Vs)
		{
			int distCount = -1;
			foreach (var vertex in Vs)
			{
				var curLenDist = Djkstra(graph, vertex);
				if (distCount == -1)
					distCount = curLenDist.Count;

				if (curLenDist.Count != distCount) return false;
			}
			return true;
		}
	}
}
