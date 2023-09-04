using AstarExample.AlgorithmBase;
using AstarExample.Drawing;

namespace AstarExample.Algorithms
{
public class Astar : Algorithm
{
    private List<Node> _openList = new List<Node>();
    private List<Node> _closedList = new List<Node>();

    public Astar(Grid grid, bool canMoveDiagionally) : base(grid, canMoveDiagionally)
    {
        _openList.Add(StartNode);
    }

    protected override List<Node> FindPath()
    {
        while (_openList.Count > 0)
        {
            var node = _openList[0];
            NumberOfOperations++;

            for (var i = 1; i < _openList.Count; i++)
            {
                if (_openList[i].FCost < node.FCost || _openList[i].FCost == node.FCost)
                    if (_openList[i].HCost < node.HCost)
                        node = _openList[i];
            }

            _openList.Remove(node);
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
