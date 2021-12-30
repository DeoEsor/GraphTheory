using System.Windows;
using System.Xml.Linq;

namespace GraphDesktop.Windows
{
	public partial class Tasks : Window
	{
		public Tasks()
		{
			InitializeComponent();
			
			
		}
		private void PdfViewerControl_OnLoaded(object sender, RoutedEventArgs e)
		{
			PdfViewerControl.Load(@"../Graphs-labs2019.pdf");
		}
	}
}

