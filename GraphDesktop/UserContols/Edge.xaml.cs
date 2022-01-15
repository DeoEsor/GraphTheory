using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GraphDesktop.UserContols
{
	public partial class Edge : UserControl
	{
		public Edge()
		{
			InitializeComponent();
		}

		private GraphLib.Edge edge;

		public GraphLib.Edge Model 
		{
			get => edge;
			set
			{
				edge = value;
				Model.OnPointsChanged += () =>
				{
					Figure.StartPoint = new Point(Model.StartPoint.X, Model.StartPoint.Y);
					ArcSegment.Point = new Point(Model.EndPoint.X, Model.EndPoint.Y);
				};
			}
		}

		public string EdgeName { get => Model.EdgeName; set => Model.EdgeName = value; }

		public GraphCanvas GraphCanvas;

		public void Delete()
		{
			GraphCanvas.Canvas.Children.Remove(this);
			Model.Delete();
		}
	}
}

