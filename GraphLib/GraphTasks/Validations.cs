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
			graph.FillAdjacencyMatrix(out var first);
			graph.FillAdjacencyMatrix(out var second);

			if (first.Length != second.Length 
				|| (first.GetUpperBound(0) != second.GetUpperBound(0)
				||  first.GetUpperBound(1) != second.GetUpperBound(1)))
				return false;

			int size = first.GetUpperBound(0);

			for (int i = 0; i < first.GetUpperBound(0); i++)
				for (int j = 0; j < first.GetUpperBound(1); j++)
					if (first[i, j] != second[i, j])
						return false;
			
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
