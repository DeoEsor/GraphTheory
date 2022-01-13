using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GraphLib
{

	public sealed class Graph : INotifyPropertyChanged
	{
        #region Enums
        public enum MatrixType : sbyte { Adjacency, Incidence }

		public enum GraphType : sbyte { Oriented, NonOriented }
		#endregion

		#region Variables & Properties

		public MatrixType MatrixT;

		public string Name { get; set; } = "Unnamed";

		private int _edgeid = 0;

		private int _verticalid = 0;

		public ObservableCollection<Edge> Edges { get; internal set; } = new ObservableCollection<Edge>();

		public ObservableCollection<Vertex> Vertices { get; internal set; } = new ObservableCollection<Vertex>();
		#endregion

		#region Methods

		public void GetMatrix(int[,] matrix)
		{
			switch (MatrixT)
			{
				case MatrixType.Adjacency:
					FillAdjacencyMatrix(matrix);
					break;
				case MatrixType.Incidence:
					FillIncidenceMatrix(matrix);
					break;
			}
		}

		/// <summary>
		/// заполняет матрицу смежности
		/// </summary>
		/// <param name="numberV"></param>
		/// <param name="e"></param>
		/// <param name="matrix"></param>
		public void FillAdjacencyMatrix(int[,] matrix)
		{
			for (var i = 0; i < Vertices.Count; i++)
				for (var j = 0; j < Vertices.Count; j++)
					matrix[i, j] = 0;

			for (var i = 0; i < Edges.Count; i++)
			{
				matrix[Edges[i].StartVertex.Id, Edges[i].EndVertex.Id] = 1;
				matrix[Edges[i].EndVertex.Id, Edges[i].StartVertex.Id] = 1;
			}
		}

		/// <summary>
		/// заполняет матрицу инцидентности
		/// </summary>
		/// <param name="numberV"></param>
		/// <param name="e"></param>
		/// <param name="matrix"></param>
		public void FillIncidenceMatrix(int[,] matrix)
		{
			for (var i = 0; i < Vertices.Count; i++)
				for (var j = 0; j < Edges.Count; j++)
					matrix[i, j] = 0;

			for (var i = 0; i < Edges.Count; i++)
			{
				matrix[Edges[i].StartVertex.Id, i] = 1;
				matrix[Edges[i].EndVertex.Id, i] = 1;
			}
		}

		public Vertex CreateVertex(int x, int y)
		{
			Vertex result;
			Vertices.Add(result = new Vertex(_verticalid++, new Point(x, y)));
			return result;
		}
		public Edge CreateEdge(Vertex x, Vertex y)
		{
			Edge res;
			Edges.Add(res = new Edge(_edgeid++, x, y));
			return res;
		}

		public void ClearGraph()
		{
			Edges.Clear();
			Vertices.Clear();
			_edgeid = 0;
			_verticalid = 0;
		}
		#endregion

		public event PropertyChangedEventHandler PropertyChanged;

		void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
