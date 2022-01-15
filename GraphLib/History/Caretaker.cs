using System.Collections.ObjectModel;

namespace GraphLib
{
    public class Caretaker
    {
        public ObservableCollection<MementoGraph> History { get; set; } = new ObservableCollection<MementoGraph>();
        public Originator Originator { get; set; } = new Originator();
    }
}
