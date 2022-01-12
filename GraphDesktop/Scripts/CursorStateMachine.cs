namespace GraphDesktop.Scripts
{
	/// <summary>
	/// FSM Switch case реализация для GraphCanvas
	/// </summary>
	public static class CursorStateMachine
	{
		public enum State { Free, VertexMove, EdgePlacement }

		public static State CurrentState { get; set; } = State.Free;
	}
}
