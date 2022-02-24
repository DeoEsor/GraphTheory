using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLib.Commands.VertexCommands
{
    public class AddEdge : VertexCommand
    {
        public AddEdge(Graph graph, Vertex vertex) : base(graph, vertex)
        {
        }

        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {
            if (!(parameter is Vertex vertex)) throw new ArgumentException();

            base.Execute(parameter);
            Graph.CreateEdge(Vertex, vertex);
            if (!Graph.IsOriented)
                Graph.CreateEdge(vertex, Vertex);
        }
        public override void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
