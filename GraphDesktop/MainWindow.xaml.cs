using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
		
		private void UndoAction(object sender, RoutedEventArgs e)
		{
			
		}
		private void RedoAction(object sender, RoutedEventArgs e)
		{
			
		}

		#region Load and Save
		private static List<string> DataFromFile(string FilePath)
		{

			List<string> strings = new List<string>();
			using (StreamReader fileObj = new StreamReader(FilePath))
			{
				string s = fileObj.ReadLine();

				while (s != null)
				{
					strings.Add(s);
					s = fileObj.ReadLine();
				}
			}
			return strings;
		}
		
		private void AdjLoad(object sender, RoutedEventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			string FilePath;
			if (openFileDialog.ShowDialog() == true)
				FilePath = openFileDialog.FileName;
			else return;
			GraphCanvas.Model.ClearGraph();
			var strings = DataFromFile(FilePath);
			var b = strings[0].Split(' ', '|', '\n', '\t').Where(s => s!= String.Empty).ToArray();
			for (int i = 0; i < b.Length; i++)
				GraphCanvas.Model.CreateVertex
				(
					new Random().Next(20, 500),
					new Random().Next(20, 80)
				);
			foreach (var str in strings)
			{
				b = str.Split(' ', '|', '\n', '\t').Where(s => s!= String.Empty).ToArray();
				for (int i = 0; i < b.Length; i++)
				{
					int w;
					if ((w = Convert.ToInt32(b[i])) == 0) continue;
					var z =GraphCanvas.Model.CreateEdge(
						GraphCanvas.Model.Vertices[strings.IndexOf(str)],
						GraphCanvas.Model.Vertices[i]);
					z.Weight = (double)w;
				}
			}
		}

		private void IncLoad(object sender, RoutedEventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			string FilePath;
			if (openFileDialog.ShowDialog() == true)
				FilePath = openFileDialog.FileName;
			else return;
			var strings = DataFromFile(FilePath);
		}
		
		private void FileLoad(object sender, RoutedEventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			string FilePath;
			if (openFileDialog.ShowDialog() == true)
				FilePath = openFileDialog.FileName;
			else return;
			GraphCanvas.Model = CustomHolderFile.FileToGraph(DataFromFile(FilePath));
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
					encoder.Save(fileStream);

				Process.Start("explorer", Environment.CurrentDirectory);
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"There was an error saving the file: {ex.Message}");
			}
		}
		void SaveGraphFile( object sender, RoutedEventArgs e)
		{
			string dir;
			dir =  @"Граф в виде файла";
			if (!Directory.Exists(dir))
				Directory.CreateDirectory(dir);

			using (StreamWriter swExtLogFile = new StreamWriter(dir + @"/"+ GraphCanvas.Model.Name + ".txt", false))
			{
				var dt = CustomHolderFile.GraphToFile(GraphCanvas.Model);

				foreach (var row in dt)
					swExtLogFile.WriteLine(row);
			}
			Process.Start("explorer", Environment.CurrentDirectory);
		}
		
		void MatrixSave(GraphBase.MatrixType type)
		{
			string dir;
			dir = 
				type == GraphBase.MatrixType.Incidence ?
					@"Сохраненные ицидентные матрицы" : 
					@"Сохраненные смежные матрицы";
			if (!Directory.Exists(dir))
				Directory.CreateDirectory(dir);

			using (StreamWriter swExtLogFile = new StreamWriter(dir + @"/"+ GraphCanvas.Model.Name + ".txt", false))
			{
				var dt =
					type == GraphBase.MatrixType.Incidence ?
						GraphCanvas.UpdateIncDataTaMatrix(GraphCanvas.Model.GetMatrix()) : 
						GraphCanvas.UpdateAdjDataTaMatrix();

				foreach (DataRow row in dt.Rows)
				{
					object[] array = row.ItemArray;
					for (int i = 0; i < array.Length - 1; i++)
						swExtLogFile.Write(array[i].ToString() + " | ");

					swExtLogFile.WriteLine(array[array.Length - 1].ToString());
				}
			}
			Process.Start("explorer", Environment.CurrentDirectory);
		}
		
		private void SaveIncMatrix(object sender, RoutedEventArgs e)
			=> MatrixSave(GraphBase.MatrixType.Incidence);
		private void SaveAdjMatrix(object sender, RoutedEventArgs e)
			=> MatrixSave(GraphBase.MatrixType.Adjacency);
  #endregion
		
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
		private void DjkstraChosen(object sender, RoutedEventArgs e)
		{
			DijkstraUI aboutProgram = new DijkstraUI(GraphCanvas.Model);
			aboutProgram.Owner = this;
			
			aboutProgram.Show();
		}
		private void Coloring(object sender, RoutedEventArgs e)
		{
			Coloring aboutProgram = new Coloring(GraphCanvas.Model);
			aboutProgram.Owner = this;
			
			aboutProgram.Show();
		}
		private void CircleTask(object sender, RoutedEventArgs e)
		{
			Coloring aboutProgram = new Coloring(GraphCanvas.Model);
			aboutProgram.Owner = this;
			
			aboutProgram.Show();
		}
		private void AdjencyGraph(object sender, RoutedEventArgs e)
		{
			var aboutProgram = new AdjencyGraph(GraphCanvas.Model);
			aboutProgram.Owner = this;
			
			aboutProgram.Show();
		}
		private void Kruskal(object sender, RoutedEventArgs e)
		{
			Kruskal aboutProgram = new Kruskal(GraphCanvas.Model);
			aboutProgram.Owner = this;
			
			aboutProgram.Show();
		}
		private void Isomorph(object sender, RoutedEventArgs e)
		{
			Isomorphism aboutProgram = new Isomorphism(GraphCanvas.Model);
			aboutProgram.Owner = this;
			
			aboutProgram.Show();
		}
		private void Linking(object sender, RoutedEventArgs e)
		{
			Linking aboutProgram = new Linking(GraphCanvas.Model);
			aboutProgram.Owner = this;
			
			aboutProgram.Show();
		}
	}
}
