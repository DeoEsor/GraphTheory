using System.Windows;
using GraphLib;
using GraphLib.GraphTasks;

namespace GraphDesktop.Windows
{
	public partial class Linking : Window
	{
		public Linking( Graph graph)
		{
			Graph = graph;
			graph.PropertyChanged += (sender, args) => Update();
			InitializeComponent();
			Update();
		}
		
		public Graph Graph { get; set; }

		public void Update()
		{
			linq.IsChecked = Graph.Linking();
			if (linq.IsChecked.Value)
			{
				weak.IsChecked = Graph.IsWeakLinking();
				Strong.IsChecked = Graph.IsStrongLinking();	
			}
			else
				weak.IsChecked = Strong.IsChecked = false;
			var a = Graph.ComponentLinking();
			Count.Text = a.Item1.ToString();
			View.ItemsSource = a.Item2;

		}
	}
}

