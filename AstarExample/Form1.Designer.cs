namespace AstarExample
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            drawingCanvas = new PictureBox();
            btnReset = new Button();
            button1 = new Button();
            ASTAR = new RadioButton();
            ASTARHEAP = new RadioButton();
            DJIKSTRA = new RadioButton();
            diagonalCheckbox = new CheckBox();
            elapsedTimeLabel = new Label();
            operationsLabel = new Label();
            resetPathButton = new Button();
            percentGridCheckedLabel = new Label();
            ASTARWEIGHTED = new RadioButton();
            assignRandomWeightsButton = new Button();
            label1 = new Label();
            gridSizeXNumericUpDown = new NumericUpDown();
            gridSizeYNumericUpDown = new NumericUpDown();
            label2 = new Label();
            label3 = new Label();
            gridSizeButton = new Button();
            ((System.ComponentModel.ISupportInitialize)drawingCanvas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridSizeXNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridSizeYNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // drawingCanvas
            // 
            drawingCanvas.Location = new Point(12, 12);
            drawingCanvas.Name = "drawingCanvas";
            drawingCanvas.Size = new Size(1868, 1060);
            drawingCanvas.TabIndex = 0;
            drawingCanvas.TabStop = false;
            drawingCanvas.MouseMove += drawingCanvas_MouseMove;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(1621, 1175);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(102, 62);
            btnReset.TabIndex = 2;
            btnReset.Text = "Reset obstacles";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // button1
            // 
            button1.Location = new Point(1729, 1099);
            button1.Name = "button1";
            button1.Size = new Size(151, 138);
            button1.TabIndex = 3;
            button1.Text = "Start";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // ASTAR
            // 
            ASTAR.AutoSize = true;
            ASTAR.Checked = true;
            ASTAR.Location = new Point(12, 1099);
            ASTAR.Name = "ASTAR";
            ASTAR.Size = new Size(66, 24);
            ASTAR.TabIndex = 4;
            ASTAR.TabStop = true;
            ASTAR.Text = "AStar";
            ASTAR.UseVisualStyleBackColor = true;
            // 
            // ASTARHEAP
            // 
            ASTARHEAP.AutoSize = true;
            ASTARHEAP.Location = new Point(12, 1129);
            ASTARHEAP.Name = "ASTARHEAP";
            ASTARHEAP.Size = new Size(102, 24);
            ASTARHEAP.TabIndex = 5;
            ASTARHEAP.TabStop = true;
            ASTARHEAP.Text = "AStarHeap";
            ASTARHEAP.UseVisualStyleBackColor = true;
            // 
            // DJIKSTRA
            // 
            DJIKSTRA.AutoSize = true;
            DJIKSTRA.Location = new Point(12, 1159);
            DJIKSTRA.Name = "DJIKSTRA";
            DJIKSTRA.Size = new Size(80, 24);
            DJIKSTRA.TabIndex = 6;
            DJIKSTRA.TabStop = true;
            DJIKSTRA.Text = "Djikstra";
            DJIKSTRA.UseVisualStyleBackColor = true;
            // 
            // diagonalCheckbox
            // 
            diagonalCheckbox.AutoSize = true;
            diagonalCheckbox.Location = new Point(191, 1099);
            diagonalCheckbox.Name = "diagonalCheckbox";
            diagonalCheckbox.Size = new Size(167, 24);
            diagonalCheckbox.TabIndex = 7;
            diagonalCheckbox.Text = "Diagonal Movement";
            diagonalCheckbox.UseVisualStyleBackColor = true;
            // 
            // elapsedTimeLabel
            // 
            elapsedTimeLabel.AutoSize = true;
            elapsedTimeLabel.Location = new Point(191, 1132);
            elapsedTimeLabel.Name = "elapsedTimeLabel";
            elapsedTimeLabel.Size = new Size(102, 20);
            elapsedTimeLabel.TabIndex = 8;
            elapsedTimeLabel.Text = "Elapsed time: ";
            // 
            // operationsLabel
            // 
            operationsLabel.AutoSize = true;
            operationsLabel.Location = new Point(191, 1162);
            operationsLabel.Name = "operationsLabel";
            operationsLabel.Size = new Size(85, 20);
            operationsLabel.TabIndex = 9;
            operationsLabel.Text = "Operations:";
            // 
            // resetPathButton
            // 
            resetPathButton.Location = new Point(1621, 1099);
            resetPathButton.Name = "resetPathButton";
            resetPathButton.Size = new Size(102, 62);
            resetPathButton.TabIndex = 10;
            resetPathButton.Text = "Reset path";
            resetPathButton.UseVisualStyleBackColor = true;
            resetPathButton.Click += resetPathButton_Click;
            // 
            // percentGridCheckedLabel
            // 
            percentGridCheckedLabel.AutoSize = true;
            percentGridCheckedLabel.Location = new Point(191, 1196);
            percentGridCheckedLabel.Name = "percentGridCheckedLabel";
            percentGridCheckedLabel.Size = new Size(135, 20);
            percentGridCheckedLabel.TabIndex = 11;
            percentGridCheckedLabel.Text = "% of grid checked: ";
            // 
            // ASTARWEIGHTED
            // 
            ASTARWEIGHTED.AutoSize = true;
            ASTARWEIGHTED.Location = new Point(12, 1189);
            ASTARWEIGHTED.Name = "ASTARWEIGHTED";
            ASTARWEIGHTED.Size = new Size(134, 24);
            ASTARWEIGHTED.TabIndex = 12;
            ASTARWEIGHTED.TabStop = true;
            ASTARWEIGHTED.Text = "AStar Weighted";
            ASTARWEIGHTED.UseVisualStyleBackColor = true;
            // 
            // assignRandomWeightsButton
            // 
            assignRandomWeightsButton.Location = new Point(1460, 1099);
            assignRandomWeightsButton.Name = "assignRandomWeightsButton";
            assignRandomWeightsButton.Size = new Size(155, 62);
            assignRandomWeightsButton.TabIndex = 13;
            assignRandomWeightsButton.Text = "Assign Random Weights";
            assignRandomWeightsButton.UseVisualStyleBackColor = true;
            assignRandomWeightsButton.Click += assignRandomWeightsButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(394, 1100);
            label1.Name = "label1";
            label1.Size = new Size(69, 20);
            label1.TabIndex = 16;
            label1.Text = "Grid size:";
            // 
            // gridSizeXNumericUpDown
            // 
            gridSizeXNumericUpDown.Location = new Point(469, 1098);
            gridSizeXNumericUpDown.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            gridSizeXNumericUpDown.Name = "gridSizeXNumericUpDown";
            gridSizeXNumericUpDown.Size = new Size(64, 27);
            gridSizeXNumericUpDown.TabIndex = 17;
            gridSizeXNumericUpDown.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // gridSizeYNumericUpDown
            // 
            gridSizeYNumericUpDown.Location = new Point(539, 1099);
            gridSizeYNumericUpDown.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            gridSizeYNumericUpDown.Name = "gridSizeYNumericUpDown";
            gridSizeYNumericUpDown.Size = new Size(64, 27);
            gridSizeYNumericUpDown.TabIndex = 18;
            gridSizeYNumericUpDown.Value = new decimal(new int[] { 25, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(488, 1075);
            label2.Name = "label2";
            label2.Size = new Size(16, 20);
            label2.TabIndex = 19;
            label2.Text = "x";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(556, 1075);
            label3.Name = "label3";
            label3.Size = new Size(16, 20);
            label3.TabIndex = 20;
            label3.Text = "y";
            // 
            // gridSizeButton
            // 
            gridSizeButton.Location = new Point(609, 1098);
            gridSizeButton.Name = "gridSizeButton";
            gridSizeButton.Size = new Size(102, 28);
            gridSizeButton.TabIndex = 21;
            gridSizeButton.Text = "Apply";
            gridSizeButton.UseVisualStyleBackColor = true;
            gridSizeButton.Click += gridSizeButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(238, 238, 238);
            ClientSize = new Size(1892, 1285);
            Controls.Add(gridSizeButton);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(gridSizeYNumericUpDown);
            Controls.Add(gridSizeXNumericUpDown);
            Controls.Add(label1);
            Controls.Add(assignRandomWeightsButton);
            Controls.Add(ASTARWEIGHTED);
            Controls.Add(percentGridCheckedLabel);
            Controls.Add(resetPathButton);
            Controls.Add(operationsLabel);
            Controls.Add(elapsedTimeLabel);
            Controls.Add(diagonalCheckbox);
            Controls.Add(DJIKSTRA);
            Controls.Add(ASTARHEAP);
            Controls.Add(ASTAR);
            Controls.Add(button1);
            Controls.Add(btnReset);
            Controls.Add(drawingCanvas);
            Name = "Form1";
            Text = "Algorithm Examples";
            ((System.ComponentModel.ISupportInitialize)drawingCanvas).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridSizeXNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridSizeYNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox drawingCanvas;
        private Button btnReset;
        private Button button1;
        private RadioButton ASTAR;
        private RadioButton ASTARHEAP;
        private RadioButton DJIKSTRA;
        private CheckBox diagonalCheckbox;
        private Label elapsedTimeLabel;
        private Label operationsLabel;
        private Button resetPathButton;
        private Label percentGridCheckedLabel;
        private RadioButton ASTARWEIGHTED;
        private Button assignRandomWeightsButton;
        private Label label1;
        private NumericUpDown gridSizeXNumericUpDown;
        private NumericUpDown gridSizeYNumericUpDown;
        private Label label2;
        private Label label3;
        private Button gridSizeButton;
    }
}