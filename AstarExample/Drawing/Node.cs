using AstarExample.Heap;

namespace AstarExample.Drawing
{
    public class Node : IHeapItem<Node>
    {
        public int X;
        public int Y;

        public int Weight = 1;

        public int GCost;
        public int HCost;
        public int RHS;
        public int Key;

        public NodeType Type;

        public bool Walkable => Type is NodeType.Walkable or NodeType.Start or NodeType.End or NodeType.Path;

        public Node? Parent;

        public List<Node> GetPredecesors()
        {
            var result = new List<Node>();
            var parent = Parent;
            while(parent != null)
            {
                result.Add(parent);
                parent = parent?.Parent;
            }

            return result;
        }

        public int FCost => GCost + HCost;
        public int CompareTo(Node? other)
        {
            if (other == null) return 1;
            var compareValue = FCost.CompareTo(other.FCost);
            if (compareValue == 0)
            {
                compareValue = HCost.CompareTo(other.HCost);
            }

            return -compareValue;
        }

        public int HeapIndex { get; set; }
    }

    public enum NodeType
    {
        Walkable = 0,
        Obstacle = 1,
        Start = 20,
        Path = 25,
        OpenSet = 26,
        ClosedSet = 27,
        End = 30
    }
}
