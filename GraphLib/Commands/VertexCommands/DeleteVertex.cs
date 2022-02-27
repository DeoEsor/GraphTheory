using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLib.Commands.VertexCommands
{
    public class DeleteVertex : VertexCommand
    {
        public DeleteVertex(Graph graph, Vertex vertex) : base(graph, vertex) {}

        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {
            if (!(parameter is Vertex vertex)) return;

            base.Execute(parameter);

            for (int i = 0; i < vertex.Edges.Count; i++)
                vertex.Edges[i].Delete();

            vertex.Graph.Vertices.Remove(vertex);

        }
        public override void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
