using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace GraphLib
{
	public abstract class GraphBase : INotifyPropertyChanged, IGraph, ICloneable
	{
		public MatrixType MatrixT = MatrixType.Incidence;
		internal int _edgeid = 0;
		internal int _verticalid = 0;
		public enum MatrixType : sbyte { Adjacency, Incidence }
		public enum GraphType : sbyte { Oriented, NonOriented }
		public string Name { get; set; } = "Unnamed";
		public ObservableCollection<Edge> Edges { get; internal set; } = new ObservableCollection<Edge>();
		public ObservableCollection<Vertex> Vertices { get;  set; } = new ObservableCollection<Vertex>();
		public int[,] GetMatrix()
		{
			int[,] matrix;
			FillIncidenceMatrix(out matrix);
			return matrix;
		}
		/// <summary>
		/// заполняет матрицу смежности
		/// </summary>
		/// <param name="numberV"></param>
		/// <param name="e"></param>
		/// <param name="matrix"></param>
		public abstract Dictionary<Vertex, Dictionary<Vertex, double>> FillAdjacencyMatrix();
		/// <summary>
		/// заполняет матрицу смежности
		/// </summary>
		/// <param name="numberV"></param>
		/// <param name="e"></param>
		/// <param name="matrix"></param>
		public abstract Dictionary<Vertex, List<Vertex>> ReturnAdjacencyList();
		/// <summary>
		/// заполняет матрицу инцидентности
		/// </summary>
		/// <param name="numberV"></param>
		/// <param name="e"></param>
		/// <param name="matrix"></param>
		public abstract void FillIncidenceMatrix(out int[,] matrix);
		public Vertex CreateVertex(int x, int y)
		{
			Vertex result;
			Vertices.Add(result = new Vertex(this, _verticalid++, new System.Windows.Point(x, y)));
			result.PropertyChanged += PropertyChanged;
			OnPropertyChanged();
			return result;
		}
		public Vertex CreateVertex(Vertex a)
		{
			Vertices.Add( a );
			a.PropertyChanged += PropertyChanged;
			OnPropertyChanged();
			return a;
		}
		public Edge CreateEdge(Vertex x, Vertex y)
		{
			Edge res;
			Edges.Add(res = new Edge(_edgeid++, x, y));
			x.Edges.Add(res); 
			y.Edges.Add(res);
			res.PropertyChanged += PropertyChanged;;
			OnPropertyChanged();
			return res;
		}
		public void ClearGraph()
		{
			Edges.Clear();
			Vertices.Clear();
			_edgeid = 0;
			_verticalid = 0;
			OnPropertyChanged();
		}
		public virtual event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		public abstract object Clone();
	}
}
