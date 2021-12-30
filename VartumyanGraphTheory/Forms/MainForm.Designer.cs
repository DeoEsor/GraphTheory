﻿namespace VartumyanGraphTheory
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.listBoxMatrix = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.импортToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.матрицыИнцидентностиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.матрицыСмежностиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокомВершинИРеберToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вручнуюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изФайлаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.матрицуИнцидентностиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.матрицуСмежностиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pNGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обАвторахToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.задачиТеорииГрафовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cycleButton = new System.Windows.Forms.Button();
            this.chainButton = new System.Windows.Forms.Button();
            this.selectButton = new System.Windows.Forms.Button();
            this.buttonInc = new System.Windows.Forms.Button();
            this.buttonAdj = new System.Windows.Forms.Button();
            this.deleteALLButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.drawEdgeButton = new System.Windows.Forms.Button();
            this.drawVertexButton = new System.Windows.Forms.Button();
            this.sheet = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sheet)).BeginInit();
            this.SuspendLayout();

            // 
            // listBoxMatrix
            // 
            this.listBoxMatrix.FormattingEnabled = true;
            this.listBoxMatrix.Location = new System.Drawing.Point(731, 125);
            this.listBoxMatrix.Name = "listBoxMatrix";
            this.listBoxMatrix.Size = new System.Drawing.Size(217, 251);
            this.listBoxMatrix.TabIndex = 6;

            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);

            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.GrayText;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                this.файлToolStripMenuItem,
                this.оПрограммеToolStripMenuItem,
                this.задачиТеорииГрафовToolStripMenuItem,
                this.toolStripMenuItem1
            });
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(969, 24);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";

            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                this.импортToolStripMenuItem,
                this.сохранитьToolStripMenuItem,
                this.обАвторахToolStripMenuItem,
                this.выходToolStripMenuItem
            });
            this.файлToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";

            // 
            // импортToolStripMenuItem
            // 
            this.импортToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                this.матрицыИнцидентностиToolStripMenuItem,
                this.матрицыСмежностиToolStripMenuItem,
                this.списокомВершинИРеберToolStripMenuItem
            });
            this.импортToolStripMenuItem.Name = "импортToolStripMenuItem";
            this.импортToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.импортToolStripMenuItem.Text = "Импорт";

            // 
            // матрицыИнцидентностиToolStripMenuItem
            // 
            this.матрицыИнцидентностиToolStripMenuItem.Name = "матрицыИнцидентностиToolStripMenuItem";
            this.матрицыИнцидентностиToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.матрицыИнцидентностиToolStripMenuItem.Text = "Матрицы инцидентности";
            this.матрицыИнцидентностиToolStripMenuItem.Click += new System.EventHandler(this.матрицыИнцидентностиToolStripMenuItem_Click);

            // 
            // матрицыСмежностиToolStripMenuItem
            // 
            this.матрицыСмежностиToolStripMenuItem.Name = "матрицыСмежностиToolStripMenuItem";
            this.матрицыСмежностиToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.матрицыСмежностиToolStripMenuItem.Text = "Матрицы смежности";
            this.матрицыСмежностиToolStripMenuItem.Click += new System.EventHandler(this.матрицыСмежностиToolStripMenuItem_Click);

            // 
            // списокомВершинИРеберToolStripMenuItem
            // 
            this.списокомВершинИРеберToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                this.вручнуюToolStripMenuItem,
                this.изФайлаToolStripMenuItem
            });
            this.списокомВершинИРеберToolStripMenuItem.Name = "списокомВершинИРеберToolStripMenuItem";
            this.списокомВершинИРеберToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.списокомВершинИРеберToolStripMenuItem.Text = "Списоком вершин и ребер";

            // 
            // вручнуюToolStripMenuItem
            // 
            this.вручнуюToolStripMenuItem.Name = "вручнуюToolStripMenuItem";
            this.вручнуюToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.вручнуюToolStripMenuItem.Text = "Вручную";

            // 
            // изФайлаToolStripMenuItem
            // 
            this.изФайлаToolStripMenuItem.Name = "изФайлаToolStripMenuItem";
            this.изФайлаToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.изФайлаToolStripMenuItem.Text = "Из файла";

            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                this.матрицуИнцидентностиToolStripMenuItem,
                this.матрицуСмежностиToolStripMenuItem,
                this.pNGToolStripMenuItem
            });
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить как";

            // 
            // матрицуИнцидентностиToolStripMenuItem
            // 
            this.матрицуИнцидентностиToolStripMenuItem.Name = "матрицуИнцидентностиToolStripMenuItem";
            this.матрицуИнцидентностиToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.матрицуИнцидентностиToolStripMenuItem.Text = "Матрицу инцидентности";
            this.матрицуИнцидентностиToolStripMenuItem.Click += new System.EventHandler(this.SaveInc);

            // 
            // матрицуСмежностиToolStripMenuItem
            // 
            this.матрицуСмежностиToolStripMenuItem.Name = "матрицуСмежностиToolStripMenuItem";
            this.матрицуСмежностиToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.матрицуСмежностиToolStripMenuItem.Text = "Матрицу смежности";
            this.матрицуСмежностиToolStripMenuItem.Click += new System.EventHandler(this.SaveAdj);

            // 
            // pNGToolStripMenuItem
            // 
            this.pNGToolStripMenuItem.Name = "pNGToolStripMenuItem";
            this.pNGToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.pNGToolStripMenuItem.Text = "PNG";
            this.pNGToolStripMenuItem.Click += new System.EventHandler(this.saveButton_Click);

            // 
            // обАвторахToolStripMenuItem
            // 
            this.обАвторахToolStripMenuItem.Name = "обАвторахToolStripMenuItem";
            this.обАвторахToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.обАвторахToolStripMenuItem.Text = "Об авторах";
            this.обАвторахToolStripMenuItem.Click += new System.EventHandler(this.about_Click);

            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.выходToolStripMenuItem.Text = "Выход";

            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.оПрограммеToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.оПрограммеToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.aboutProg_Click);

            // 
            // задачиТеорииГрафовToolStripMenuItem
            // 
            this.задачиТеорииГрафовToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlDark;
            this.задачиТеорииГрафовToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.задачиТеорииГрафовToolStripMenuItem.Name = "задачиТеорииГрафовToolStripMenuItem";
            this.задачиТеорииГрафовToolStripMenuItem.Size = new System.Drawing.Size(143, 20);
            this.задачиТеорииГрафовToolStripMenuItem.Text = "Задачи теории графов";

            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(24, 20);
            this.toolStripMenuItem1.Text = "?";

            // 
            // cycleButton
            // 
            this.cycleButton.Image = global::VartumyanGraphTheory.Properties.Resources.cycle;
            this.cycleButton.Location = new System.Drawing.Point(873, 382);
            this.cycleButton.Name = "cycleButton";
            this.cycleButton.Size = new System.Drawing.Size(70, 45);
            this.cycleButton.TabIndex = 11;
            this.cycleButton.UseVisualStyleBackColor = true;
            this.cycleButton.Click += new System.EventHandler(this.cycleButton_Click);

            // 
            // chainButton
            // 
            this.chainButton.Image = global::VartumyanGraphTheory.Properties.Resources.chain;
            this.chainButton.Location = new System.Drawing.Point(731, 382);
            this.chainButton.Name = "chainButton";
            this.chainButton.Size = new System.Drawing.Size(70, 45);
            this.chainButton.TabIndex = 10;
            this.chainButton.UseVisualStyleBackColor = true;
            this.chainButton.Click += new System.EventHandler(this.chainButton_Click);

            // 
            // selectButton
            // 
            this.selectButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.selectButton.Image = global::VartumyanGraphTheory.Properties.Resources.cursor;
            this.selectButton.Location = new System.Drawing.Point(12, 38);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(45, 45);
            this.selectButton.TabIndex = 9;
            this.selectButton.UseVisualStyleBackColor = false;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);

            // 
            // buttonInc
            // 
            this.buttonInc.Image = global::VartumyanGraphTheory.Properties.Resources.inc;
            this.buttonInc.Location = new System.Drawing.Point(856, 67);
            this.buttonInc.Name = "buttonInc";
            this.buttonInc.Size = new System.Drawing.Size(92, 52);
            this.buttonInc.TabIndex = 8;
            this.buttonInc.UseVisualStyleBackColor = true;
            this.buttonInc.Click += new System.EventHandler(this.buttonInc_Click);

            // 
            // buttonAdj
            // 
            this.buttonAdj.Image = global::VartumyanGraphTheory.Properties.Resources.smezh;
            this.buttonAdj.Location = new System.Drawing.Point(731, 67);
            this.buttonAdj.Name = "buttonAdj";
            this.buttonAdj.Size = new System.Drawing.Size(92, 52);
            this.buttonAdj.TabIndex = 7;
            this.buttonAdj.UseVisualStyleBackColor = true;
            this.buttonAdj.Click += new System.EventHandler(this.buttonAdj_Click);

            // 
            // deleteALLButton
            // 
            this.deleteALLButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.deleteALLButton.Image = global::VartumyanGraphTheory.Properties.Resources.deleteAll;
            this.deleteALLButton.Location = new System.Drawing.Point(13, 243);
            this.deleteALLButton.Name = "deleteALLButton";
            this.deleteALLButton.Size = new System.Drawing.Size(45, 45);
            this.deleteALLButton.TabIndex = 5;
            this.deleteALLButton.UseVisualStyleBackColor = false;
            this.deleteALLButton.Click += new System.EventHandler(this.deleteALLButton_Click);

            // 
            // deleteButton
            // 
            this.deleteButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.deleteButton.Image = global::VartumyanGraphTheory.Properties.Resources.delete;
            this.deleteButton.Location = new System.Drawing.Point(13, 192);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(45, 45);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);

            // 
            // drawEdgeButton
            // 
            this.drawEdgeButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.drawEdgeButton.Image = global::VartumyanGraphTheory.Properties.Resources.edge;
            this.drawEdgeButton.Location = new System.Drawing.Point(12, 141);
            this.drawEdgeButton.Name = "drawEdgeButton";
            this.drawEdgeButton.Size = new System.Drawing.Size(45, 45);
            this.drawEdgeButton.TabIndex = 2;
            this.drawEdgeButton.UseVisualStyleBackColor = false;
            this.drawEdgeButton.Click += new System.EventHandler(this.drawEdgeButton_Click);

            // 
            // drawVertexButton
            // 
            this.drawVertexButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.drawVertexButton.Image = global::VartumyanGraphTheory.Properties.Resources.vertex;
            this.drawVertexButton.Location = new System.Drawing.Point(13, 90);
            this.drawVertexButton.Name = "drawVertexButton";
            this.drawVertexButton.Size = new System.Drawing.Size(45, 45);
            this.drawVertexButton.TabIndex = 1;
            this.drawVertexButton.UseVisualStyleBackColor = false;
            this.drawVertexButton.Click += new System.EventHandler(this.drawVertexButton_Click);

            // 
            // sheet
            // 
            this.sheet.BackColor = System.Drawing.SystemColors.Control;
            this.sheet.Location = new System.Drawing.Point(70, 39);
            this.sheet.Name = "sheet";
            this.sheet.Size = new System.Drawing.Size(634, 388);
            this.sheet.TabIndex = 0;
            this.sheet.TabStop = false;
            this.sheet.MouseClick += new System.Windows.Forms.MouseEventHandler(this.sheet_MouseClick);

            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(810, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 26);
            this.label1.TabIndex = 17;
            this.label1.Text = "Вид";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(969, 444);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.cycleButton);
            this.Controls.Add(this.chainButton);
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.buttonInc);
            this.Controls.Add(this.buttonAdj);
            this.Controls.Add(this.listBoxMatrix);
            this.Controls.Add(this.deleteALLButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.drawEdgeButton);
            this.Controls.Add(this.drawVertexButton);
            this.Controls.Add(this.sheet);
            this.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Теория графов";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sheet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem списокомВершинИРеберToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вручнуюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изФайлаToolStripMenuItem;
        #endregion
        #region UI Elements
        public System.Windows.Forms.PictureBox sheet;
        public System.Windows.Forms.Button drawVertexButton;
        private System.Windows.Forms.Button drawEdgeButton;
        public System.Windows.Forms.Button deleteButton;
        public System.Windows.Forms.Button deleteALLButton;
        public System.Windows.Forms.ListBox listBoxMatrix;
        public System.Windows.Forms.Button buttonAdj;
        public System.Windows.Forms.Button buttonInc;
        public System.Windows.Forms.Button selectButton;
        public System.Windows.Forms.Button chainButton;
        public System.Windows.Forms.Button cycleButton;
        public System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        public System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem импортToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem матрицуИнцидентностиToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem матрицуСмежностиToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem pNGToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem обАвторахToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem задачиТеорииГрафовToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem матрицыИнцидентностиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem матрицыСмежностиToolStripMenuItem;


        #endregion

        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}
