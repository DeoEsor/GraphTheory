using GraphLib.Commands.VertexCommands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using GraphLib.GraphTasks;
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

		public GraphBase Graph { get; set; }
		public int Id;
		public System.Windows.Point Point
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
		
		public List<Vertex> AchievableVertexes
		{
			get{
				var list = new List<Vertex>();
				foreach (var edge in _edges)
				{
					if (edge.StartVertex == this && edge.EndVertex != this)
						list.Add(edge.EndVertex);
				}
				return list;
			}
		}
		

		public Edge EdgeWithVertex(Vertex other)
		{
			var result = new List<Edge>();
			foreach (var edge in _edges)
				if(edge.StartVertex == this && edge.EndVertex == other)
					result.Add(edge);
			
			return result.Min();
		}

		Random _random = new Random();
		private System.Windows.Point _point;

		public int Weight => this.VertexWeight();
		

		#endregion


		internal Vertex(GraphBase graph ,int id, System.Windows.Point point)
		{
			this.Graph = graph;
			this.Id = id;
			this.Point = point;
            Name = Id.ToString();

			DeleteVertexCommand = new DeleteVertex(Graph as Graph, this);
			AddEdgeCommand= new AddEdge(Graph as Graph, this);

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
