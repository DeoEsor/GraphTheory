using System;
using System.Windows.Input;

namespace GraphLib.Commands
{
    abstract class EdgeCommand : GraphCommand
    {
        public EdgeCommand(Graph graph): base(graph) { }
    }
}
