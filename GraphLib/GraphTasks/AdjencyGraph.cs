namespace GraphLib.GraphTasks
{
	public static partial class GraphTasks
	{
		public static Graph AdjencifyGraph(this Graph graph)
		{
			var adj = graph.FillAdjacencyMatrix();
			var adjgraph = new Graph();
			foreach (var vertex in graph.Vertices)
			{
				adjgraph.CreateVertex(0, 0);
				
			}
			foreach (var pair in adj)
				foreach (var par in pair.Value)
					if (par.Value == double.PositiveInfinity)
						adjgraph.CreateEdge
						(
							adjgraph.Vertices[graph.Vertices.IndexOf(pair.Key)],
							adjgraph.Vertices[graph.Vertices.IndexOf(par.Key)]
							);

			return adjgraph;
		}
	}
}
