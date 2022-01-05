using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using GraphLib;

namespace GraphDesktop.UserContols
{
	public partial class GraphCanvas : UserControl
	{
		public GraphLib.Graph Model { get; set; }= new Graph();

		Point mouselastpos;
		
		public GraphCanvas()
		{
			InitializeComponent();
		}

		private void UIElement_OnMouseUp(object sender, MouseButtonEventArgs e)
		{
			mouselastpos = e.GetPosition(Canvas);
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


		public void AddElement(object sender, RoutedEventArgs e)
		{
			Popup.IsOpen = false;
			Vertex vertex = new Vertex
			{
				Height = 50,
				Width = 50,
				Model = Model.CreateVertex((int)Mouse.GetPosition(Canvas).X, 
											(int)Mouse.GetPosition(Canvas).Y)
			};
			vertex.EdgesListBox.ItemsSource = vertex.Model.Edges;
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

