using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
namespace GraphLib.GraphTasks
{
	public partial class GraphTasks
	{
		public static List<Vertex> СommisVoyageur(Graph _graph)
		{
			var res = new List<Vertex>();
			//1
			var matrix = _graph.FillAdjacencyMatrix();
			var minrows = new Dictionary<Vertex, double>();
			var mincolumns = new Dictionary<Vertex, double>();
			var shtaf = new Dictionary<Vertex, Dictionary<Vertex, double>>();
			double lowedge = 0;

			foreach (var pair in matrix)
				matrix[pair.Key].Remove(pair.Key);		
			
			//2 TODO
			foreach (var pair in matrix)
				minrows.Add(pair.Key, pair.Value.Values.Min());

			//3
			foreach (var pair in matrix)
				foreach (var variable in pair.Value)
					matrix[pair.Key][variable.Key] -= minrows[pair.Key];
			
			//4 TODO
			foreach (var pair in matrix)
				foreach (var VARIABLE in pair.Value)
				{
					if(mincolumns.ContainsKey(VARIABLE.Key))
						mincolumns[VARIABLE.Key] = Math.Min(VARIABLE.Value, mincolumns[VARIABLE.Key]) ;
					else
						mincolumns.Add(VARIABLE.Key, VARIABLE.Value);
				}
				
			// 5
			
			foreach (var pair in matrix)
				foreach (var variable in pair.Value)
					matrix[pair.Key][variable.Key] -= mincolumns[variable.Key];
			//6

			foreach (var VARIABLE in minrows.Values)
				lowedge += VARIABLE;
			foreach (var VARIABLE in mincolumns.Values)
				lowedge += VARIABLE;
			
			//7

			foreach (var row in matrix)
				foreach (var cell in row.Value)
					if (cell.Value == 0)
					{
						shtaf.Add(row.Key, new Dictionary<Vertex, double>());
					//	shtaf[row.Key].Add(cell.Key, );
					}
			
			return res;
			
		}
	}
}
