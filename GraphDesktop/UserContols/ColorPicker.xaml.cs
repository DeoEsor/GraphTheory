using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GraphDesktop.UserContols
{
	public partial class ColorPicker : UserControl
	{
		private Brush chosenColor;

		public Action OnChosenColorChanged;
		
		public Brush ChosenColor
		{
			get => chosenColor;
			set
			{
				chosenColor = value;
				OnChosenColorChanged?.Invoke();
			}
		}
		
		public ColorPicker()
		{
			InitializeComponent();
		}

		private void ColorsOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			if(!( sender is Button but)) return;

			but.Click += ButtonBase_Onclick;
		}
		
		private void ButtonBase_Onclick(object sender, RoutedEventArgs e)
		{
			if(!( sender is Button but) || !(but.Background is SolidColorBrush solidColorBrush)) return;

			ChosenColor = solidColorBrush;
		}
	}
}

