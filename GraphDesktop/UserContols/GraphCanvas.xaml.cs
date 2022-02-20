using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GraphLib;
// ReSharper disable HeapView.BoxingAllocation

namespace GraphDesktop.UserContols
{
    public partial class GraphCanvas : UserControl, INotifyPropertyChanged
	{
		#region Variables && Properties

		public bool IsDragging { get; set; }= false;

		private Point lastPosition;
		public Graph Model { get; set; } = new Graph();


        //its mb optimized, but i'm too lazy for it
        private object _matrix;
		public object Matrix
		{
			get =>_matrix;
			set 
			{ 
				_matrix = value;
				OnPropertyChanged();
			}
		}

		public UserControl draggedItem;
  #endregion

		public GraphCanvas()
		{
			InitializeComponent();
			GraphLib.DrawGraph.Graph = Model;
			Model.Edges.CollectionChanged += EdgesOnCollectionChanged;
		}
		private void EdgesOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			switch (e.Action)
			{
				case NotifyCollectionChangedAction.Add:
					if (e.NewItems[0] is GraphLib.Edge edgedata)
					{
						var edge = new Edge(this, edgedata);
						Canvas.Children.Add(edge);	
					}
					break;
				case NotifyCollectionChangedAction.Remove:
					break;
				case NotifyCollectionChangedAction.Replace:
					break;
				case NotifyCollectionChangedAction.Reset:
					break;
				case NotifyCollectionChangedAction.Move:
					break;
			}
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
			MatrixChoice_SelectionChanged(null, null);
			lastPosition = e.GetPosition(Canvas);
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

			if (!(draggedItem is Vertex vertex && !vertex.popup.IsOpen )) return;
			
			Canvas.SetTop(draggedItem, point.Y - draggedItem.Height / 2);
			Canvas.SetLeft(draggedItem, point.X - draggedItem.Width / 2);
			
			vertex.Model.Point = 
				new System.Drawing.Point( 
					(int) (point.X - draggedItem.Width / 2),
					(int)(point.Y - draggedItem.Height / 2)
					);
		}
  #endregion

		#region Local Functions

		Vertex CreateVertex()
		{
			var model = Model.CreateVertex(
				(int)(lastPosition.X   -  25), 
				(int) (lastPosition.Y  - 25)
				);

			Vertex vertex1 = new Vertex
			{
				Height = 50,
				Width = 50,
				Model = model,
				GraphCanvas = this,
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
			
			Model.MatrixT =
				MatrixChoice.SelectedIndex == 0 ? 
				Graph.MatrixType.Incidence :
				Model.MatrixT = Graph.MatrixType.Adjacency;
			
			UpdateMatrix(Model.GetMatrix());
		}

		void UpdateMatrix(int[,] matrix)
		{
			
			var dt = new DataTable();
			if (matrix.Length == 0)
			{
				this.Matrix = dt.DefaultView;	
				return;
			}
			int rows = matrix.GetUpperBound(0) + 1;    // количество строк
			int columns = matrix.Length / rows;

			for (var i = 0; i < columns; i++)
				dt.Columns.Add(new DataColumn("c" + i, typeof(int)));

			for (var i = 0; i < rows; i++)
			{
				var r = dt.NewRow();				
				for (var j = 0; j < columns; j++)
					r[j] = matrix[i,j];
				dt.Rows.Add(r);
			}
			this.Matrix = dt.DefaultView;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public void SetElementTop(UIElement element, int length)
			=> Canvas.SetTop(element, length);
		public void SetElementLeft(UIElement element, int length)
			=> Canvas.SetLeft(element, length);
	}
}

