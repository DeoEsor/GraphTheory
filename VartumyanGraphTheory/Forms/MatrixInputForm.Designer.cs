
namespace VartumyanGraphTheory.Forms
{
    partial class MatrixInputForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MatrixInputForm));
            this.MainText = new System.Windows.Forms.Label();
            this.MatrixInputGrid = new System.Windows.Forms.DataGridView();
            this.AcceptButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MatrixInputGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // MainText
            // 
            this.MainText.AutoSize = true;
            this.MainText.Location = new System.Drawing.Point(288, 46);
            this.MainText.Name = "MainText";
            this.MainText.Size = new System.Drawing.Size(158, 13);
            this.MainText.TabIndex = 0;
            this.MainText.Text = "Название вводимой матрицы";
            // 
            // MatrixInputGrid
            // 
            this.MatrixInputGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MatrixInputGrid.Location = new System.Drawing.Point(67, 73);
            this.MatrixInputGrid.Name = "MatrixInputGrid";
            this.MatrixInputGrid.Size = new System.Drawing.Size(580, 338);
            this.MatrixInputGrid.TabIndex = 1;
            // 
            // AcceptButton
            // 
            this.AcceptButton.Location = new System.Drawing.Point(613, 453);
            this.AcceptButton.Name = "AcceptButton";
            this.AcceptButton.Size = new System.Drawing.Size(75, 23);
            this.AcceptButton.TabIndex = 2;
            this.AcceptButton.Text = "Применить";
            this.AcceptButton.UseVisualStyleBackColor = true;
            // 
            // MatrixInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 495);
            this.Controls.Add(this.AcceptButton);
            this.Controls.Add(this.MatrixInputGrid);
            this.Controls.Add(this.MainText);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MatrixInputForm";
            this.Text = "Ввод матрицы";
            ((System.ComponentModel.ISupportInitialize)(this.MatrixInputGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label MainText;
        public System.Windows.Forms.DataGridView MatrixInputGrid;
        private System.Windows.Forms.Button AcceptButton;
    }
}