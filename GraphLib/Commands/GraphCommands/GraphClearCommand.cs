namespace GraphLib.Commands.GraphCommands
{
	public class GraphClearCommand : GraphCommand
	{

		public GraphClearCommand(Graph graph) : base(graph) {}
		
		public override bool CanExecute(object parameter)
		{
			throw new System.NotImplementedException();
		}

		public override void Execute(object parameter)
		{
			Graph.ClearGraph();
		}
		public override void Undo()
		{
			
		}
	}
}
