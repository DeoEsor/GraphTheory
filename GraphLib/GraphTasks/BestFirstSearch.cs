using System;
using System.Collections.Generic;
namespace GraphLib.GraphTasks
{
    public static partial class GraphTasks
    {
	    public static List<Vertex> BestFirstSearch(Graph graph, Vertex start, Vertex target)
            {
                var vertexes = new Queue<Vertex>();
                var RouteVertsForVert = new Dictionary<Vertex, Vertex>();
                var visited = new HashSet<Vertex>();

                if (start == target)
                {
                    List<Vertex> ret = new List<Vertex>();
                    ret.Add(start);
                    return ret;
                }

                visited.Add( start);
                vertexes.Enqueue(start);
                while (vertexes.Count > 0)
                {
                    Vertex v = vertexes.Dequeue();

                    List<Vertex> curVerts = v.GoingToVertexes;

                    foreach (var vertex in curVerts)
                    {;
                        if (visited.Contains(vertex)) continue;
                        
                        visited.Add(vertex);
                        vertexes.Enqueue(vertex);

                        RouteVertsForVert.Add(vertex, v);

                        if (vertex != target) continue;
                        
                        List<Vertex> retList = new List<Vertex>();
                        retList.Add(vertex);

                        Vertex prevVert = RouteVertsForVert[vertex];

                        while (prevVert != start)
                        {
                            retList.Add(prevVert);
                            prevVert = RouteVertsForVert[prevVert];
                        }

                        retList.Add(prevVert);

                        return retList;   
                    }
                }

                return null;
            }
    }
}
