using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
// ReSharper disable NonReadonlyMemberInGetHashCode
// ReSharper disable InconsistentNaming
namespace GraphLib
{
	public abstract class EdgeBase : INotifyPropertyChanged, IStartEndVertexHolder, IEquatable<EdgeBase>, IComparable
	{
		internal int Id;
		private string name;
		public Action OnDelete;
		private double _weight = 1;
		private Vertex _startVertex;
		private Vertex _endVertex;
		private bool _isDirected = true;
		public virtual event PropertyChangedEventHandler PropertyChanged;
		public System.Windows.Point EndPoint => EndVertex.Point;
		public System.Windows.Point StartPoint => StartVertex.Point;
		
		public string Name
		{
			get => name;
			set
			{
				name = value;
				OnPropertyChanged();
			}
		}
		
		public double Weight
		{
			get => _weight;
			set
			{
				_weight = value;
				OnPropertyChanged();
			}
		}
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

		public bool IsDirected
		{
			get => _isDirected;
			set
			{
				_isDirected = value;
				OnPropertyChanged();
			}
		}
		
		public void VertexOnPropertyChanged(object sender, PropertyChangedEventArgs e)
			=> OnPropertyChanged();
		private void OnPropertyChanged([CallerMemberName] string propertyName = null)
			=> PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		
		public static bool operator >(EdgeBase first, EdgeBase other) => first.Weight > other.Weight;
		public static bool operator<(EdgeBase first, EdgeBase other) => first.Weight < other.Weight;
		public static bool operator==(EdgeBase first, EdgeBase other) => first?.Id == other?.Id;
		public static bool operator !=(EdgeBase first, EdgeBase other) => first?.Id != other?.Id;
		
		public bool Equals(EdgeBase other)
			=> 
				Id == other?.Id
				&& name == other.name
				&& _weight.Equals(other._weight)
				&& Equals(_startVertex, other._startVertex)
				&& Equals(_endVertex, other._endVertex);
		
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj) || obj.GetType() != this.GetType())
				return false;
			if (ReferenceEquals(this, obj))
				return true;
			return Equals((EdgeBase)obj);
		}
		
		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = Id;
				hashCode = (hashCode * 397) ^ (name != null ? name.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ _weight.GetHashCode();
				hashCode = (hashCode * 397) ^ (_startVertex != null ? _startVertex.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (_endVertex != null ? _endVertex.GetHashCode() : 0);
				return hashCode;
			}
		}
		public int CompareTo(object obj)
		{
			if (Equals(obj)) return 0;
			
			if (ReferenceEquals(null, obj) || obj.GetType() != this.GetType())
				return int.MinValue;
			if (ReferenceEquals(this, obj))
				return 0;

			return this.GetHashCode() - obj.GetHashCode();
		}
	}
}
