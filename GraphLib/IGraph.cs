using System.Collections.ObjectModel;

namespace GraphLib
{
    public interface IGraph
    {
        string Name { get; set; }
        ObservableCollection<Edge> Edges { get; }
        ObservableCollection<Vertex> Vertices { get; }
    }
}