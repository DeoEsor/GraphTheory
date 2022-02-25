using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
namespace GraphLib.GraphTasks
{
	public static partial class GraphTasks
	{
		public static class GraphColoring
		{
			private static List<int> BuddaStColoring;
			static int _minimalcoloring = Int32.MaxValue;
			
			public static void Coloring(Graph _graph, out Dictionary<Vertex, int> colors, out int ChromoNumber)
			{
				int unique = 0;
				BuddaStColoring = null;
				_minimalcoloring = Int32.MaxValue;
				colors = new Dictionary<Vertex, int>();
				
				var a = new List<int>();
				for (int i = 0; i < _graph.Vertices.Count; i++)
					a.Add(0);
		
				Recursive(_graph, ref a);

				for (int i = 0; i < BuddaStColoring.Count; i++)
					colors.Add(_graph.Vertices[i], BuddaStColoring[i]);	

				ChromoNumber = BuddaStColoring.Distinct().Count();
			}

			internal static void Recursive(Graph graph, ref List<int> colors, int depth = 0)
			{
				if (depth == colors.Count)
				{
					if (CheckColoring(graph, colors) && colors.Max() < _minimalcoloring)
					{
							BuddaStColoring = new List<int>( colors);
							_minimalcoloring = colors.Max();
					} 
					return;
				}

				for (int i = 0; i < colors.Count; i++)
				{
					colors[depth] = i;
					Recursive(graph, ref colors, depth + 1);
				}
			
			}

			internal static bool CheckColoring(Graph graph, List<int> colors)
			{
				foreach (var edge in graph.Edges)
					if(colors[edge.StartVertex.Id] == colors[edge.EndVertex.Id])
						return false;
				return true;
			}
			
		}
	}
}
