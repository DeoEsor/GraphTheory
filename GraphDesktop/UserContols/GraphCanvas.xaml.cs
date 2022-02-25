using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using GraphLib;
using GraphLib.GraphTasks;
// ReSharper disable HeapView.BoxingAllocation

namespace GraphDesktop.UserContols
{
    public partial class GraphCanvas : UserControl, INotifyPropertyChanged
	{
		#region Variables && Properties
		public static  RoutedCommand ShowAdjgrid { get; set; } = new RoutedCommand();
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

		public object AdjMatix
		{
			get => _adjMatix;
			set
			{
				_adjMatix = value;
				OnPropertyChanged();
			}
		}

		public UserControl draggedItem;
		private object _adjMatix;
  #endregion

		public GraphCanvas()
		{
			ShowAdjgrid.InputGestures.Add(new KeyGesture(Key.N, ModifierKeys.Control));
			CommandBindings.Add(new CommandBinding(ShowAdjgrid, MyCommandExecuted));
			
			GraphLib.DrawGraph.Graph = Model;
			Model.Edges.CollectionChanged += EdgesOnCollectionChanged;
			Model.Vertices.CollectionChanged += VerticesOnCollectionChanged;
			
			InitializeComponent();
			
			Zoom();

			Model.PropertyChanged += (object o, PropertyChangedEventArgs args) => AdjMatix = UpdateAdjDataTaMatrix().DefaultView;
		}
		private void Zoom()
		{

			var st = new ScaleTransform();
			Canvas.RenderTransform = st;
			Canvas.MouseWheel += (sender, e) =>
			{
				if (e.Delta > 0)
				{
					st.ScaleX *= 1.2;
					st.ScaleY *= 1.2;
				}
				else
				{
					st.ScaleX /= 1.2;
					st.ScaleY /= 1.2;
				}
			};
		}
		private void VerticesOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			switch (e.Action)
			{
				case NotifyCollectionChangedAction.Add:
					if (e.NewItems[0] is GraphLib.Vertex vertex)
					{
						var edge = new Vertex(this, vertex);
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
			DiametrData.Text = Model.GraphDiametr().ToString();
			RadiusData.Text = Model.GraphRadius().ToString();
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
			vertex.Model.Point = new Point( Mouse.GetPosition(this).X, Mouse.GetPosition(this).Y);
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
				new System.Windows.Point( 
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
			=> Matrix = UpdateIncDataTaMatrix(Model.GetMatrix());

		public DataTable UpdateIncDataTaMatrix(int[,] matrix)
		{

			var dt = new DataTable();
			if (matrix.Length == 0)
			{
				this.Matrix = dt.DefaultView;
				return dt;
			}
			int rows = matrix.GetUpperBound(0) + 1;
			int columns = matrix.Length / rows;

			for (var i = 0; i < columns; i++)
				if(i < Model.Vertices.Count)
					dt.Columns.Add(new DataColumn(Model.Vertices[i].Name, typeof(int)));

			for (var i = 0; i < rows; i++)
			{
				var r = dt.NewRow();
				for (var j = 0; j < columns; j++)
					if(j < Model.Vertices.Count)
						r[j] = matrix[i, j];
				dt.Rows.Add(r);
			}

			
			return dt;
		}
		private void Grid1_LoadingRow(object sender, DataGridRowEventArgs e)
		{
			var id = e.Row.GetIndex();
			if(id < Model.Vertices.Count)
				e.Row.Header = Model.Vertices[id].Name;
		}

		public DataTable UpdateAdjDataTaMatrix()
		{
			var matrix = Model.FillAdjacencyMatrix();
			var dt = new DataTable();
			if (matrix.Count == 0)
			{
				this.Matrix = dt.DefaultView;	
				return dt;
			}
			int rows = matrix.Values.Count;
			int columns = matrix.Keys.Count;

			for (var i = 0; i < columns; i++)
				dt.Columns.Add(new DataColumn(Model.Vertices[i].Name, typeof(double)));

			foreach (var data in matrix)
			{
				var r = dt.NewRow();
				foreach (var a in data.Value)
				{
					r[Model.Vertices.IndexOf(a.Key)] = a.Value;
				}
				dt.Rows.Add(r);
			}
				
			
			return dt;
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
		private void MyCommandExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			MatrixAdjGrid.Visibility = MatrixAdjGrid.IsVisible ? Visibility.Hidden : Visibility.Visible;
			this.UpdateLayout();
		}
	}
}

