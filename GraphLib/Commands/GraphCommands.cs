using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GraphLib.Commands
{
    public abstract class GraphCommand : ICommand
    {
        protected Graph Graph;

        public GraphCommand(Graph graph) => this.Graph = graph;

        public event EventHandler CanExecuteChanged;

        public abstract bool CanExecute(object parameter);
        public virtual void Execute(object parameter)
        {
            Graph.Caretaker.History.Add(Originator.CreateMemento(Graph));
        }

        public abstract void Undo();
    }
}
