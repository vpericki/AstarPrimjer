using System.Diagnostics;
using AstarExample.Drawing;

namespace AstarExample.AlgorithmBase
{
    public abstract class Algorithm
    {
        protected Grid Grid;

        protected Node StartNode;
        protected Node DestinationNode;
        public int NumberOfOperations { get; protected set; }

        private readonly bool _canMoveDiagonally;
        private readonly Stopwatch _stopwatch;

        public TimeSpan ElapsedTime;

        public AlgorithmHistory History { get; }
        public double PercentageGridChecked => (double)(History.CheckedNodes.Count + 2) / (Grid.VerticalCells * Grid.HorizontalCells);

        protected Algorithm(Grid grid, bool canMoveDiagonally)
        {
            Grid = grid;
            StartNode = Grid.GetStartNode();
            DestinationNode = Grid.GetEndNode();
            _canMoveDiagonally = canMoveDiagonally;
            _stopwatch = new Stopwatch();
            NumberOfOperations = 0;
            History = new AlgorithmHistory(StartNode, DestinationNode);
        }

        public List<Node> FindPathTimed()
        {
            _stopwatch.Reset();
            _stopwatch.Start();
            var path = FindPath();
            _stopwatch.Stop();

            ElapsedTime = _stopwatch.Elapsed;

            return path;
        }

        protected abstract List<Node> FindPath();

        protected List<Node> GetFinalPath(Node? currentNode)
        {
            var path = new List<Node>();

            while (!CoordinatesMatch(currentNode!, StartNode))
            {
                path.Add(currentNode!);
                currentNode = currentNode?.Parent;
            }

            path.RemoveAt(0);
            path.Reverse();

            NumberOfOperations++;

            return path;
        }

        public List<Node> GetNeighbours(Node node)
        {
            var neighbours = new List<Node>();

            for (int x = -1; x <= 1; x++)
                for (int y = -1; y <= 1; y++)
                {
                    if (x == 0 && y == 0)
                        continue;

                    if (_canMoveDiagonally == false)
                    {
                        if (Math.Abs(MathF.Abs(x) - MathF.Abs(y)) <= 0.00001)
                            continue;
                    }

                    var checkX = node.X + x;
                    var checkY = node.Y + y;

                    var cell = Grid.GetNode(checkX, checkY);

                    if (cell is null) continue;

                    neighbours.Add(cell);
                }

            return neighbours;
        }


        protected static bool CoordinatesMatch(Node nodeA, Node nodeB) => nodeA.X == nodeB.X && nodeA.Y == nodeB.Y;

        protected int GetDistance(Node nodeA, Node nodeB)
        {
            if (!_canMoveDiagonally)
                return Math.Abs(nodeA.X - nodeB.X) + Math.Abs(nodeA.Y - nodeB.Y);

            var dx = Math.Abs(nodeA.X - nodeB.X);
            var dy = Math.Abs(nodeA.Y - nodeB.Y);

            const int d = 10;
            const int d2 = 14;

            return d * (dx + dy) + (d2 - 2 * d) * Math.Min(dx, dy);
        }
    }
}
