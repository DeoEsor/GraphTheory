using System.Collections.Generic;
using System.Linq;
namespace GraphLib.GraphTasks
{
	public static partial class GraphTasks
	{

		public static (List<Vertex>, double) AStar(Graph graph, Vertex s, Vertex f, Heuristics heuristics = null)
		{
            if (heuristics == null)
                heuristics = new Heuristics();

			var path = new List<Vertex>();

			var queue = new PrioQueue<Vertex, double>();
			var camefrom = new Dictionary<Vertex,Vertex>();
			var costsofar = new Dictionary<Vertex, double>();
			
			queue.Enqueue(s, 0);
			camefrom.Add(s, null);
			costsofar.Add(s, 0);
			
			while (!queue.IsEmpty())
			{
				Vertex v = queue.Dequeue();

				if (v == f)
					break;
				foreach (var next in v.AchievableVertexes)
				{
					double newcost = costsofar[v] + v.EdgeWithVertex(next).Weight;

					if (!costsofar.Keys.Contains(next) || newcost < costsofar[next])
					{
						costsofar[next] = newcost;
						queue.Enqueue(next, newcost + heuristics.CurrentHeuristic(next, f));
						
						if (camefrom.Keys.Contains(next))
							camefrom[next] = v;
						else
							camefrom.Add(next, v);
					}

				}
			}
			
			if (!camefrom.Keys.Contains(f))
				path = null;
			else
			{
				path = new List<Vertex>();
				for(Vertex v = f; v != null; v = camefrom[v])
					path.Add(v);
                
				path.Reverse();
			}
			double dist = 0;
			for (int i = 1; i < path?.Count; i++)
				dist += path[i - 1].EdgeWithVertex(path[i]).Weight;

			return (path, dist);
		}
	}
}
