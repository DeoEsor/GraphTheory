using System.Drawing;
namespace GraphLib
{
	/// <summary>
	/// Ребер
	/// </summary>
	public class Edge
	{
		public int Id;
		public  bool IsDirected { get; set; }
		/// <summary>
		/// V1 - out vertex (from)
		/// V2 - in Vertex (to)
		/// </summary>
		public Vertex StartVertex; 
		public Vertex EndVertex;
		
		public Point StartPoint { get => StartVertex.Point; }
		public Point EndPoint { get => EndVertex.Point; }

		public int Weight { get; set; } = 1;

		internal Edge(int id, Vertex v1, Vertex v2)
		{
			this.Id = id;
			this.StartVertex = v1;
			this.EndVertex = v2;
		}
	}
}
