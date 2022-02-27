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
			DistText.Visibility = Visibility.Hidden;
			DistResult.Visibility = Visibility.Hidden;
			UpdateLayout();
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
			EndList.SelectedIndex = -1;
		}
		private void EndChanged(object sender, SelectionChangedEventArgs e)
		{
			
			DistText.Visibility = Visibility.Hidden;
			DistResult.Visibility = Visibility.Hidden;
			
			End =(GraphLib.Vertex) EndList.SelectedItem;
			List<GraphLib.Vertex> path;
			if (((ComboBoxItem) AlgoBoxChoice.SelectedItem).Content.ToString() == "BreadthFirst Search")
				GraphLib.GraphTasks.GraphTasks.BFS(Graph, Start, End, out path);
			else if (((ComboBoxItem)AlgoBoxChoice.SelectedItem).Content.ToString() == "Best-First Search")
				path = GraphLib.GraphTasks.GraphTasks.BestFirstSearch(Graph, Start, End);
			else
			{
				var a = GraphLib.GraphTasks.GraphTasks.AStar(Graph, Start, End);
				path = a.Item1;
				
				DistText.Visibility = Visibility.Visible;
				DistResult.Visibility = Visibility.Visible;
				DistResult.Text = a.Item2.ToString();
			}
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

