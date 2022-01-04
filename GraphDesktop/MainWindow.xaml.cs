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
			Tasks tasksWindow = new Tasks();

			tasksWindow.Show();
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
