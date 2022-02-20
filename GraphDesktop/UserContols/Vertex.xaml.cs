using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using GraphLib;

namespace GraphDesktop.UserContols
{
	public partial class Vertex : UserControl, INotifyPropertyChanged
	{
		private GraphCanvas owner;

        public event PropertyChangedEventHandler PropertyChanged;

        public GraphCanvas GraphCanvas 
		{
			get => owner;
			set
            {
				owner = value;
				Edges = new UIElementCollection(owner, this);
			}
		}

		public Vertex()
		{
			InitializeComponent();
			ColorPicker.OnChosenColorChanged += () => Button.Background = ColorPicker.ChosenColor;
			
		}
		
		
		
#nullable enable 
		public static Popup? OpenedPopup { get; set; }= null;
#nullable disable

		public GraphLib.Vertex Model { get; set; }

		public UIElementCollection Edges { get; set; }

		public string NameVertex { 
			get => Model?.Name.ToString();
			set
			{
				Model.Name = value;
				Button.Content = Model.Name;	
			}
		}

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

		private void DeleteEdge(object sender, RoutedEventArgs e)
		{
			if (EdgesListBox.SelectedItem == null)
			{
				MessageBox.Show("Выберите ребра", "Ошибка удаления ребра", MessageBoxButton.OK, MessageBoxImage.Information);
				return;
			}

			var selectedItem = EdgesListBox.SelectedItem as GraphLib.Edge;
			selectedItem.Delete();

		}
		private void Delete(object sender, RoutedEventArgs e)
		{
			owner.Canvas.Children.Remove(this);

			owner.Model.Vertices.Remove(Model);
		}

		#region Local func

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		#endregion

		private void OpenContext(object sender, RoutedEventArgs e)
		{
			ContextMenu.PlacementTarget = this;
			ContextMenu.IsOpen = true;
			popup.IsOpen = true;
		}
		
		private void MenuItem_OnClick(object sender, RoutedEventArgs e)
		{
			MenuItem menuItem = e.OriginalSource as MenuItem;
			GraphLib.Vertex vertex = menuItem.DataContext as GraphLib.Vertex;
			Model.AddEdgeCommand.Execute(vertex);
		}
	}
}


