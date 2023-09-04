using AstarExample.AlgorithmBase;
using AstarExample.Drawing;
using AstarExample.Heap;

namespace AstarExample.Algorithms
{
    public  class AStarHeap : Algorithm
    {
        private Heap<Node> _openList;
        private Heap<Node> _closedList;


        public AStarHeap(Grid grid, bool canMoveDiagionally) : base(grid, canMoveDiagionally)
        {
            _openList = new Heap<Node>(Grid.VerticalCells * Grid.HorizontalCells);
            _closedList = new Heap<Node>(Grid.VerticalCells * Grid.HorizontalCells);

            _openList.Add(StartNode);
        }

        protected override List<Node> FindPath()
        {
            while (_openList.Count > 0)
            {
                NumberOfOperations++;

                var node = _openList.RemoveFirst();
                _closedList.Add(node);

                if (CoordinatesMatch(node, DestinationNode))
                    return GetFinalPath(node);

                var neighbours = GetNeighbours(node);
                History.GenerateHistoryList(neighbours);

                foreach (var neighbour in neighbours)
                {
                    if (!neighbour.Walkable || _closedList.Contains(neighbour))
                        continue;

                    var newCost = node.GCost + GetDistance(node, neighbour);
                    if (newCost < neighbour.GCost || !_openList.Contains(neighbour))
                    {
                        neighbour.GCost = newCost;
                        neighbour.HCost = GetDistance(neighbour, DestinationNode);
                        neighbour.Parent = node;

                        if (!_openList.Contains(neighbour))
                        {
                            _openList.Add(neighbour);
                            NumberOfOperations++;
                        }
                    }
                }

            }

            return new List<Node>();
        }
    }
}
