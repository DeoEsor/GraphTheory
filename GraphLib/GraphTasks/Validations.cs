using System;
using System.Collections.Generic;
using System.Linq;
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
			if (graph.Vertices.Count == other.Vertices.Count && other.Vertices.Count == 0)
				return true;
			if (graph.Vertices.Count != other.Vertices.Count)
				return false;
			var a = graph.AdjencyMatrix();
			var b = other.AdjencyMatrix();

			var perm = new List<int>();
			for (int i = 0; i < graph.Vertices.Count; i++)
				perm.Add(i);

			var allperm = GetPermutations(perm, perm.Count);

			foreach (var curperm in allperm)
				if (Match(in a, in b, curperm.ToList()))
					return true;

			return false;
			
			static IEnumerable<IEnumerable<T>>
				GetPermutations<T>(IEnumerable<T> list, int length)
			{
				if (length == 1) return list.Select(t => new T[] { t });

				return GetPermutations(list, length - 1)
					.SelectMany(t => list.Where(e => !t.Contains(e)),
						(t1, t2) => t1.Concat(new T[] { t2 }));
			}
			bool Match(in List<List<int>>  a, in List<List<int>>  b, List<int> perm)
			{

				for (int i = 0; i < a.Count; i++)
					for (int j = 0; j < a.Count; j++)
						if (a[i][j] != b[perm[i]][perm[j]])
							return false;

				return true;
			}
		}
		/*
		 * var first = graph.FillAdjacencyMatrix();
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

			firstStrings.Sort(); 
			secondStrings.Sort();
			bool iso = true;
			for (int i = 0; i < size; ++i)
			{
				iso &= string.Equals(firstStrings[i], secondStrings[i]);
				if (!iso)
					break;
			}


			return iso;;
		 */

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
