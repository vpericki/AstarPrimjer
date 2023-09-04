using AstarExample.Drawing;

namespace AstarExample.AlgorithmBase
{
    public class AlgorithmHistory
    {
        public List<Node> CheckedNodes { get; }

        private readonly Node _startNode;
        private readonly Node _endNode;
        public AlgorithmHistory(Node startNode, Node endNode)
        {
            CheckedNodes = new List<Node>();
            _startNode = startNode;
            _endNode = endNode;
        }

        public void GenerateHistoryList(List<Node> neighbours)
        {
            foreach (var neighbour in neighbours)
            {
                AddToNodeList(CheckedNodes, neighbour);
            }
        }

        private void AddToNodeList(List<Node> nodeList, Node node)
        {
            if (!(node.X == _endNode.X && node.Y == _endNode.Y) && !(node.X == _startNode.X && node.Y == _startNode.Y) && node.Walkable)
            {
                if (!nodeList.Exists(n => n.X == node.X && n.Y == node.Y))
                    nodeList.Add(node);
            }
        }
    }
}
