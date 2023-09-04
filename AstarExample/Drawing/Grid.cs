using AstarExample.AlgorithmBase;

namespace AstarExample.Drawing
{
    public class Grid
    {
        private readonly PictureBox _drawingCanvas;
        private Node[,] _nodes;

        private readonly int _cellWidth;
        private readonly int _cellHeight;

        public int HorizontalCells { get; }
        public int VerticalCells { get; }

        public (int x, int y) StartCoordTuple { get; set; }
        public (int x, int y) EndCoordTuple { get; set; }

        public Grid(PictureBox drawingCanvas, int numCellsHorizontal, int numCellsVertical)
        {
            this._drawingCanvas = drawingCanvas;

            HorizontalCells = numCellsHorizontal;
            VerticalCells = numCellsVertical;

            _cellWidth = drawingCanvas.Width / numCellsHorizontal;
            _cellHeight = drawingCanvas.Height / numCellsVertical;

            if (EndCoordTuple.Equals(default))
                EndCoordTuple = (HorizontalCells - 1, VerticalCells - 1);

            if (StartCoordTuple.Equals(default))
                StartCoordTuple = (0, 0);

            _nodes = new Node[numCellsHorizontal, numCellsVertical];
            InitializeGrid(HorizontalCells, VerticalCells);
        }

        public List<Node> GetPathNodes()
        {
            var resNodes = new List<Node>();

            for (int i = 0; i < HorizontalCells; i++)
                for (int j = 0; j < VerticalCells; j++)
                {
                    if (_nodes[i, j].Type == NodeType.Path || _nodes[i, j].Type == NodeType.ClosedSet)
                        resNodes.Add(_nodes[i, j]);
                }

            return resNodes;
        }

        public void ResetGrid()
        {
            InitializeGrid(HorizontalCells, VerticalCells);
            DrawGrid();
        }

        public void DrawGrid()
        {
            var image = new Bitmap(_drawingCanvas.Width, _drawingCanvas.Height);
            using (var graphics = Graphics.FromImage(image))
            {
                var background = new Rectangle(0, 0, image.Width, image.Height);
                graphics.FillRectangle(new SolidBrush(Color.White), background);

                for (int x = 0; x < HorizontalCells; x++)
                {
                    for (int y = 0; y < VerticalCells; y++)
                    {
                        DrawCell(graphics, x, y);
                    }
                }
            }
            _drawingCanvas.InitialImage = null;
            _drawingCanvas.Image = image;
        }

        public async Task DrawHistory(AlgorithmHistory history, TimeSpan? delayBetweenTicks = null)
        {
            delayBetweenTicks ??= TimeSpan.FromMilliseconds(1);

            foreach (var node in history.CheckedNodes)
            {
                await Task.Delay(delayBetweenTicks.Value);

                var updatedCell = _nodes[node.X, node.Y];
                updatedCell.Type = NodeType.ClosedSet;

                RedrawCell(updatedCell);
            }
        }

        public async Task UpdatePath(List<Node> path, TimeSpan? delayBetweenTicks = null)
        {
            delayBetweenTicks ??= TimeSpan.FromMilliseconds(1);

            foreach (var node in path)
            {
                await Task.Delay(delayBetweenTicks.Value);

                var updatedCell = _nodes[node.X, node.Y];
                updatedCell.Type = NodeType.Path;

                RedrawCell(updatedCell);
            }
        }

        public void UpdateCellWeight(int amount, int formPosX, int formPosY, bool setAmountInstedOfIncrease = false)
        {
            int x = formPosX / _cellWidth;
            int y = formPosY / _cellHeight;

            if (!SafetyCheckCoords(x, y))
                return;

            var node = GetNode(x, y);

            if (node != null)
            {
                if (setAmountInstedOfIncrease)
                    node.Weight = amount;
                else
                    node.Weight += amount;

                RedrawCell(node);
            }
        }

        public void AssignRandomWeights(int min = 1, int max = 100)
        {
            foreach (var node in _nodes)
            {
                node.Weight = Random.Shared.Next(min, max);
            }

            DrawGrid();
        }

        public void MoveStartOrEndPosition(NodeType positionToMove, int formPosX, int formPosY)
        {
            int x = formPosX / _cellWidth;
            int y = formPosY / _cellHeight;

            if (!SafetyCheckCoords(x, y))
                return;

            Node node;

            switch (positionToMove)
            {
                case NodeType.Start:
                    node = _nodes[StartCoordTuple.x, StartCoordTuple.y];
                    node.Type = NodeType.Walkable;
                    RedrawCell(node);

                    StartCoordTuple = new ValueTuple<int, int>(x, y);
                    ChangeCellType(StartCoordTuple, NodeType.Start);
                    break;

                case NodeType.End:
                    node = _nodes[EndCoordTuple.x, EndCoordTuple.y];
                    node.Type = NodeType.Walkable;
                    RedrawCell(node);

                    EndCoordTuple = new ValueTuple<int, int>(x, y);
                    ChangeCellType(EndCoordTuple, NodeType.End);
                    break;

                default:
                    throw new NotImplementedException("Cannot move given cell type because movement of given cell type is not yet implemented.");
            }
        }

