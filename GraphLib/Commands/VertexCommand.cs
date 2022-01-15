using System;
using System.Windows.Input;

namespace GraphLib.Commands
{
    public abstract class VertexCommand : GraphCommand
    {
        protected Vertex Vertex;
        public VertexCommand(Graph graph, Vertex vertex)
            :base(graph) =>
            this.Vertex = vertex;
    }
}
