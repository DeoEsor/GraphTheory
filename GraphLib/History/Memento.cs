using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLib
{
    public class MementoGraph : IGraph
    {
        private Graph state;
        public Graph State
        {
            get => state;
            set => state = value;
        }

        public ObservableCollection<Edge> Edges => state.Edges;

        public string Name { get;  set; }

        public ObservableCollection<Vertex> Vertices => state.Vertices;

        public MementoGraph(Graph state){ this.State = state; }
    }
}
