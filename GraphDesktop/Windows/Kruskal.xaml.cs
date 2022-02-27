using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using GraphLib;

namespace GraphDesktop.Windows
{
	public partial class Kruskal : Window
	{
		public Graph Graph { get; set; }
		public Kruskal(Graph graph)
		{
			graph.PropertyChanged += GraphOnPropertyChanged;
			Graph = graph;
			InitializeComponent();
			
			GraphCanvas.Model = GraphLib.GraphTasks.GraphTasks.Kruskal(graph);

		}
		private void GraphOnPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			GraphCanvas.Model.Name = "Минимальное островное дерево графа : " + Graph.Name;
			GraphCanvas.Model = GraphLib.GraphTasks.GraphTasks.Kruskal(Graph);
		}
	}
}

