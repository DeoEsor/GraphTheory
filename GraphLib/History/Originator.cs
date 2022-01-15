namespace GraphLib
{
    public class Originator
    {
        public Graph Current { get; set; }
        public void SetMemento(MementoGraph memento)
        {
            Current = memento.State;
        }
        public static MementoGraph CreateMemento(Graph graph)
        {
            return new MementoGraph(graph);
        }
    }
}
