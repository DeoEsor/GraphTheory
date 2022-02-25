using System.Windows;
using System.Windows.Controls;
using GraphLib;
namespace GraphDesktop.Windows
{
	public partial class DijkstraUI : Window
	{
		public DijkstraUI(Graph graph)
		{
			Graph = graph;
			InitializeComponent();
		}
		public  GraphLib.Graph Graph { get; set; }
		public GraphLib.Vertex Start { get; set; }
		private void StartList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
			=>  PathBox.ItemsSource =
				GraphLib.GraphTasks.GraphTasks.
					Djkstra(
						Graph,
						Start = (GraphLib.Vertex) StartList.SelectedItem 
						);
		private void AlgoListChanged(object sender, SelectionChangedEventArgs e)
		{
			//GraphLib.GraphTasks.GraphTasks.AStar( )
		}
	}
}

