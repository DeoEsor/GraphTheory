using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GraphLib;

namespace GraphDesktop.UserContols
{
    public partial class GraphCanvas : UserControl, INotifyPropertyChanged
	{
		#region Variables && Properties

		public bool IsDragging { get; set; }= false;

		private Point lastPosition;
		public Graph Model { get; set; } = new Graph();


		//its mb optimized, but i'm too lazy for it
		private int[,] _matrix = new int[0,0];
		public int[,] Matrix
		{
			get { return _matrix; }
			set { _matrix = value; }
		}

		public UserControl draggedItem;
  #endregion

		public GraphCanvas()
		{
			InitializeComponent();
			GraphLib.DrawGraph.Graph = Model;
		}
		
		/// <summary>
		/// Popup window show
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
		{
            Vertex.PopupClose();

			draggedItem = null;

			if (!Popup.IsOpen)
				Popup.IsOpen = false;
			Popup.IsOpen = true;
		}

		#region Button events
		
		public void Clear(object sender, RoutedEventArgs e)
		{
			Popup.IsOpen = false;
			Canvas.Children.Clear();
			
			Model.ClearGraph();
		}
		
		public void AddElement(object sender, RoutedEventArgs e)
		{
			Popup.IsOpen = false;

			var vertex = CreateVertex();

			Canvas.SetLeft(vertex, Mouse.GetPosition(this).X);
			Canvas.SetTop(vertex, Mouse.GetPosition(this).Y);
			Canvas.Children.Add(vertex);
		}
  #endregion

		#region Drag logic
		public void btn_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			if (sender is Vertex vertex)
			{
				if (draggedItem is Edge edge)
				{
					edge.Model.EndVertex = vertex.Model;
					vertex.Model.Edges.Add(edge.Model);
					draggedItem = null;
					IsDragging = false;
				}
				
				else
				{
					IsDragging = true;
					draggedItem = vertex;
					lastPosition = e.GetPosition(Canvas);
				}
			}
		}

		private void btn_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			if (!IsDragging)
				return;

			IsDragging = false;
			draggedItem = null;
		}

		public void btn_PreviewMouseMove(object sender, MouseEventArgs e)
		{

			if (!IsDragging) return;

			if (Mouse.LeftButton == MouseButtonState.Released)
			{
				btn_PreviewMouseLeftButtonUp(sender, null);
				return;
			}
			
			var point = e.GetPosition(Canvas);

			if (draggedItem is Edge edge)
			{
				edge.Model.EndPoint = new System.Drawing.Point(((int)point.X), ((int)point.Y)); ;
				return;
			}

			if (draggedItem is Vertex vertex && !vertex.popup.IsOpen )
			{
				Canvas.SetTop(draggedItem, point.Y - draggedItem.Height / 2);
				Canvas.SetLeft(draggedItem, point.X - draggedItem.Width / 2);	
			}

		}
  #endregion

		#region Local Functions

		Vertex CreateVertex()
		{

			Vertex vertex1 = new Vertex
			{
				Height = 50,
				Width = 50,
				Model = Model.CreateVertex((int)Mouse.GetPosition(Canvas).X,
					(int)Mouse.GetPosition(Canvas).Y),
				GraphCanvas = this
			};
			vertex1.EdgesListBox.ItemsSource = vertex1.Model.Edges;
			vertex1.NameVertex = vertex1.Model.Id.ToString();

			vertex1.PreviewMouseLeftButtonUp += btn_PreviewMouseLeftButtonUp;
			vertex1.PreviewMouseLeftButtonDown += btn_PreviewMouseLeftButtonDown;
			vertex1.PreviewMouseMove += btn_PreviewMouseMove;
			return vertex1;
		}
        #endregion

        private void MatrixChoice_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (MatrixChoice.SelectedIndex == 0)
				Model.MatrixT = Graph.MatrixType.Incidence;
			else
				Model.MatrixT = Graph.MatrixType.Adjacency;
			Model.GetMatrix(Matrix);
		}

		public event PropertyChangedEventHandler PropertyChanged;

		void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

