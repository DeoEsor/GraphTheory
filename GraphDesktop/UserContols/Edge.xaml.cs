using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using GraphDesktop.Annotations;
using Point = System.Drawing.Point;
// ReSharper disable PossibleLossOfFraction

namespace GraphDesktop.UserContols
{
	public partial class Edge : UserControl, INotifyPropertyChanged
	{
		public bool isArc { get; set; } = false;
		public Visibility LineVisibility
		{
			get => _lineVisibility;
			set
			{
				_lineVisibility = value;
				OnPropertyChanged();
			}
		}
		public Visibility ArcVisibility
		{
			get => _arcVisibility;
			set
			{
				_arcVisibility = value;
				OnPropertyChanged();
			}
		}
		public Edge(GraphCanvas canvas, GraphLib.Edge edge )
		{
			GraphCanvas = canvas;
			Model = edge;
			
			if (Model.
				StartVertex.EdgesWithVertex(Model.EndVertex)
				.Where(edge => !edge.Equals(Model))
				.Any()
			)
			{
				LineVisibility = Visibility.Hidden;
				ArcVisibility = Visibility.Visible;
				isArc = true;
			}
			else
			{
				LineVisibility = Visibility.Visible;
				ArcVisibility = Visibility.Hidden;
			}
				
			
			InitializeComponent();
			Model.PropertyChanged += ModelOnPropertyChanged;
			
			ModelOnPropertyChanged(null, new PropertyChangedEventArgs(nameof(GraphLib.Edge.VertexOnPropertyChanged)));
			ModelOnPropertyChanged(null, new PropertyChangedEventArgs(nameof(GraphLib.Edge.IsDirected)));
			Model.OnDelete += () => canvas.Canvas.Children.Remove(this);
			OnPropertyChanged();
		}
		
		private void ModelOnPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == nameof(GraphLib.Edge.StartPoint) 
				||  e.PropertyName == nameof(GraphLib.Edge.EndPoint)
				|| e.PropertyName == nameof(GraphLib.Edge.VertexOnPropertyChanged))
			{
				if(isArc)
				{
					StartPointArc.StartPoint=  new System.Windows.Point( Model.StartVertex.Point.X + 25, Model.StartVertex.Point.Y + 50);
					EndPointArc.Point = new System.Windows.Point( Model.EndVertex.Point.X + 25, Model.EndVertex.Point.Y + 50);
					ArcVisibility = Visibility.Visible;
				}
				else
				{
					Line.X1 = Model.StartPoint.X + 25;
					Line.Y1 = Model.StartPoint.Y + 50;
					Line.X2 = Model.EndPoint.X + 25;
					Line.Y2 = Model.EndPoint.Y + 50;
				}
			}
			UpdateLayout();
			if (e.PropertyName == nameof(GraphLib.Edge.IsDirected))
				Line.StrokeStartLineCap = Model.IsDirected ? PenLineCap.Square : PenLineCap.Triangle ;
		}

		private GraphLib.Edge edge;

		public GraphLib.Edge Model 
		{
			get => edge;
			set
			{
				edge = value;
			}
		}

		private PointCollection Trianglepoints { get; set; } = null;

		public string EdgeName { get => Model.Name; set => Model.Name = value; }

		public GraphCanvas GraphCanvas;
		private Visibility _lineVisibility = Visibility.Visible;
		private Visibility _arcVisibility = Visibility.Visible;

		public void Delete(object sender, RoutedEventArgs routedEventArgs)
		{
			GraphCanvas.Canvas.Children.Remove(this);
			Model.Delete();
		}
		private void Line_OnMouseUp(object sender, MouseButtonEventArgs e)
		{
			GraphCanvas.Popup.IsOpen = false;
			popup.IsOpen = true;
		}
		public event PropertyChangedEventHandler PropertyChanged;
		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

