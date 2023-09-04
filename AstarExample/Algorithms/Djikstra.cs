using AstarExample.AlgorithmBase;
using AstarExample.Drawing;
using AstarExample.Heap;

namespace AstarExample.Algorithms
{
    public class Djikstra : Algorithm
    {
        private Heap<Node> _openList;
        private List<Node> _closedList = new List<Node>();

        public Djikstra(Grid grid, bool canMoveDiagonally) : base(grid, canMoveDiagonally)
        {
            _openList = new Heap<Node>(grid.VerticalCells * grid.HorizontalCells);
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
                        neighbour.HCost = 0;
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
