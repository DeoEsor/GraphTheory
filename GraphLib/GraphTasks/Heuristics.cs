using System;
namespace GraphLib.GraphTasks
{
	public partial class GraphTasks
	{
		public class Heuristics
		{
			public Func<Vertex,Vertex,double> CurrentHeuristic = Euclid;
			
			public static double Euclid(Vertex s, Vertex f)
				=> Math.Sqrt( (s.Point.X - f.Point.X) * (s.Point.X - f.Point.X) + (s.Point.Y - f.Point.Y) * (s.Point.Y - f.Point.Y));

			public static double Manhattan(Vertex s, Vertex f)
				=> Math.Abs((s.Point.X - f.Point.X)) + Math.Abs((s.Point.Y - f.Point.Y));

			public static double Chebushev(Vertex s, Vertex f)
				=> Math.Max( Math.Abs((s.Point.X - f.Point.X)), Math.Abs((s.Point.Y - f.Point.Y)));
		}
	}
}
