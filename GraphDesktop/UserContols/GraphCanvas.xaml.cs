using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GraphDesktop.UserContols
{
	public partial class GraphCanvas : UserControl
	{
		public GraphCanvas()
		{
			InitializeComponent();
		}
		
		
		
		private void UIElement_OnMouseUp(object sender, MouseButtonEventArgs e)
		{
			popup.IsOpen = true;
		}


		public void AddElement(object sender, MouseButtonEventArgs e)
		{
			Vertex vertex = new Vertex
			{
				Height = 50,
				Width = 50
			};
			//TODO creating a vertex model in fabric method x and y - 
			// Mouse.GetPosition(this).X; Mouse.GetPosition(this).Y;
		}
	}
}

