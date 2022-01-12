using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
		Random _random = new Random();
		
		public int Weight { get; set; } = 1;

		internal Vertex(int id, Point point)
		{
			this.Id = id;
			this.Point = point;
			Name = Id.ToString();
		}

		public ObservableCollection<Edge> Edges
		{
			get => _edges;
		}

		public void AddEdge(Edge e)
		{
			_edges.Add(e);
		}

		public void Delete()
		{
			//TODO
		}
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
