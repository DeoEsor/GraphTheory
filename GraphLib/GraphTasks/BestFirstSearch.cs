using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
namespace GraphLib.GraphTasks
{
    public static partial class GraphTasks
    {
	    public static List<Vertex> BestFirstSearch(Graph _graph, Vertex s, Vertex f, Heuristics heuristics = null)
		{
			if (heuristics == null)
				heuristics = new Heuristics();
			Dictionary<Vertex, List<Vertex>> graph = _graph.ReturnAdjacencyList();

			var path = new List<Vertex>();

			var queue = new PrioQueue<Vertex,double>();
			queue.Enqueue(s,0);

			var used = new Dictionary<Vertex, bool>();
			var dist = new Dictionary<Vertex, double>();
			var paretns = new Dictionary<Vertex, Vertex>();
            
			used.Add(s,  true);
			paretns.Add(s, null);

			while (!queue.IsEmpty())
			{
				Vertex v = queue.Dequeue();
                
				foreach (var to in graph[v])
				{
					if (used.Keys.Contains(to) && used[to]) continue;
                    
					used.Add(to , true);
					queue.Enqueue(to, heuristics.CurrentHeuristic(to,f));
					if (!dist.Keys.Contains(v))
						dist.Add(v, v.EdgeWithVertex(to).Weight);
					else
						dist.Add(to,dist[v] + v.EdgeWithVertex(to).Weight );
					paretns.Add( to, v);
                    
				}
			}

			if (!used.Keys.Contains(f))
				path = null;
			else
			{
				path = new List<Vertex>();
				for(Vertex v = f; v != null; v = paretns[v])
					path.Add(v);
                
				path.Reverse();
			}

			return path;
		}

		public class PrioQueue<T, V>
			where T : class 
		
		{
			int total_size;
			SortedDictionary<V, Queue<T>> storage;

			public PrioQueue ()
			{
				this.storage = new SortedDictionary<V, Queue<T>> ();
				this.total_size = 0;
			}

			public bool IsEmpty () => total_size == 0;
			

			public T Dequeue ()
			{
				if (IsEmpty ()) 
				
					throw new Exception ("Please check that priorityQueue is not empty before dequeing");
				else
					foreach (Queue<T> q in storage.Values)
						if (q.Count > 0) 
						{
							total_size--;
							return q.Dequeue ();
						}

				Debug.Assert(false,"not supposed to reach here. problem with changing total_size");

				return null; 
			}

			// same as above, except for peek.

			public T Peek ()
			{
				if (IsEmpty ())
					throw new Exception ("Please check that priorityQueue is not empty before peeking");
				else
					foreach (Queue<T> q in storage.Values)
						if (q.Count > 0)
							return q.Peek ();

				Debug.Assert(false,"not supposed to reach here. problem with changing total_size");

				return null; // not supposed to reach here.
			}

			public T Dequeue (V prio)
			{
				total_size--;
				return storage[prio].Dequeue ();
			}

			public void Enqueue (T item, V prio)
			{
				if (!storage.ContainsKey (prio))
					storage.Add (prio, new Queue<T> ());
				
				storage[prio].Enqueue (item);
				total_size++;
			}
		}
    }
}
