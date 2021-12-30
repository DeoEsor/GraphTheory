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
	}
}
