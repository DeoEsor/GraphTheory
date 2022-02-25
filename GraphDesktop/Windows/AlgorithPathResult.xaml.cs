using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using GraphLib;
namespace GraphDesktop.Windows
{
	public partial class AlgorithPathResult : Window
	{
		public AlgorithPathResult(Graph graph)
		{
			Graph = graph;
			Collection = null;
			InitializeComponent();
			
		}

		private Graph _graph;
		
		public static  readonly DependencyProperty EndListProperty = 
			DependencyProperty.Register(
				"EndListProperty", 
				typeof(ObservableCollection<GraphLib.Vertex>),
				typeof(AlgorithPathResult)
			);
		
		public static  readonly DependencyProperty PathResult = 
			DependencyProperty.Register(
				"PathResult", 
				typeof(ObservableCollection<GraphLib.Vertex>),
				typeof(AlgorithPathResult)
			);

		public ObservableCollection<GraphLib.Vertex> Collection
		{
			get => (ObservableCollection<GraphLib.Vertex>)GetValue(PathResult);
			set => SetValue(PathResult,value);
		}
		public ObservableCollection<GraphLib.Vertex> AvailableEndVertexes
		{
			get => (ObservableCollection<GraphLib.Vertex>)GetValue(EndListProperty);
			set => SetValue(EndListProperty,value);
		}
		public Graph Graph
		{
			get => _graph;
			set => _graph = value;
		}
		private GraphLib.Vertex End;
		private GraphLib.Vertex Start;
		private void StartChanged(object sender, SelectionChangedEventArgs e)
		{
			Start = (GraphLib.Vertex)StartList.SelectedItem;
			AvailableEndVertexes = new ObservableCollection<GraphLib.Vertex>(Graph.Vertices.Where(s => s != Start));
			EndList.ItemsSource = AvailableEndVertexes;
		}
		private void EndChanged(object sender, SelectionChangedEventArgs e)
		{
			End =(GraphLib.Vertex) EndList.SelectedItem;
			List<GraphLib.Vertex> path;
			if (((ComboBoxItem) AlgoBoxChoice.SelectedItem).Content == "BreadthFirst Search")
				GraphLib.GraphTasks.GraphTasks.BFS(Graph, Start, End, out path);
			else
				path = GraphLib.GraphTasks.GraphTasks.BestFirstSearch(Graph, Start, End);
			if (path != null)
			{
				Collection = new ObservableCollection<GraphLib.Vertex>(path);
				PathBox.ItemsSource = Collection;
			}
			else
				PathBox.ItemsSource = null;

		}
	}
}

