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

		public double Weight { get; set; } = 1;

		public string EdgeName
		{
			get => name;
			set
			{
				name = value;
				OnPropertyChanged();
			}
		}

		private Point endPoint;
		public Point EndPoint
		{
			get => endPoint;
			set
			{
				endPoint = value;
				OnPointsChanged();
			}
		}

		public bool IsDirected { get; set; }
		/// <summary>
		/// V1 - out vertex (from)
		/// V2 - in Vertex (to)
		/// </summary>
		public Vertex StartVertex { get; set; }
		public Vertex EndVertex { get; set; }

		public Point StartPoint { get => StartVertex.Point; }

		#endregion

		public Action OnPointsChanged;

		public Action OnDelete;

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
