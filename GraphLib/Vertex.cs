using System;
using System.Collections.Generic;
using System.Drawing;
namespace GraphLib
{
	/// <summary>
	/// Vertex representation
	/// Вершина
	/// </summary>
	public class Vertex
	{
		public int Id;
		public Point Point { get; set; }
		
		private List<Edge> _edges;
		Random _random = new Random();
		
		public int Weight { get; set; } = 1;

		public Vertex(int id, Point point)
		{
			this.Id = id;
			this.Point = point;
		}

		public List<Edge> Edges
		{
			get => _edges;
		}

		public void AddEdge(Edge e)
		{
			_edges.Add(e);
		}
	}
}
