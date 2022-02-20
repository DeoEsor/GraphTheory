using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;

namespace GraphLib.GraphTasks
{
    public static partial class GraphTasks
    {
        /// <summary>
        /// // Граф - список смежности
        /// g[u][0] = (v, w) u->v (weight w)
        /// Условие - граф невзвешен 
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="s"></param>
        /// <param name="f"></param>
        /// <param name="path"></param>
        /// <returns>есть ли путь</returns>
        public static void BFS(Graph _graph, Vertex s, Vertex f, out List<Vertex> path)
        {
            _graph.ReturnAdjacencyList(out Dictionary<Vertex, List<Vertex>> graph);

            var queue = new Queue<Vertex>();
            queue.Enqueue(s);
            (var used,var dist, var paretns) 
                = ( new Dictionary<Vertex, bool>(), new Dictionary<Vertex, double>(), new Dictionary<Vertex, Vertex>());

            used[s] = true;
            paretns[s] = null;

            while (queue.Count != 0)
            {
                Vertex v = queue.Dequeue();
                
                foreach (var to in graph[v])
                {
                    if (used[to]) continue;
                    
                    used[to] = true;
                    queue.Enqueue(to);
                    dist[to] = dist[v] + v.EdgeWithVertex(to).Weight;//Check
                    paretns[to] = v;
                    
                }
            }

            if (!used[f])
                path = null;
            else
            {
                path = new List<Vertex>();
                for(Vertex v = f; v != null; v = paretns[v])
                    path.Add(v);
                
                path.Reverse();
            }
        }
    }
}

