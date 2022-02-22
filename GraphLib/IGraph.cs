using System.Collections.ObjectModel;

namespace GraphLib
{
    public interface IGraph
    {
        string Name { get; set; }
        ObservableCollection<Edge> Edges { get; }
        ObservableCollection<Vertex> Vertices { get; }
    }
    
    public interface IGraph<T>
    {
        string Name { get; set; }
        ObservableCollection<IEdge<IVertex<T>>> Edges { get; }
        ObservableCollection<IVertex<T>> Vertices { get; }
    }
    
    public interface IVertex<T>
    {}
    
    public interface IEdge<T>
    {}
}