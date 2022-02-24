using System;
using System.Collections.Generic;
using System.Linq;
namespace GraphLib.GraphTasks
{
	public partial class GraphTasks
	{
		public static void GraphParametrs
		(
			Graph _graph,
			out Dictionary<Vertex, int> VertexWeights, out double Radiues, out double Diametr, out Dictionary<Vertex, int> VertexPower
		)
		{
			VertexWeights = new Dictionary<Vertex, int>();
			VertexPower = new Dictionary<Vertex, int>();
			foreach (var vertex in _graph.Vertices)
			{
				VertexWeights.Add(vertex, vertex.VertexWeight());
				VertexPower.Add(vertex, 0);
			}

			foreach (var edge in _graph.Edges)
			{
				VertexPower[edge.StartVertex]++;
				VertexPower[edge.EndVertex]++;
			}

			Radiues = Double.PositiveInfinity;
			Diametr = Double.NegativeInfinity;

			foreach (var from in _graph.Vertices)
				foreach (var distance in Djkstra(_graph,from).Values)
					if (!double.IsPositiveInfinity(distance)) 
						Diametr = Math.Max(Diametr,distance);

			foreach (var from in _graph.Vertices)
			{
				var dist = Djkstra(_graph,from);
				double Max = Double.NegativeInfinity;

				foreach (var distance in dist.Values)
				{
					if (double.IsPositiveInfinity(distance)) continue;
					Max = Math.Max(Diametr,distance);
				}
				if (!double.IsPositiveInfinity(Max))
					Radiues = Math.Min(Radiues, Max);
			}
		}
		
		public static double GraphRadius(this Graph _graph)
		{
			double Radius = Double.PositiveInfinity;

			var matrix = _graph.FillAdjacencyMatrix();
			for (int k = 0; k < matrix.Count; k++)
				foreach (var i in _graph.Vertices)
					foreach (var j in _graph.Vertices)
						matrix[i][j] = 
							Math.Min(
									matrix[i][j],
									matrix[i][_graph.Vertices[k]] + matrix[_graph.Vertices[k]][j]
								);
			double res = double.PositiveInfinity;
			foreach (var i in _graph.Vertices)
			{
				var max = double.NegativeInfinity;
				foreach (var pair in matrix[i])
					if (pair.Value != Double.PositiveInfinity && pair.Key != i)
						max = Math.Max(max, pair.Value);
				if (max != Double.NegativeInfinity)
					res = Math.Min(max, res);
			}
				
			return res;
		}
		
		public static double GraphDiametr(this Graph _graph)
		{
			double Diametr = Double.NegativeInfinity;
			
			foreach (var from in _graph.Vertices)
				foreach (var distance in Djkstra(_graph,from).Values)
					if (!double.IsPositiveInfinity(distance)) 
						Diametr = Math.Max(Diametr,distance);

			foreach (var from in _graph.Vertices)
			{
				var dist = Djkstra(_graph,from);
				double Max = Double.NegativeInfinity;

				foreach (var distance in dist.Values)
				{
					if (double.IsPositiveInfinity(distance)) continue;
					Max = Math.Max(Diametr,distance);
				}
			}

			return Diametr;
		}

		public static Dictionary<Vertex, int> VertexWeight(this Graph _graph)
		{
			var VertexWeights = new Dictionary<Vertex, int>();
			
			foreach (var vertex in _graph.Vertices)
				VertexWeights.Add(vertex, vertex.VertexWeight());

			return VertexWeights;
		}
		
		public static Dictionary<Vertex, int> VertexPower(this Graph _graph)
		{
			var VertexPowers = new Dictionary<Vertex, int>();
			
			foreach (var vertex in _graph.Vertices)
				VertexPowers.Add(vertex, 0);
			
			foreach (var edge in _graph.Edges)
			{
				VertexPowers[edge.StartVertex]++;
				VertexPowers[edge.EndVertex]++;
			}
			
			return VertexPowers;
		}
		
		public static int VertexWeight(this Vertex v) => Djkstra(v.Graph as Graph, v).Values.Where(s => !double.IsPositiveInfinity(s)).Count();
	}
}