        public void ChangeCellType(int formPosX, int formPosY, NodeType cellType, bool realCoords = false)
        {
            int x = formPosX;
            int y = formPosY;

            if (!realCoords)
            {
                x = formPosX / _cellWidth;
                y = formPosY / _cellHeight;
            }

            var cell = GetNode(x, y);

            if (cell is not null && cell.Type != cellType)
            {
                if (cell.Type != NodeType.Start && cell.Type != NodeType.End && cell.Type != NodeType.ClosedSet && cell.Type != NodeType.Path)
                {
                    cell.Type = cellType;
                    RedrawCell(cell);
                }
            }
        }

        public void ChangeCellType((int x, int y) coordTuple, NodeType cellType, bool realCoords = true)
        {
            ChangeCellType(coordTuple.x, coordTuple.y, cellType, realCoords);
        }
        public void ResetPath()
        {
            foreach (var node in _nodes)
            {
                if (node.Type == NodeType.Path || node.Type == NodeType.ClosedSet)
                    node.Type = NodeType.Walkable;
            }

            DrawGrid();
        }

        private Brush GetCellTypeBrush(NodeType cellType)
        {
            switch (cellType)
            {
                case NodeType.Walkable:
                    return new SolidBrush(Color.FromArgb(255, 57, 62, 70));

                case NodeType.Obstacle:
                    return Brushes.Black;

                case NodeType.Start:
                    return Brushes.Aquamarine;

                case NodeType.End:
                    return Brushes.IndianRed;

                case NodeType.Path:
                    return new SolidBrush(Color.FromArgb(255, 255, 211, 105));

                case NodeType.ClosedSet:
                    return new SolidBrush(Color.FromArgb(255, 34, 40, 49));

                case NodeType.OpenSet:
                    return Brushes.LightGray;

                default:
                    throw new NotImplementedException("Rectangle color for given type is not yet implemented.");
            }
        }

        private void SetStartAndEndCell()
        {
            _nodes[StartCoordTuple.x, StartCoordTuple.y].Type = NodeType.Start;
            _nodes[EndCoordTuple.x, EndCoordTuple.y].Type = NodeType.End;
        }

        private void InitializeGrid(int numCellsHorizontal, int numCellsVertical)
        {
            for (int x = 0; x < numCellsHorizontal; x++)
            {
                for (int y = 0; y < numCellsVertical; y++)
                {
                    _nodes[x, y] = new Node
                    {
                        X = x,
                        Y = y,
                        Type = NodeType.Walkable
                    };
                }
            }

            SetStartAndEndCell();
        }

        private async Task<Image> RedrawCell(int x, int y)
        {
            Image image = _drawingCanvas.Image;
            await Task.Run(() =>
            {
                var graphics = Graphics.FromImage(image);
                DrawCell(graphics, x, y);
            });

            return image;
        }

        private void DrawCell(Graphics graphics, int x, int y)
        {
            var cell = _nodes[x, y];
            var rect = GetGridRectangle(x, y);

            graphics.FillRectangle(GetCellTypeBrush(cell.Type), rect);

            if (cell.Type != NodeType.Obstacle)
            {
                var stringFormat = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center,
                };

                var cellText = cell.Weight.ToString();
                using var font = new Font("Arial", GetFontSize(cellText, graphics, rect, "Arial", stringFormat, 12), FontStyle.Regular, GraphicsUnit.Point);

                var color = Color.FromArgb(255, 34, 40, 49);

                if (cell.Type == NodeType.ClosedSet)
                    color = Color.FromArgb(255, 57, 62, 70);

                graphics.DrawString(cellText, font, new SolidBrush(color), rect, stringFormat);
            }

            graphics.DrawRectangle(Pens.Black, rect);
        }

        private int GetFontSize(string text, Graphics graphics, RectangleF rect, string fontName, StringFormat stringFormat, int maxFontSize = 32)
        {
            while (maxFontSize > 3)
            {
                using (var font = new Font(fontName, maxFontSize, FontStyle.Regular, GraphicsUnit.Point))
                {
                    var calc = graphics.MeasureString(text, font, (int)rect.Width, stringFormat);
                    if (calc.Height <= rect.Height && calc.Width <= rect.Width)
                    {
                        break;
                    }
                }
                maxFontSize -= 1;
            }
            return maxFontSize;
        }

        private async void RedrawCell(Node cell)
        {
            var newImage = await RedrawCell(cell.X, cell.Y);
            _drawingCanvas.Image = newImage;
        }

        private Rectangle GetGridRectangle(int x, int y)
        {
            return new Rectangle(x * _cellWidth, y * _cellHeight, _cellWidth, _cellHeight);
        }

        public Node? GetNode(int x, int y)
        {
            if (x < 0 || y < 0 || x > _nodes.GetLength(0) - 1 || y > _nodes.GetLength(1) - 1)
                return null;

            return _nodes[x, y];
        }

        public Node GetStartNode()
        {
            return _nodes.Cast<Node>().FirstOrDefault(cell => cell.Type == NodeType.Start) ?? throw new InvalidOperationException();
        }

        public Node GetEndNode()
        {
            return _nodes.Cast<Node>().FirstOrDefault(cell => cell.Type == NodeType.End) ?? throw new InvalidOperationException();
        }

        public bool SafetyCheckCoords(int x, int y)
        {
            if (x < 0) return false;
            if (y < 0) return false;
            if (x > HorizontalCells - 1) return false;
            if (y > VerticalCells - 1) return false;

            return true;
        }
    }
}
