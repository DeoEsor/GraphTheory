using System;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace GraphDesktop.UserContols
{
	public partial class Vertex : UserControl
	{
		private GraphCanvas owner;
		public GraphCanvas GraphCanvas 
		{
			get => owner;
			set
            {
				owner = value;
				Edges = new UIElementCollection(owner, this);
			}
		}

		~Vertex()
        {
			//TODO
        }
		public Vertex()
		{
			InitializeComponent();
			ColorPicker.OnChosenColorChanged += () => Button.Background = ColorPicker.ChosenColor;
		}
#nullable enable 
		public static Popup? OpenedPopup { get; set; }= null;
#nullable disable
		Point _mouselastpos;

		public GraphLib.Vertex Model { get; set; }

		public UIElementCollection Edges { get; set; }

		public string NameVertex { get => Model.Id.ToString(); set => Model.Name = value; }

		#region Popup logic

		private void PopupOpen(object sender, RoutedEventArgs e)
		{
			if (popup.IsOpen)
				//popup redraw
				popup.IsOpen = false;
			popup.IsOpen = true;
			OpenedPopup = popup;
		}

		public static void PopupClose()
		{
			if (OpenedPopup != null)
				OpenedPopup.IsOpen = false;
		}

		public void Delete()
		{
			GraphCanvas.Model.Vertices.Remove(Model);
			GraphCanvas.Canvas.Children.Remove(this);
			foreach (var edge in Edges)
			{
				
			}
		}
		
		private void Popup_OnLostFocus(object sender, RoutedEventArgs e) => OpenedPopup = null;
  #endregion
		private void Popup_OnGotFocus(object sender, RoutedEventArgs e)
		{
			//TODO
		}
		private void AddEdge(object sender, RoutedEventArgs e)
		{
			//TODO
		}
		private void DeleteEdge(object sender, RoutedEventArgs e)
		{
			if (EdgesListBox.SelectedItem == null )
			{
				MessageBox.Show("Выберите ребра", "Ошибка удаления ребра", MessageBoxButton.OK, MessageBoxImage.Information);
				return;
			}

			var selectedItem = EdgesListBox.SelectedItem as Edge;
			owner.Canvas.Children.Remove(selectedItem);
			Model.Edges.Remove(selectedItem.Model); //TODO UID implementation

		}
		private void Delete(object sender, RoutedEventArgs e)
		{
			owner.Canvas.Children.Remove(this);

			//TODO owner.Model.Vertices.Remove();
		}
	}
}


