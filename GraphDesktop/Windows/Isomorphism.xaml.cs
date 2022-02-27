using System.ComponentModel;
using System.Windows;
using GraphLib;

namespace GraphDesktop.Windows
{
	public partial class Isomorphism : Window
	{
		public Graph Graph;
		public Isomorphism( Graph graph)
		{
			Graph = graph;
			InitializeComponent();
			Canvas.Model.PropertyChanged += ModelOnPropertyChanged;
			Graph.PropertyChanged += ModelOnPropertyChanged;
			Graph.Edges.CollectionChanged += (a,b) => ModelOnPropertyChanged(null, null);
			Canvas.Model.Edges.CollectionChanged += (a, b) => ModelOnPropertyChanged(null, null);
		}
		private void ModelOnPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			CheckBox.IsChecked = GraphLib.GraphTasks.GraphTasks.IsIsomorphWith(Graph, Canvas.Model);
		}
	}
}

