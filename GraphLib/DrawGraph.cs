using System.Drawing;
namespace GraphLib
{
	/// <summary>
	/// Probably move to VE
	/// </summary>
	public static class DrawGraph
	{
		#region Variables

		private static Graph _graph;
		private static Bitmap _bitmap;
		private static Pen _blackPen = new Pen(Color.Black);
		private static Pen _redPen = new Pen(Color.Red);
		private static Pen _darkGoldPen = new Pen(Color.DarkGoldenrod);
		private static Graphics _gr;
		private static Font _fo = new Font("Arial", 15);
		private static Brush _br = Brushes.Black;
		private static PointF _point;
		public static int R = 20; //радиус окружности вершины
  #endregion

		#region Properties
		public static Bitmap Bitmap
		{
			get => _bitmap;
			set
			{
				_bitmap = value;	
				_gr = Graphics.FromImage(_bitmap);
			}
		}
  #endregion

		#region Constructor
		static DrawGraph()
		{
			_bitmap = new Bitmap(100, 100);
			_gr = Graphics.FromImage(_bitmap);
			СlearSheet();
			_blackPen.Width = 2;
			_redPen.Width = 2;
			_darkGoldPen.Width = 2;
		}
  #endregion

		public static void СlearSheet() =>  _gr.Clear(Color.White);

		public static void DrawVertex(int x, int y, string number)
		{
			_gr.FillEllipse(Brushes.White, x - R, y - R, 2 * R, 2 * R);
			_gr.DrawEllipse(_blackPen, x - R, y - R, 2 * R, 2 * R);
			_point = new PointF(x - 9, y - 9);
			_gr.DrawString(number, _fo, _br, _point);
		}

		public static void DrawSelectedVertex(int x, int y) =>  _gr.DrawEllipse(_redPen, x - R, y - R, 2 * R, 2 * R);


		public static void drawEdge(Vertex V1, Vertex V2, Edge E, int numberE)
		{
			if (E.StartVertex.Id == E.EndVertex.Id)
			{
				_gr.DrawArc(_darkGoldPen, V1.Point.X - 2 * R, V1.Point.Y - 2 * R, 2 * R, 2 * R, 90, 270);
				_point = new PointF(V1.Point.X - (int)(2.75 * R), V1.Point.Y - (int)(2.75 * R));
				_gr.DrawString(((char)('a' + numberE)).ToString(), _fo, _br, _point);

				DrawVertex(V1.Point.X, V1.Point.Y, (E.StartVertex.Id + 1).ToString());
			}
			else
			{
				_gr.DrawLine(_darkGoldPen, V1.Point.X, V1.Point.Y, V2.Point.X, V2.Point.Y);
				_point = new PointF((V1.Point.X + V2.Point.X) / 2, (V1.Point.Y + V2.Point.Y) / 2);
				_gr.DrawString(((char)('a' + numberE)).ToString(), _fo, _br, _point);
				DrawVertex(V1.Point.X, V1.Point.Y, (E.StartVertex.Id + 1).ToString());
				DrawVertex(V2.Point.X, V2.Point.Y, (E.EndVertex.Id + 1).ToString());
			}
		}

	}
}
