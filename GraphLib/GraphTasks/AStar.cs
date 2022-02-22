using System.Collections.Generic;
using System.Linq;
namespace GraphLib.GraphTasks
{
	public static partial class GraphTasks
	{

		public static Dictionary<Vertex, double> AStar(Graph graph, Vertex s, Vertex f)
		{
			List<Vertex> unvisited = new List<Vertex>(graph.Vertices);
            Dictionary<Vertex, Vertex> VertWithParent = new Dictionary<Vertex, Vertex>();
            var visited = new HashSet<Vertex>();

            visited.Add(s);
            /*
            while (unvisited.Count > 0)
            {
                Vertex curVert = unvisited.Min();
                unvisited.Remove(curVert);
                visited.Add( curVert);

                List<Edge> connectedEdges = new List<Edge>(curVert.Edges);

                while (connectedEdges.Count > 0)
                {
                    var e = connectedEdges.Min(); // Picking edge with the less weight
                    connectedEdges.Remove(e);

                    Vertex obsVert = e.EndVertex; // Taking vertex on the end of this edge

                    double Length = curVert.Length + e.Weight; 
                    double h = heuristicPathLength(obsVert, f);

                    if (!visited.Contains(obsVert))
                    {
                        Vertex v = unvisited.Find(x => x == obsVert);
                        Vertex existingVert = v is null ? newVert : v;
                        if (v is null)
                        {
                            unvisited.Add(existingVert);
                            VertWithParent.Add(existingVert, curVert);
                        }
                        if (newVert.CompareTo(existingVert) < 0)
                        {
                            existingVert.H = h; existingVert.Length = Length;
                            VertWithParent[existingVert] = curVert;
                        }

                        if (obsVert == f)
                        {
                            Dictionary<Vertex, double> retDict = new Dictionary<Vertex, double>();
                            retDict.Add(obsVert, existingVert.Weight);
                            Vertex rootVert = VertWithParent[existingVert];
                            var a = VertWithParent;
                            while (rootVert != s)
                            {
                                retDict.Add(rootVert, rootVert.Weight);
                                rootVert = VertWithParent[rootVert];
                            }
                            retDict.Add(rootVert, rootVert.Weight);

                            return retDict;
                        }
                    }
                }

            }
                */
            return null;
		}
	}
}
