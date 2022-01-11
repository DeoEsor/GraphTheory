using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using GraphLib;

namespace GraphDesktop.UserContols
{
	public partial class GraphCanvas : UserControl
	{
		private bool IsDragging { get; set; }= false;

		private Point lastPosition;
		public GraphLib.Graph Model { get; set; } = new GraphLib.Graph();

		private UserControl draggedItem;

		public GraphCanvas()
		{
			InitializeComponent();
			ColorPicker.OnChosenColorChanged += () => Canvas.Background = ColorPicker.ChosenColor;
		}

		private void UIElement_OnMouseUp(object sender, MouseButtonEventArgs e)
		{
			Vertex.PopupClose();

			if (!Popup.IsOpen)
				//Redraw popup window
				Popup.IsOpen = false;
			Popup.IsOpen = true;
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
											(int)Mouse.GetPosition(Canvas).Y),
				GraphCanvas = this
			};
			vertex.EdgesListBox.ItemsSource = vertex.Model.Edges;
			vertex.NameVertex = vertex.Model.Id.ToString();

			vertex.PreviewMouseLeftButtonUp += btn_PreviewMouseLeftButtonUp;
			vertex.PreviewMouseLeftButtonDown += btn_PreviewMouseLeftButtonDown;
			vertex.PreviewMouseMove += btn_PreviewMouseMove;

			Canvas.SetLeft(vertex, Mouse.GetPosition(this).X);
			Canvas.SetTop(vertex, Mouse.GetPosition(this).Y);
			Canvas.Children.Add(vertex);
		}

		#region Drag logic

		private void btn_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			if ((sender is Vertex vertex))
			{
				IsDragging = true;
				draggedItem = vertex;
				lastPosition = e.GetPosition(Canvas);
			}
		}

		private void btn_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			if (!IsDragging)
				return;

			IsDragging = false;
		}

		private void btn_PreviewMouseMove(object sender, MouseEventArgs e)
		{
			if (!IsDragging) return;

			Point canvasRelativePosition = e.GetPosition(Canvas);

			Canvas.SetTop(draggedItem, canvasRelativePosition.Y - draggedItem.Height / 2);
			Canvas.SetLeft(draggedItem, canvasRelativePosition.X - draggedItem.Width / 2);
		}
  #endregion
		private void GraphCanvas_OnGotFocus(object sender, RoutedEventArgs e)
		{
			//throw new NotImplementedException();
		}
		private void GraphCanvas_OnLostFocus(object sender, RoutedEventArgs e)
		{
			//throw new NotImplementedException();
		}
	}
}

