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

    public class Graph : INotifyPropertyChanged, IGraph, ICloneable
    {
        public Caretaker Caretaker { get; set; } = new Caretaker();

        #region Enums
        public enum MatrixType : sbyte { Adjacency, Incidence }

        public enum GraphType : sbyte { Oriented, NonOriented }
        #endregion

        #region Variables & Properties

        public MatrixType MatrixT = MatrixType.Incidence;

        public string Name { get; set; } = "Unnamed";

        private int _edgeid = 0;

        private int _verticalid = 0;
        private Graph(Graph graph)
        {
            this.Name = graph.Name;
            //TODO
        }
        
        private Graph(string name, params object[] theredata)//TODO
        {
            
        }

        public ObservableCollection<Edge> Edges { get; internal set; } = new ObservableCollection<Edge>();

        public ObservableCollection<Vertex> Vertices { get; internal set; } = new ObservableCollection<Vertex>();
        #endregion

        #region Methods

        public int[,] GetMatrix()
        {
            int[,] matrix;
            switch (MatrixT)
            {
                case MatrixType.Adjacency:
                    FillAdjacencyMatrix(out matrix);
                    break;
                case MatrixType.Incidence:
                    FillIncidenceMatrix(out matrix);
                    break;
                default:
                    throw new NotImplementedException();
            }
            return matrix;
        }

        /// <summary>
        /// заполняет матрицу смежности
        /// </summary>
        /// <param name="numberV"></param>
        /// <param name="e"></param>
        /// <param name="matrix"></param>
        public void FillAdjacencyMatrix(out int[,] matrix)
        {
            matrix = new int[Vertices.Count, Vertices.Count];

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
        public void FillIncidenceMatrix(out int[,] matrix)
        {
            matrix = new int[Vertices.Count, Edges.Count];

            for (var i = 0; i < Edges.Count; i++)
            {
                matrix[Edges[i].StartVertex.Id, i] = 1;
                matrix[Edges[i].EndVertex.Id, i] = 1;
            }
        }

        public Vertex CreateVertex(int x, int y)
        {
            Vertex result;
            Vertices.Add(result = new Vertex(this, _verticalid++, new Point(x, y)));
            return result;
        }
        public Edge CreateEdge(Vertex x, Vertex y)
        {
            Edge res;
            Edges.Add(res = new Edge(_edgeid++, x, y));
            x.Edges.Add(res); y.Edges.Add(res);
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
        public object Clone()
        {
            return new Graph(this);
        }
    }
}
