namespace GraphLib
{
	public interface IStartEndVertexHolder
	{
		
		System.Windows.Point StartPoint
		{
			get;
		}
		System.Windows.Point EndPoint
		{
			get;
		}
		/// <summary>
		/// V1 - out vertex (from)
		/// V2 - in Vertex (to)
		/// </summary>
		Vertex StartVertex
		{
			get;
			set;
		}
		Vertex EndVertex
		{
			get;
			set;
		}
	}
}
