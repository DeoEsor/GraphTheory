using System.Windows;
using GraphLib;

namespace GraphDesktop.Windows
{
	public partial class AdjencyGraph : Window
	{
		public Graph Graph { get; set; }
		public AdjencyGraph(Graph model)
		{
			DataContext = this;
			var i = GraphLib.GraphTasks.GraphTasks.IsFullified(model);
			Graph =  i
				? model 
				: GraphLib.GraphTasks.GraphTasks.AdjencifyGraph(model);

			InitializeComponent();
			GraphCanvas.Model = Graph;
			IsFullCheckbox.IsChecked = i;
			UpdateLayout();
		}
	}
}

