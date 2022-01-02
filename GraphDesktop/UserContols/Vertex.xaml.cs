using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace GraphDesktop.UserContols
{
	public partial class Vertex : UserControl
	{
		public Vertex()
		{
			InitializeComponent();
		}

		public GraphLib.Vertex Model { get; set; }
		
		public string NameVertex { get; set; }
		
		private void Button_MouseEnter_1(object sender, MouseEventArgs e)
		{
			popup.IsOpen = !popup.IsOpen;
		}
	}
}


