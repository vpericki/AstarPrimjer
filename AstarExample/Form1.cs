using AstarExample.AlgorithmBase;
using AstarExample.Algorithms;
using AstarExample.Drawing;

namespace AstarExample
{
    public partial class Form1 : Form
    {
        private Grid grid;

        public Form1()
        {
            InitializeComponent();
            KeyPreview = true;

            grid = new Grid(drawingCanvas, (int)gridSizeXNumericUpDown.Value, (int)gridSizeYNumericUpDown.Value);
            grid.DrawGrid();
        }

        private void drawingCanvas_MouseMove(object sender, EventArgs e)
        {
            var mouseEventArgs = e as MouseEventArgs;

            if (mouseEventArgs?.Button == MouseButtons.Left)
            {
                grid.ChangeCellType(mouseEventArgs.X, mouseEventArgs.Y, NodeType.Obstacle);
            }
            else if (mouseEventArgs?.Button == MouseButtons.Right)
            {
                grid.ChangeCellType(mouseEventArgs.X, mouseEventArgs.Y, NodeType.Walkable);
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (e is HandledMouseEventArgs hme)
                hme.Handled = true;

            var mousePos = Cursor.Position;
            var mousePosControl = this.PointToClient(mousePos);

            if (e.Delta > 0)
            {
                grid.UpdateCellWeight(1, mousePosControl.X, mousePosControl.Y);
            }
            else
            {
                grid.UpdateCellWeight(-1, mousePosControl.X, mousePosControl.Y);
            }
        }

        protected override void OnKeyUp(KeyEventArgs? keyEventArgs)
        {
            var mousePos = Cursor.Position;
            var mousePosControl = this.PointToClient(mousePos);

            if (keyEventArgs is null)
                return;

            if (keyEventArgs.KeyCode == Keys.E)
                grid.MoveStartOrEndPosition(NodeType.End, mousePosControl.X, mousePosControl.Y);

            if (keyEventArgs.KeyCode == Keys.S)
                grid.MoveStartOrEndPosition(NodeType.Start, mousePosControl.X, mousePosControl.Y);

            if (char.IsNumber((char)keyEventArgs.KeyCode))
            {
                var numChar = (char)keyEventArgs.KeyCode;
                if (int.TryParse(numChar.ToString(), out var result))
                    grid.UpdateCellWeight(result, mousePosControl.X, mousePosControl.Y, true);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            grid.ResetGrid();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var checkedButton = Controls.OfType<RadioButton>()
                    .FirstOrDefault(r => r.Checked);

                var diagonalMovement = diagonalCheckbox.Checked;

                List<Node> path;
                Algorithm algorithm;

                grid.ResetPath();

                switch (checkedButton!.Name)
                {
                    case "ASTAR":
                        algorithm = new Astar(grid, diagonalMovement);
                        path = algorithm.FindPathTimed();
                        break;

                    case "ASTARHEAP":
                        algorithm = new AStarHeap(grid, diagonalMovement);
                        path = algorithm.FindPathTimed();
                        break;

                    case "DJIKSTRA":
                        algorithm = new Djikstra(grid, diagonalMovement);
                        path = algorithm.FindPathTimed();
                        break;

                    case "ASTARWEIGHTED":
                        algorithm = new AStarWeighted(grid, diagonalMovement);
                        path = algorithm.FindPathTimed();
                        break;
                    
                    default:
                        throw new NotImplementedException("Given algorithm has not yet been implemented.");
                }

                UpdateElapsedTimeLabel(algorithm.ElapsedTime);
                UpdateOperationsLabel(algorithm.NumberOfOperations);
                UpdatePercentOfGridCheckedLabel(algorithm.PercentageGridChecked);

                DisableControls();

                grid.ResetPath();
                await grid.DrawHistory(algorithm.History);
                await grid.UpdatePath(path);

                EnableControls();


            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DisableControls()
        {
            Enabled = false;
        }

        private void EnableControls()
        {
            Enabled = true;
        }

        private void UpdatePercentOfGridCheckedLabel(double number)
        {
            percentGridCheckedLabel.Text = $"% of grid checked: {(number).ToString("P")}";
        }

        private void UpdateElapsedTimeLabel(TimeSpan timeSpan)
        {
            elapsedTimeLabel.Text = $"Elapsed time: {timeSpan.TotalMicroseconds} microseconds";
        }

        private void UpdateOperationsLabel(int numberOfOperations)
        {
            operationsLabel.Text = $"Operations: {numberOfOperations}";
        }

        private void resetPathButton_Click(object sender, EventArgs e)
        {
            grid.ResetPath();
        }

        private void assignRandomWeightsButton_Click(object sender, EventArgs e)
        {
            grid.AssignRandomWeights();
        }

        private void gridSizeButton_Click(object sender, EventArgs e)
        {
            var xCells = (int)gridSizeXNumericUpDown.Value;
            var yCells = (int)gridSizeYNumericUpDown.Value;

            if (grid.VerticalCells == yCells && grid.HorizontalCells == xCells)
                return;

            grid = new Grid(drawingCanvas, xCells, yCells);
            grid.DrawGrid();
        }
    }
}