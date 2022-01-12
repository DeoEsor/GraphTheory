using System;
using System.Diagnostics;
using System.Windows;
using GraphDesktop.Windows;
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
	}
}
