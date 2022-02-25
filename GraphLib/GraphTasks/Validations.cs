using System;
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

		public static bool IsFullified(this Graph graph)
		{
			var adj = graph.FillAdjacencyMatrix();

			foreach (var pair in adj)
				foreach (var par in pair.Value)
					if (par.Value == double.PositiveInfinity)
						return false;
			
			return true;
		}
		
		public static bool IsIsomorphWith(this Graph graph, Graph other)
		{
			var first = graph.FillAdjacencyMatrix();
			var second = other.FillAdjacencyMatrix();

			if (first.Count != second.Count)
				return false;

			int size = first.Count;

			List<string> firstStrings = new List<string>();
			List<string> secondStrings = new List<string>();


			for (int i = 0; i < size; ++i)
			{
				firstStrings.Add(GetRowAsStringWithoutWeighs(first[graph.Vertices[i]]));
				secondStrings.Add(GetRowAsStringWithoutWeighs(second[other.Vertices[i]]));
			}

			firstStrings.Sort(); secondStrings.Sort();
			bool iso = true;
			for (int i = 0; i < size; ++i)
			{
				iso = iso && firstStrings[i] == secondStrings[i];
				if (!iso)
					break;
			}


			return iso;;
		}

		public static string GetRowAsStringWithoutWeighs(Dictionary<Vertex,double> row)
		{
			string str = String.Empty;

			foreach (var pair in row)
			{
					str += pair.Value == Double.PositiveInfinity ? 0.ToString() : 1.ToString() ;
					str += " ";
			}
	
			return str.TrimEnd(' ');
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
