using System.Collections.Generic;
using System.Windows;
using GraphLib;
namespace GraphDesktop.Windows
{
	public partial class Coloring : Window
	{
		public Coloring(Graph graph)
		{
			Graph = graph;
			InitializeComponent();
			
			View.ItemsSource = ColoringData;
			Graph.PropertyChanged += (sender, args) => View.ItemsSource = ColoringData;
		}


		public List<string> ColoringData
		{
			get
			{
				var list = new List<string>();
				GraphLib.GraphTasks.GraphTasks.GraphColoring.Coloring(Graph, out var colors, out  int ChromNumber);
				list.Add("Хроматическое число - " + ChromNumber.ToString());
				foreach (var vertexchrome in colors)
					list.Add(vertexchrome.Key.Name + " - " + vertexchrome.Value.ToString());

				return list;
			}
			
		}
		
		public Graph Graph { get; set; }
	}
}

