namespace GraphLib.Commands
{
	public interface IRedoUndo
	{
		public bool Redo(object param);

		public void Undo();
		
		public enum Last
		{
			Do,
			Undo
		}
		
		Last LastAction { get; set; }
	}
}
