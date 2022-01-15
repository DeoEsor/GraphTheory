using GraphLib.Commands.VertexCommands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Input;

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

		public Vertex Instance {get => this; }

		public Graph Graph { get; set; }
		public int Id;
		public Point Point { get; set; }

		public DeleteVertex DeleteVertexCommand { get; private set; }

		public AddEdge AddEdgeCommand { get; private set; }

		private ObservableCollection<Edge> _edges = new ObservableCollection<Edge>();

		public ObservableCollection<Edge> Edges {get => _edges;}

		Random _random = new Random();

		public int Weight { get; set; } = 1;
		#endregion


		internal Vertex(Graph graph ,int id, Point point)
		{
			this.Graph = graph;
			this.Id = id;
			this.Point = point;
            Name = Id.ToString();

			DeleteVertexCommand = new DeleteVertex(Graph, this);
			AddEdgeCommand= new AddEdge(Graph, this);

			_edges.CollectionChanged += EdgesOnCollectionChanged;
		}

		private void EdgesOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			OnPropertyChanged();
		}

		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
