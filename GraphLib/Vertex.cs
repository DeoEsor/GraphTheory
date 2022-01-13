using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
namespace GraphLib
{
	/// <summary>
	/// Vertex representation
	/// Вершина
	/// </summary>
	public class Vertex : INotifyPropertyChanged
	{
		#region Variables & Properties
		private string name;
		public string Name
		{
			get => name;
			set
			{
				name = value;
				OnPropertyChanged();
			}
		}
		public int Id;
		public Point Point { get; set; }

		private ObservableCollection<Edge> _edges = new ObservableCollection<Edge>();

		public ObservableCollection<Edge> Edges
		{
			get => _edges;
		}

		Random _random = new Random();

		public int Weight { get; set; } = 1;
		#endregion


		internal Vertex(int id, Point point)
		{
			this.Id = id;
			this.Point = point;
			Name = Id.ToString();
			_edges.CollectionChanged += EdgesOnCollectionChanged;
		}
		private void EdgesOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			//TODO
		}

		public void Delete()
		{
			foreach(var edge in Edges)
				edge.Delete();


		}

		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
