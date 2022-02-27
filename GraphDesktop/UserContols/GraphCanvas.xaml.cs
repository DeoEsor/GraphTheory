using System;
using System.Collections.Generic;
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

		public Dictionary<GraphLib.Vertex, UIElement> Vertexes = new Dictionary<GraphLib.Vertex, UIElement>();
		public Dictionary<GraphLib.Edge, UIElement> Edges = new Dictionary<GraphLib.Edge, UIElement>();
		public bool IsDragging { get; set; }= false;

		private Point? lastPosition = null;
		private Point? popupopenpos = null;

		private Graph model = new Graph();
		
		public Graph Model
		{
			get => model;
			set
			{
				model.Edges.CollectionChanged -= EdgesOnCollectionChanged;
				model.Vertices.CollectionChanged -= VerticesOnCollectionChanged;
				model.PropertyChanged -= ModelOnPropertyChanged;
				model = value;
				model.Edges.CollectionChanged += EdgesOnCollectionChanged;
				model.Vertices.CollectionChanged += VerticesOnCollectionChanged;
				model.PropertyChanged += ModelOnPropertyChanged;
				var a = new List<GraphLib.Vertex>();
				var b = new List<GraphLib.Edge>();
				foreach (var vertex in model.Vertices)
					a.Add(vertex);
				Model.Vertices.Clear();
				foreach (var vertex in a)
					Model.Vertices.Add(vertex);

				foreach (var edge in model.Edges)
					b.Add(edge);
				Model.Edges.Clear();
				foreach (var edge in b)
					Model.Edges.Add(edge);
			}
		}
		
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

		public DataView AdjMatix
		{
			get => _adjMatix;
			set
			{
				_adjMatix = value;
				OnPropertyChanged();
			}
		}

		public UserControl draggedItem;
		private DataView _adjMatix;
  #endregion

		public GraphCanvas()
		{
			ShowAdjgrid.InputGestures.Add(new KeyGesture(Key.N, ModifierKeys.Control));
			CommandBindings.Add(new CommandBinding(ShowAdjgrid, MyCommandExecuted));

			Model.Edges.CollectionChanged += EdgesOnCollectionChanged;
			Model.Vertices.CollectionChanged += VerticesOnCollectionChanged;
			Model.PropertyChanged += ModelOnPropertyChanged;
			
			InitializeComponent();
			
			Zoom();
			
		}
		private void ModelOnPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			AdjMatix = UpdateAdjDataTaMatrix().DefaultView;
		}

		private void VerticesOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			switch (e.Action)
			{
				case NotifyCollectionChangedAction.Add:
					if (e.NewItems[0] is GraphLib.Vertex vertex)
					{
						var vertexui = new Vertex(this, vertex);
						double lengthx = 0, lengthy = 0;
						if (lastPosition != null)
						{
							lengthx= Mouse.GetPosition(this).X;
							lengthy = Mouse.GetPosition(this).Y;	
						}
						else
						{
							lengthx = vertex.Point.X;
							lengthy = vertex.Point.Y;
						}
						Canvas.SetTop(vertexui, lengthx);
						Canvas.SetLeft(vertexui, lengthy);
						if (!Vertexes.ContainsKey(vertex))
							Vertexes.Add(vertex, vertexui);
						else
						{
							Canvas.Children.Remove(Vertexes[vertex]);
							Vertexes[vertex] = vertexui;
						}
						vertexui.Height = 50;
						vertexui.Width = 50;
						Canvas.Children.Add(vertexui);
						vertexui.PreviewMouseLeftButtonUp += btn_PreviewMouseLeftButtonUp;
						vertexui.PreviewMouseLeftButtonDown += btn_PreviewMouseLeftButtonDown;
						vertexui.PreviewMouseMove += btn_PreviewMouseMove;
					}
					break;
				case NotifyCollectionChangedAction.Remove:
					if (e.OldItems[0] is GraphLib.Vertex vertexr)
					{
						if (Vertexes.ContainsKey(vertexr))
						{
							var a = Vertexes[vertexr];
							a.PreviewMouseLeftButtonUp -= btn_PreviewMouseLeftButtonUp;
							a.PreviewMouseLeftButtonDown -= btn_PreviewMouseLeftButtonDown;
							a.PreviewMouseMove -= btn_PreviewMouseMove;
							Vertexes[vertexr].Visibility = Visibility.Hidden;
							Canvas.Children.Remove(Vertexes[vertexr]);
							Vertexes.Remove(vertexr);
							UpdateLayout();
						}
					}
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
					if ( !(e.NewItems[0] is GraphLib.Edge edgedata)) return;
					var edge = new Edge(this, edgedata);
					if (!Edges.ContainsKey(edgedata))
						Edges.Add(edgedata, edge);
					else
					{
						Canvas.Children.Remove(Edges[edgedata]);
						Edges[edgedata] = edge;
					}
					Canvas.Children.Add(edge);
					break;
				case NotifyCollectionChangedAction.Remove:
					if ( !(e.OldItems[0] is GraphLib.Edge edger)) return;
					if (Edges.ContainsKey(edger))
					{
						Edges.Remove(edger);
						Canvas.Children.Remove(Edges[edger]);
					}
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
			lastPosition = Mouse.GetPosition(this);
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

			Model.CreateVertex((int)lastPosition.Value.X, (int)lastPosition.Value.Y);
		}
  #endregion

		#region Drag logic
		public void btn_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			if (!(sender is Vertex vertex)) return;
			
			IsDragging = true;
			draggedItem = vertex;
			lastPosition = e.GetPosition(Canvas);
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
				dt.Columns.Add(new DataColumn( Model.Vertices[i].Name, typeof(double)));

			foreach (var data in matrix)
			{
				var r = dt.NewRow();
				foreach (var a in data.Value)
					r[Model.Vertices.IndexOf(a.Key)] = double.IsPositiveInfinity(a.Value) ? 0 : a.Value;
				
				dt.Rows.Add(r);
			}
				
			
			return dt;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		void OnPropertyChanged([CallerMemberName] string propertyName = null)
			=> PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

		public void SetElementTop(UIElement element, int length)
			=> Canvas.SetTop(element, length);
		public void SetElementLeft(UIElement element, int length)
			=> Canvas.SetLeft(element, length);
		private void MyCommandExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			MatrixAdjGrid.Visibility = MatrixAdjGrid.IsVisible ? Visibility.Hidden : Visibility.Visible;
			this.UpdateLayout();
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
		private void MatrixAdjGrid_OnCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
		{
			GraphLib.Edge edge;
			if ((edge = Model
				.Vertices[MatrixAdjGrid.Items.IndexOf(MatrixAdjGrid.CurrentItem)].
				EdgeWithVertex(Model.Vertices[e.Column.DisplayIndex])) == null)
			{
				Model.CreateEdge(Model
					.Vertices[MatrixAdjGrid.Items.IndexOf(MatrixAdjGrid.CurrentItem)], Model.Vertices[e.Column.DisplayIndex])
					.Weight = Convert.ToDouble(((TextBox) e.EditingElement).Text);
			}
			else
				edge.Weight = Convert.ToDouble(((TextBox) e.EditingElement).Text);

		}
	}
}

