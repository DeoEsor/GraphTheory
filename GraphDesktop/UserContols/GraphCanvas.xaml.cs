using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace GraphDesktop.UserContols
{
	public partial class GraphCanvas : UserControl
	{
		public GraphLib.Graph Model { get; set; }
		
		public GraphCanvas()
		{
			InitializeComponent();
		}

		private void UIElement_OnMouseUp(object sender, MouseButtonEventArgs e)
		{
			if (!Popup.IsOpen)
				Popup.IsOpen = true;
			else
			{
				//Redraw popup window
				Popup.IsOpen = false;
				Popup.IsOpen = true;
			}
		}

		public void Clear(object sender, RoutedEventArgs e)
		{
			Popup.IsOpen = false;
			Canvas.Children.Clear();
			
			Model.ClearGraph();
		}


		public void AddElement(object sender, MouseButtonEventArgs e)
		{
			Popup.IsOpen = false;
			Vertex vertex = new Vertex
			{
				Height = Canvas.Height / 10,
				Width = Canvas.Width / 10,
				Model = Model.CreateVertex((int)Mouse.GetPosition(this).X, 
											(int)Mouse.GetPosition(this).Y)
			};
			
			vertex.NameVertex = vertex.Model.Id.ToString();
			vertex.MouseMove += OnMouseMove;
			Canvas.SetLeft(vertex, Mouse.GetPosition(this).X);
			Canvas.SetTop(vertex, Mouse.GetPosition(this).Y);
			Canvas.Children.Add(vertex);
		}
		
		void OnMouseMove(object sender, MouseEventArgs e)
		{
			if (e.Source is Vertex vertex)
			{
				if (e.LeftButton == MouseButtonState.Pressed)
				{
					Point p = e.GetPosition(Canvas);
					Canvas.SetLeft(vertex, p.X - vertex.ActualWidth / 2);
					Canvas.SetTop(vertex, p.Y - vertex.ActualHeight / 2);
					vertex.CaptureMouse();
				}
				else
					vertex.ReleaseMouseCapture();
			}
		}
	}
}

