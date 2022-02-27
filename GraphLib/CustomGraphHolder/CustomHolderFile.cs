using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Windows;
namespace GraphLib
{
	public static class CustomHolderFile
	{
		/// <summary>
		/// список рёбер вершин вида Edges{i(a, k, l), . . .},
		/// где i — номер ребра, a — вес ребра, k и l — номера или имена вершин;
		/// список вершин также может быть задан с привязкой по координатам в следующем виде: Vertex{v(x, y)}, где v — имя
		/// или номер вершины, x и y — координаты в пикселях;
		/// если список вершин не указан, то их координаты могут задаваться произвольно;
		/// в файле могут быть комментарии начинающиеся с %
		/// </summary>
		/// <param name="graph"></param>
		/// <returns></returns>
		public  static string[] GraphToFile(Graph graph)
		{
			var res = new List<string>();
			
			res.Add("% " + graph.Name.ToString());
			
			res.Add(nameof(Vertex));
			res.Add("{");
			foreach (var vertex in graph.Vertices)
				res.Add( '\t' + vertex.ToString() + ",");
			
			res.Add("}");
			
			
			res.Add("");
			
			res.Add(nameof(Edge));
			res.Add("{");
			foreach (var edge in graph.Edges)
				res.Add('\t' + edge.ToString() + ",");
			
			res.Add("}");
			
			return res.ToArray();
		}
		
		public  static Graph FileToGraph(List<string> file)
		{
			var res = new Graph();

			for (int i = 0; i < file.Count; i++)
				if (file[i].StartsWith("%") || file[i].Trim().Length == 0)
					file.Remove(file[i]);

			for (int i = 0; i < file.Count; i++)
			{
				if (file[i] == nameof(Vertex))
				{
					i++;
					while (file[i] != "}")
					{
						i++;
						if (file[i] == "}") break;
						var a = file[i].Split(',', '(', ')', '\t').
							Where(s => s != String.Empty).ToArray();
						res.Vertices.Add(
							new Vertex(res,
											Convert.ToInt32(a[0]), 
											new Point(
												Convert.ToInt32(a[1]), 
												Convert.ToInt32(a[2])
												)
								)
							);
						res._verticalid = Convert.ToInt32(a[0]);
					}
				}
				
				if (file[i] == nameof(Edge))
				{
					i++;
					while (file[i] != "}")
					{
						i++;
						if (file[i] == "}") break;
						var a = file[i].Split(',', '(', ')', '\t').
							Where(s => s != String.Empty).ToArray();
						var fv = res.FindVertexByID(Convert.ToInt32(a[2]));
						var sv = res.FindVertexByID(Convert.ToInt32(a[3]));
						if (sv == null || fv == null)
							throw new ArgumentException("Incorrect File");
						res.Edges.Add(
							new Edge(Convert.ToInt32(a[0]), fv, sv)
								{Weight = Convert.ToInt32(a[1])}
										);
						res._edgeid = Convert.ToInt32(a[0]);
					}
				}
			}
			return res;
		}
	}
}
