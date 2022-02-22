using GraphLib.Commands.VertexCommands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using Point = System.Drawing.Point;

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

		public Vertex Instance { get => this; }

		public Graph Graph { get; set; }
		public int Id;
		public Point Point
		{
			get => _point;
			set
			{
				_point = value;
				OnPropertyChanged();
			}
		}

		public DeleteVertex DeleteVertexCommand { get; private set; }

		public AddEdge AddEdgeCommand { get; private set; }

		private ObservableCollection<Edge> _edges = new ObservableCollection<Edge>();

		public ObservableCollection<Edge> Edges { get => _edges; }

		public List<Vertex> GoingToVertexes
		{
			get
			{
				var list = new List<Vertex>();
				foreach (var edge in _edges)
					if(edge.StartVertex == this)
						list.Add(edge.EndVertex);
				return list;
			}
		}

		public Edge EdgeWithVertex(Vertex other, bool oriented = true) 
			//TODO List or Enumerate 
			//TODO oriented check
		{
			foreach (var edge in _edges)
				if(
					(!oriented && (edge.StartVertex == other || edge.EndVertex == other))
					|| (oriented && edge.EndVertex == other)
					)
					return edge;
			
			return null;
		}

		Random _random = new Random();
		private Point _point;

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
