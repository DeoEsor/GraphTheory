using System.Windows.Controls;
using System.Windows.Media;

namespace GraphDesktop.UserContols
{
	public partial class Edge : UserControl
	{
		public Edge()
		{
			InitializeComponent();
		}

		public GraphLib.Edge Model { get; set; }
		
		public string EdgeName { get; set; }

		public GraphCanvas GraphCanvas;
		
	}
}

