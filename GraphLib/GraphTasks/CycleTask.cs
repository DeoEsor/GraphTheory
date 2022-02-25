using System;
using System.Collections.Generic;
using System.Linq;
namespace GraphLib.GraphTasks
{
	public static partial class GraphTasks
	{
		public static void CycleTask(Graph graph)
		{

			var parentsmatrix = new Dictionary<Vertex, Dictionary<Vertex, Vertex>>(); 
			var matrix = graph.FillAdjacencyMatrix();

			foreach (var edge in graph.Edges)
			{
				parentsmatrix.Add(edge.StartVertex, new Dictionary<Vertex, Vertex>());
				parentsmatrix[edge.StartVertex].Add(edge.EndVertex, edge.EndVertex);
			}

			foreach (var vertex in graph.Vertices)
			{
				if (parentsmatrix.Keys.Contains(vertex))
				{
					if (parentsmatrix[vertex].Keys.Contains(vertex))
						parentsmatrix[vertex][vertex] = vertex;
					else
						parentsmatrix[vertex].Add(vertex, vertex);
				}
				else
				{
					parentsmatrix.Add(vertex, new Dictionary<Vertex, Vertex>());
					parentsmatrix[vertex].Add(vertex, vertex);
				}
					
			}
			
			
			for (int k = 0; k < matrix.Count; k++)
				foreach (var i in graph.Vertices)
					foreach (var j in graph.Vertices)
						if (matrix[i][j] > matrix[i][graph.Vertices[k]] + matrix[graph.Vertices[k]][j])
						{
							matrix[i][j] =  matrix[i][graph.Vertices[k]] + matrix[graph.Vertices[k]][j];
							//TODO COntains check
							parentsmatrix[i][j] = parentsmatrix[i][graph.Vertices[k]];
						}
							
			
			
		}

		public static List<Vertex> Dist(Dictionary<Vertex, Dictionary<Vertex, Vertex>> parentsmatrix, Vertex u, Vertex v)
		{
			if (parentsmatrix[u][v] == null)//TODO 
				return null;
			var path = new List<Vertex>();

			path.Add(u);
			Vertex current = u;
			while (current != v)
			{
				current = parentsmatrix[current][v];
				path.Add(current);
			}
			return  path;
		}
	}
}
