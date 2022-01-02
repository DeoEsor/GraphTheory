using System.Windows.Controls;

namespace GraphDesktop.UserContols
{
	public partial class Edge : UserControl
	{
		public Edge()
		{
			InitializeComponent();
		}

		public GraphLib.Edge Model;
		
		public string Name { get; set; }
	}
}

