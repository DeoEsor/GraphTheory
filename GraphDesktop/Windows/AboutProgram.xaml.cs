using System.Windows;

namespace GraphDesktop.Windows
{
	public partial class AboutProgram : Window
	{
		public AboutProgram()
		{
			InitializeComponent();
		}

        private void Close(object sender, RoutedEventArgs e) => this.Close();
    }
}

