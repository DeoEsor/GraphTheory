using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using GraphDesktop.UserContols;
using GraphDesktop.Windows;
using GraphLib;
using GraphLib.GraphTasks;
using Microsoft.Win32;
namespace GraphDesktop
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow
	{
		public MainWindow()
		{
			InitializeComponent();
		}


		void Tasks(object sender, RoutedEventArgs e)
		{
            try
            {
				System.Diagnostics.Process process = new System.Diagnostics.Process();
				string path = AppDomain.CurrentDomain.BaseDirectory+@"/Graphs-labs2019.pdf";
				Uri pdf = new Uri(path, UriKind.RelativeOrAbsolute);
				process.StartInfo.FileName = pdf.LocalPath;
				process.Start();
				process.WaitForExit();
			}
			catch (Exception)
            {
				MessageBox.Show("Could not open the file.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
			}
		}
		
		private void AboutAuthors(object sender, RoutedEventArgs e)
		{
			AboutAuthors aboutAuthors = new AboutAuthors();
			
			aboutAuthors.Show();
		}
		
		private void AboutProgramm(object sender, RoutedEventArgs e)
		{
			AboutProgram aboutProgram = new AboutProgram();
			
			aboutProgram.Show();
		}

		private void BFS(object sender, RoutedEventArgs e)
		{
			AlgorithPathResult aboutProgram = new AlgorithPathResult(GraphCanvas.Model);
			aboutProgram.Owner = this;
			
			aboutProgram.Show();
		}
		private void BFSSecond(object sender, RoutedEventArgs e)
		{
			throw new NotImplementedException();
		}
		private void DjkstraChosen(object sender, RoutedEventArgs e)
		{
			DijkstraUI aboutProgram = new DijkstraUI(GraphCanvas.Model);
			aboutProgram.Owner = this;
			
			aboutProgram.Show();
		}
		private void PngSave(object sender, RoutedEventArgs e)
		{
			var renderTargetBitmap = GetRenderTargetBitmapFromControl(GraphCanvas.Canvas);

			var encoder = new PngBitmapEncoder();
			encoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));

			var result = new BitmapImage();

			try
			{
				using (var fileStream = new FileStream(GraphCanvas.Model.Name + ".png", FileMode.Create))
				{
					encoder.Save(fileStream);
				}

				System.Diagnostics.Process.Start("explorer", Environment.CurrentDirectory);
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine($"There was an error saving the file: {ex.Message}");
			}
		}
		void MatrixSave()
		{
			string dir;
			dir = 
				GraphCanvas.Model.MatrixT == Graph.MatrixType.Incidence ?
				@"Сохраненные ицидентные матрицы" : 
				@"Сохраненные смежные матрицы";
			if (!Directory.Exists(dir))
				Directory.CreateDirectory(dir);

			using (StreamWriter swExtLogFile = new StreamWriter(dir + @"/"+ GraphCanvas.Model.Name + ".txt", true))
			{
				var dt = GraphCanvas.UpdateDataTaMatrix(GraphCanvas.Model.GetMatrix());

				foreach (DataRow row in dt.Rows)
				{
					object[] array = row.ItemArray;
					for (int i = 0; i < array.Length - 1; i++)
						swExtLogFile.Write(array[i].ToString() + " | ");

					swExtLogFile.WriteLine(array[array.Length - 1].ToString());
				}
			}
			System.Diagnostics.Process.Start("explorer", Environment.CurrentDirectory);
		}
		
		private void SaveIncMatrix(object sender, RoutedEventArgs e)
		{
			GraphCanvas.Model.MatrixT = Graph.MatrixType.Incidence;
			MatrixSave();
		}
		private void SaveAdjMatrix(object sender, RoutedEventArgs e)
		{
			GraphCanvas.Model.MatrixT = Graph.MatrixType.Adjacency;
			MatrixSave();
		}
		
		private static BitmapSource GetRenderTargetBitmapFromControl(Visual targetControl, double dpi = 96.0)
		{
			if (targetControl == null) return null;

			var bounds = VisualTreeHelper.GetDescendantBounds(targetControl);
			var renderTargetBitmap = new RenderTargetBitmap((int)(bounds.Width * dpi / 96.0),
				(int)(bounds.Height * dpi / 96.0),
				dpi,
				dpi,
				PixelFormats.Pbgra32);

			var drawingVisual = new DrawingVisual();

			using (var drawingContext = drawingVisual.RenderOpen())
			{
				var visualBrush = new VisualBrush(targetControl);
				drawingContext.DrawRectangle(visualBrush, null, new Rect(new Point(), bounds.Size));
			}

			renderTargetBitmap.Render(drawingVisual);
			return renderTargetBitmap;
		}
		private void UndoAction(object sender, RoutedEventArgs e)
		{
			
		}
		private void RedoAction(object sender, RoutedEventArgs e)
		{
			
		}
	}
}
