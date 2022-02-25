using System;
using System.ComponentModel;
using System.Drawing;
using System.Dynamic;
using System.Runtime.CompilerServices;
namespace GraphLib
{
	/// <summary>
	/// Ребер
	/// </summary>
	public sealed class Edge : EdgeBase
	{
		#region Properties & Variables
		#endregion

		internal Edge(int id, Vertex v1, Vertex v2 = null)
		{
			this.Id = id;
			this.StartVertex = v1;
			this.EndVertex = v2;
			Name = Id.ToString();
		}

		public bool IsIn(Vertex sender) => sender == EndVertex || sender == StartVertex;

		public void Delete()
		{
			StartVertex?.Edges.Remove(this);
			EndVertex?.Edges.Remove(this);
			OnDelete?.Invoke();
		}

	}
}
