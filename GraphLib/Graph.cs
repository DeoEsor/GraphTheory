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

    public class Graph : GraphBase
    {
        
        public bool IsOriented { get => Edges.Where(edge => edge.IsDirected).Count() != 0; }
        public Caretaker Caretaker { get; set; } = new Caretaker();

        #region Enums
        #endregion

        #region Variables & Properties
        private Graph(Graph graph)
        {
            this.Name = graph.Name;
            //TODO
        }
        
        private Graph(string name, params object[] theredata)//TODO
        {
            
        }

        public Graph() {}
        #endregion

        #region Methods
        /// <summary>
        /// заполняет матрицу смежности
        /// </summary>
        /// <param name="numberV"></param>
        /// <param name="e"></param>
        /// <param name="matrix"></param>
        public override Dictionary<Vertex, Dictionary<Vertex, double>> FillAdjacencyMatrix()
        {
            var matrix = new Dictionary<Vertex, Dictionary<Vertex, double>>();
            foreach (var vertex in Vertices)
            {
                var addmatrix = new Dictionary<Vertex, double>();
                foreach (var to in vertex.AchievableVertexes)
                    if (!addmatrix.ContainsKey(to) && vertex.EdgeWithVertex(to) != null)
                        addmatrix.Add(to, vertex.EdgeWithVertex(to).Weight);
                    
                
                foreach (var somevertex in Vertices)
                {
                    if (somevertex == vertex)
                    {
                        addmatrix.Add(somevertex, 0);
                        continue;
                    }

                    if (!addmatrix.ContainsKey(somevertex))
                        addmatrix.Add(somevertex, double.PositiveInfinity);
                }
                matrix.Add(vertex, addmatrix);
            }
            return matrix;
        }
        
        /// <summary>
        /// заполняет матрицу смежности
        /// </summary>
        /// <param name="numberV"></param>
        /// <param name="e"></param>
        /// <param name="matrix"></param>
        public override Dictionary<Vertex, List<Vertex>> ReturnAdjacencyList()
        {
            var matrix = new Dictionary<Vertex, List<Vertex>>();
            foreach (var vertex in Vertices)
                matrix.Add(vertex, vertex.AchievableVertexes);

            return matrix;
        }

        /// <summary>
        /// заполняет матрицу инцидентности
        /// </summary>
        /// <param name="numberV"></param>
        /// <param name="e"></param>
        /// <param name="matrix"></param>
        public override void FillIncidenceMatrix(out int[,] matrix)
        {
            matrix = new int[Vertices.Count, Edges.Count];

            for (var i = 0; i < Edges.Count; i++)
            {
                matrix[Edges[i].StartVertex.Id, i] = 1;
                matrix[Edges[i].EndVertex.Id  , i] = 1;
            }
        }
        #endregion

        public override object Clone()
        {
            return new Graph(this);
        }

        public Vertex FindVertexByID(int id)
        {
            foreach (var vertex in Vertices)
                if (vertex.Id == id)
                    return vertex;
            return null;
        }

        public List<List<int>> AdjencyMatrix()
        {
            var res = new List<List<int>>();
            var adj = FillAdjacencyMatrix();
            foreach (var i in Vertices)
            {
                var b = new List<int>();
                foreach (var j in Vertices)
                    b.Add(double.IsPositiveInfinity(adj[i][j]) ? 0 : 1);
                res.Add(b);
            }
            return res;
        }
    }
}
