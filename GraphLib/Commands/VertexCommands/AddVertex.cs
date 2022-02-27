using System;
namespace GraphLib.Commands.VertexCommands
{
	public class AddVertex : VertexCommand
	{
		public AddVertex(Graph graph, Vertex vertex) : base(graph, vertex) {}

		public override bool CanExecute(object parameter) => true;

		public override void Execute(object parameter)
		{
			if (!(parameter is Vertex vertex)) return;

			base.Execute(parameter); 

			vertex.Graph.Vertices.Add(vertex);

		}
		public override void Undo()
		{
			throw new NotImplementedException();
		}
	}
}
