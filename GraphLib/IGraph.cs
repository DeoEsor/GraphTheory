using System.Collections.ObjectModel;

namespace GraphLib
{
    public interface IGraph
    {
        ObservableCollection<Edge> Edges { get; }
        string Name { get; set; }
        ObservableCollection<Vertex> Vertices { get; }
    }
}