using System;
using System.ComponentModel;
using System.Drawing;
using System.Dynamic;
using System.Runtime.CompilerServices;
namespace GraphLib
{
	/// <summary>
	/// Ребер
	/// </summary>
	public class Edge : INotifyPropertyChanged
	{
		#region Properties & Variables
		public int Id;

		public string name;

		public double Weight
		{
			get => _weight;
			set
			{
				_weight = value;
				OnPropertyChanged();
			}
		}

		public string EdgeName
		{
			get => name;
			set
			{
				name = value;
				OnPropertyChanged();
			}
		}

		public Point EndPoint => EndVertex.Point;

		public bool IsDirected { get; set; }
		/// <summary>
		/// V1 - out vertex (from)
		/// V2 - in Vertex (to)
		/// </summary>
		public Vertex StartVertex
		{
			get => _startVertex;
			set
			{
				if (_startVertex != null)
					_startVertex.PropertyChanged -= VertexOnPropertyChanged;
				_startVertex = value;
				_startVertex.PropertyChanged += VertexOnPropertyChanged;
				OnPropertyChanged();
			}
		}
		public Vertex EndVertex
		{
			get => _endVertex;
			set
			{
				if (_endVertex != null)
					_endVertex.PropertyChanged -= VertexOnPropertyChanged;
				_endVertex = value;
				_endVertex.PropertyChanged += VertexOnPropertyChanged;
				OnPropertyChanged();
			}
		}
		public void VertexOnPropertyChanged(object sender, PropertyChangedEventArgs e)
			=> OnPropertyChanged();

		public Point StartPoint => StartVertex.Point;

		#endregion

		public Action OnDelete;
		private double _weight = 1;
		private bool _isDirected;
		private Vertex _startVertex;
		private Vertex _endVertex;

		internal Edge(int id, Vertex v1, Vertex v2 = null)
		{
			this.Id = id;
			this.StartVertex = v1;
			this.EndVertex = v2;
			EdgeName = Id.ToString();
		}

		public bool IsIn(Vertex sender) => sender == EndVertex;

		public void Delete()
		{
			StartVertex?.Edges.Remove(this);
			EndVertex?.Edges.Remove(this);
			OnDelete?.Invoke();
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
