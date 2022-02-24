using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Point = System.Drawing.Point;
// ReSharper disable PossibleLossOfFraction

namespace GraphDesktop.UserContols
{
	public partial class Edge : UserControl
	{
		public Edge(GraphCanvas canvas, GraphLib.Edge edge )
		{
			GraphCanvas = canvas;
			Model = edge;
			
			
			
			/*if (Model.IsDirected)
				Trianglepoints = new PointCollection()
				{
					new System.Windows.Point
					(
						Model.EndPoint.X - 25,
						Model.EndPoint.Y - 15
					),
					Model.EndPoint,
					new System.Windows.Point
					(
							
						Model.EndPoint.X + 25,
						Model.EndPoint.Y + 15
					)
						
				};
				*/
			InitializeComponent();
			Model.PropertyChanged += ModelOnPropertyChanged;
			ModelOnPropertyChanged(null, new PropertyChangedEventArgs(nameof(GraphLib.Edge.VertexOnPropertyChanged)));
			Model.OnDelete += () => canvas.Canvas.Children.Remove(this);
		}
		
		private void ModelOnPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (!(e.PropertyName == nameof(GraphLib.Edge.StartPoint) 
				||  e.PropertyName == nameof(GraphLib.Edge.EndPoint)
				|| e.PropertyName == nameof(GraphLib.Edge.VertexOnPropertyChanged))) 
				return;
			Line.X1 = Model.StartPoint.X + 25;
			Line.Y1 = Model.StartPoint.Y + 50;
			Line.X2 = Model.EndPoint.X + 25;
			Line.Y2 = Model.EndPoint.Y + 50;
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

		public string EdgeName { get => Model.EdgeName; set => Model.EdgeName = value; }

		public GraphCanvas GraphCanvas;

		public void Delete()
		{
			GraphCanvas.Canvas.Children.Remove(this);
			Model.Delete();
		}
		private void Line_OnMouseUp(object sender, MouseButtonEventArgs e)
		{
			GraphCanvas.Popup.IsOpen = false;
			popup.IsOpen = true;
		}
	}
}

