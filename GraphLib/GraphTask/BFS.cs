using System;
using System.Collections.Generic;

namespace GraphLib.GraphTasks
{
    public static partial class GraphTasks
    {
        /// <summary>
        /// // Граф - список смежности
        /// g[u][0] = (v, w) u->v (weight w)
        /// Условие - граф невзвешен 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="s"></param>
        /// <param name="f"></param>
        /// <param name="path"></param>
        /// <returns>есть ли путь</returns>
        public static bool BFS(List<List<(int, double)>> g, int s, int f, out List<int> path)
        {
            List<bool> used = new List<bool>(g.Count); // is all false??
            Queue<int> q = new Queue<int>();
            q.Enqueue(s);
            List<double> d = new List<double>(g.Count);
            List<int> p = new List<int>(g.Count);
            used[s] = true;
            p[s] = -1;
            while (q.Count != 0)
            {
                int v = q.Dequeue();
                foreach (var edge in g[v])
                {
                    int to = edge.Item1;
                    if (!used[to])
                    {
                        used[to] = true;
                        q.Enqueue(to);
                        d[to] = d[v] + 1;
                        p[to] = v;
                    }
                }
            }

            if (!used[f])
            {
                path = null;
                return false;
            }
            else
            {
                path = new List<int>();
                for (int v = f; v != -1; v = p[v])
                {
                    path.Add(v);
                }
                path.Reverse();
                return true;
            }

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
