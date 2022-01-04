using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using GraphLib;
using System.Security;

namespace VartumyanGraphTheory
{
    public partial class MainForm : Form
    {
        List<Vertex> V;
        List<Edge> E;
        int[,] AMatrix; //матрица смежности
        int[,] IMatrix; //матрица инцидентности

        int selected1; //выбранные вершины, для соединения линиями
        int selected2;

        public MainForm()
        {
            InitializeComponent();
            V = new List<Vertex>();
            DrawGraph.Bitmap = new Bitmap(sheet.Width, sheet.Height);
            E = new List<Edge>();
            sheet.Image = DrawGraph.Bitmap;
        }

        //кнопка - выбрать вершину
        private void selectButton_Click(object sender, EventArgs e)
        {
            selectButton.Enabled = false;
            drawVertexButton.Enabled = true;
            drawEdgeButton.Enabled = true;
            deleteButton.Enabled = true;
            DrawGraph.СlearSheet();
            DrawGraph.drawALLGraph(V, E);
            sheet.Image = DrawGraph.Bitmap;
            selected1 = -1;
        }

        //кнопка - рисовать вершину
        private void drawVertexButton_Click(object sender, EventArgs e)
        {
            drawVertexButton.Enabled = false;
            selectButton.Enabled = true;
            drawEdgeButton.Enabled = true;
            deleteButton.Enabled = true;
            DrawGraph.СlearSheet();
            DrawGraph.drawALLGraph(V, E);
            sheet.Image = DrawGraph.Bitmap;
        }

        //кнопка - рисовать ребро
        private void drawEdgeButton_Click(object sender, EventArgs e)
        {
            drawEdgeButton.Enabled = false;
            selectButton.Enabled = true;
            drawVertexButton.Enabled = true;
            deleteButton.Enabled = true;
            DrawGraph.СlearSheet();
            DrawGraph.drawALLGraph(V, E);
            sheet.Image = DrawGraph.Bitmap;
            selected1 = -1;
            selected2 = -1;
        }

        //кнопка - удалить элемент
        private void deleteButton_Click(object sender, EventArgs e)
        {
            deleteButton.Enabled = false;
            selectButton.Enabled = true;
            drawVertexButton.Enabled = true;
            drawEdgeButton.Enabled = true;
            DrawGraph.СlearSheet();
            DrawGraph.drawALLGraph(V, E);
            sheet.Image = DrawGraph.Bitmap;
        }

        //кнопка - удалить граф
        private void deleteALLButton_Click(object sender, EventArgs e)
        {
            selectButton.Enabled = true;
            drawVertexButton.Enabled = true;
            drawEdgeButton.Enabled = true;
            deleteButton.Enabled = true;
            const string message = "Вы действительно хотите полностью удалить граф?";
            const string caption = "Удаление";
            var MBSave = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (MBSave == DialogResult.Yes)
            {
                V.Clear();
                E.Clear();
                DrawGraph.СlearSheet();
                sheet.Image = DrawGraph.Bitmap;
            }
        }

        //кнопка - матрица смежности
        private void buttonAdj_Click(object sender, EventArgs e)
        {
            createAdjAndOut();
        }

        //кнопка - матрица инцидентности 
        private void buttonInc_Click(object sender, EventArgs e)
        {
            createIncAndOut();
        }

        private void sheet_MouseClick(object sender, MouseEventArgs e)
        {
            //нажата кнопка "выбрать вершину", ищем степень вершины
            if (selectButton.Enabled == false)
            {
                for (int i = 0; i < V.Count; i++)
                {
                    if (Math.Pow((V[i].x - e.X), 2) + Math.Pow((V[i].y - e.Y), 2) <= DrawGraph.R * DrawGraph.R)
                    {
                        if (selected1 != -1)
                        {
                            selected1 = -1;
                            DrawGraph.СlearSheet();
                            DrawGraph.drawALLGraph(V, E);
                            sheet.Image = DrawGraph.Bitmap;
                        }
                        if (selected1 == -1)
                        {
                            
                            DrawGraph.DrawSelectedVertex(V[i].x, V[i].y);
                            selected1 = i;
                            sheet.Image = DrawGraph.Bitmap;
                            createAdjAndOut();
                            listBoxMatrix.Items.Clear();
                            int degree = 0;
                            for (int j = 0; j < V.Count; j++)
                                degree += AMatrix[selected1, j];
                            listBoxMatrix.Items.Add("Степень вершины №" + (selected1 + 1) + " равна " + degree);
                            break;
                        }
                    }
                }
            }
            //нажата кнопка "рисовать вершину"
            if (drawVertexButton.Enabled == false)
            {
                V.Add(new Vertex(e.X, e.Y));
                DrawGraph.DrawVertex(e.X, e.Y, V.Count.ToString());
                sheet.Image = DrawGraph.Bitmap;
            }
            //нажата кнопка "рисовать ребро"
            if (drawEdgeButton.Enabled == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    for (int i = 0; i < V.Count; i++)
                    {
                        if (Math.Pow((V[i].x - e.X), 2) + Math.Pow((V[i].y - e.Y), 2) <= DrawGraph.R * DrawGraph.R)
                        {
                            if (selected1 == -1)
                            {
                                DrawGraph.DrawSelectedVertex(V[i].x, V[i].y);
                                selected1 = i;
                                sheet.Image = DrawGraph.Bitmap;
                                break;
                            }
                            if (selected2 == -1)
                            {
                                DrawGraph.DrawSelectedVertex(V[i].x, V[i].y);
                                selected2 = i;
                                E.Add(new Edge(selected1, selected2));
                                DrawGraph.drawEdge(V[selected1], V[selected2], E[E.Count - 1], E.Count - 1);
                                selected1 = -1;
                                selected2 = -1;
                                sheet.Image = DrawGraph.Bitmap;
                                break;
                            }
                        }
                    }
                }
                if (e.Button == MouseButtons.Right)
                {
                    if ((selected1 != -1) &&
                        (Math.Pow((V[selected1].x - e.X), 2) + Math.Pow((V[selected1].y - e.Y), 2) <= DrawGraph.R * DrawGraph.R))
                    {
                        DrawGraph.DrawVertex(V[selected1].x, V[selected1].y, (selected1 + 1).ToString());
                        selected1 = -1;
                        sheet.Image = DrawGraph.Bitmap;
                    }
                }
            }
            //нажата кнопка "удалить элемент"
            if (deleteButton.Enabled == false)
            {
                bool flag = false; //удалили ли что-нибудь по ЭТОМУ клику
                //ищем, возможно была нажата вершина
                for (int i = 0; i < V.Count; i++)
                {
                    if (Math.Pow((V[i].x - e.X), 2) + Math.Pow((V[i].y - e.Y), 2) <= DrawGraph.R * DrawGraph.R)
                    {
                        for (int j = 0; j < E.Count; j++)
                        {
                            if ((E[j].V1 == i) || (E[j].V2 == i))
                            {
                                E.RemoveAt(j);
                                j--;
                            }
                            else
                            {
                                if (E[j].V1 > i) E[j].V1--;
                                if (E[j].V2 > i) E[j].V2--;
                            }
                        }
                        V.RemoveAt(i);
                        flag = true;
                        break;
                    }
                }
                //ищем, возможно было нажато ребро
                if (!flag)
                {
                    for (int i = 0; i < E.Count; i++)
                    {
                        if (E[i].V1 == E[i].V2) //если это петля
                        {
                            if ((Math.Pow((V[E[i].V1].x - DrawGraph.R - e.X), 2) + Math.Pow((V[E[i].V1].y - DrawGraph.R - e.Y), 2) <= ((DrawGraph.R + 2) * (DrawGraph.R + 2))) &&
                                (Math.Pow((V[E[i].V1].x - DrawGraph.R - e.X), 2) + Math.Pow((V[E[i].V1].y - DrawGraph.R - e.Y), 2) >= ((DrawGraph.R - 2) * (DrawGraph.R - 2))))
                            {
                                E.RemoveAt(i);
                                flag = true;
                                break;
                            }
                        }
                        else //не петля
                        {
                            if (((e.X - V[E[i].V1].x) * (V[E[i].V2].y - V[E[i].V1].y) / (V[E[i].V2].x - V[E[i].V1].x) + V[E[i].V1].y) <= (e.Y + 4) &&
                                ((e.X - V[E[i].V1].x) * (V[E[i].V2].y - V[E[i].V1].y) / (V[E[i].V2].x - V[E[i].V1].x) + V[E[i].V1].y) >= (e.Y - 4))
                            {
                                if ((V[E[i].V1].x <= V[E[i].V2].x && V[E[i].V1].x <= e.X && e.X <= V[E[i].V2].x) ||
                                    (V[E[i].V1].x >= V[E[i].V2].x && V[E[i].V1].x >= e.X && e.X >= V[E[i].V2].x))
                                {
                                    E.RemoveAt(i);
                                    flag = true;
                                    break;
                                }
                            }
                        }
                    }
                }
                //если что-то было удалено, то обновляем граф на экране
                if (flag)
                {
                    DrawGraph.СlearSheet();
                    DrawGraph.drawALLGraph(V, E);
                    sheet.Image = DrawGraph.Bitmap;
                }
            }
        }

        //создание матрицы смежности и вывод в листбокс
        private void createAdjAndOut()
        {
            AMatrix = new int[V.Count, V.Count];
            DrawGraph.fillAdjacencyMatrix(V.Count, E, AMatrix);
            listBoxMatrix.Items.Clear();
            string sOut = "    ";
            for (int i = 0; i < V.Count; i++)
                sOut += (i + 1) + " ";
            listBoxMatrix.Items.Add(sOut);
            for (int i = 0; i < V.Count; i++)
            {
                sOut = (i + 1) + " | ";
                for (int j = 0; j < V.Count; j++)
                    sOut += AMatrix[i, j] + " ";
                listBoxMatrix.Items.Add(sOut);
            }
        }


        private void SaveAdj(object sender, EventArgs e)
        {
            AMatrix = new int[V.Count, V.Count];
            DrawGraph.fillAdjacencyMatrix(V.Count, E, AMatrix);
            string sOut = "    ";
            for (int i = 0; i < V.Count; i++)
                sOut += (i + 1) + " ";
            sOut += "\n";
            for (int i = 0; i < V.Count; i++)
            {
                sOut += (i + 1) + " | ";
                for (int j = 0; j < V.Count; j++)
                    sOut += AMatrix[i, j] + " ";
                sOut += "\n";
            }
            SaveFileDialog savedialog = new SaveFileDialog();
            savedialog.Title = "Сохранить матрицу cмежности как...";
            savedialog.OverwritePrompt = true;
            savedialog.CheckPathExists = true;
            savedialog.Filter = "Image Files(*.txt)|*.txt";
            savedialog.ShowHelp = true;
            if (savedialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    System.IO.File.WriteAllText(savedialog.FileName, sOut);
                }
                catch
                {
                    MessageBox.Show("Невозможно сохранить файл", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //создание матрицы инцидентности и вывод в листбокс
        private void createIncAndOut()
        {
            if (E.Count > 0)
            {
                IMatrix = new int[V.Count, E.Count];
                DrawGraph.fillIncidenceMatrix(V.Count, E, IMatrix);
                listBoxMatrix.Items.Clear();
                string sOut = "    ";
                for (int i = 0; i < E.Count; i++)
                    sOut += (char)('a' + i) + " ";
                listBoxMatrix.Items.Add(sOut);
                for (int i = 0; i < V.Count; i++)
                {
                    sOut = (i + 1) + " | ";
                    for (int j = 0; j < E.Count; j++)
                        sOut += IMatrix[i, j] + " ";
                    listBoxMatrix.Items.Add(sOut);
                }
            }
            else
                listBoxMatrix.Items.Clear();
        }

        public void SaveInc(object sender, EventArgs e)
        {
            IMatrix = new int[V.Count, E.Count];
            DrawGraph.fillIncidenceMatrix(V.Count, E, IMatrix);
            string sOut = "    ";
            for (int i = 0; i < E.Count; i++)
                sOut += (char)('a' + i) + " ";
            sOut += "\n";
            for (int i = 0; i < V.Count; i++)
            {
                sOut += (i + 1) + " | ";
                for (int j = 0; j < E.Count; j++)
                    sOut += IMatrix[i, j] + " ";
                sOut += "\n";
            }
            SaveFileDialog savedialog = new SaveFileDialog();
            savedialog.Title = "Сохранить матрицу инцидентности как...";
            savedialog.OverwritePrompt = true;
            savedialog.CheckPathExists = true;
            savedialog.Filter = "Image Files(*.txt)|*.txt";
            savedialog.ShowHelp = true;
            if (savedialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    System.IO.File.WriteAllText(savedialog.FileName, sOut);
                }
                catch
                {
                    MessageBox.Show("Невозможно сохранить файл", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //поиск элементарных цепей
        private void chainButton_Click(object sender, EventArgs e)
        {
            listBoxMatrix.Items.Clear();
            //1-white 2-black
            int[] color = new int[V.Count];
            for (int i = 0; i < V.Count - 1; i++)
                for (int j = i + 1; j < V.Count; j++)
                {
                    for (int k = 0; k < V.Count; k++)
                        color[k] = 1;
                    DFSchain(i, j, E, color, (i + 1).ToString());
                }
        }

        //обход в глубину. поиск элементарных цепей. (1-white 2-black)
        private void DFSchain(int u, int endV, List<Edge> E, int[] color, string s)
        {
            //вершину не следует перекрашивать, если u == endV (возможно в нее есть несколько путей)
            if (u != endV)  
                color[u] = 2;
            else
            {
                listBoxMatrix.Items.Add(s);
                return;
            }
            for (int w = 0; w < E.Count; w++)
            {
                if (color[E[w].V2] == 1 && E[w].V1 == u)
                {
                    DFSchain(E[w].V2, endV, E, color, s + "-" + (E[w].V2 + 1).ToString());
                    color[E[w].V2] = 1;
                }
                else if (color[E[w].V1] == 1 && E[w].V2 == u)
                {
                    DFSchain(E[w].V1, endV, E, color, s + "-" + (E[w].V1 + 1).ToString());
                    color[E[w].V1] = 1;
                }
            }
        }

        //поиск элементарных циклов
        private void cycleButton_Click(object sender, EventArgs e)
        {
            listBoxMatrix.Items.Clear();
            //1-white 2-black
            int[] color = new int[V.Count];
            for (int i = 0; i < V.Count; i++)
            {
                for (int k = 0; k < V.Count; k++)
                    color[k] = 1;
                List<int> cycle = new List<int>();
                cycle.Add(i + 1);
                DFScycle(i, i, E, color, -1, cycle);
            }
        }

        //обход в глубину. поиск элементарных циклов. (1-white 2-black)
        //Вершину, для которой ищем цикл, перекрашивать в черный не будем. Поэтому, для избежания неправильной
        //работы программы, введем переменную unavailableEdge, в которой будет хранится номер ребра, исключаемый
        //из рассмотрения при обходе графа. В действительности это необходимо только на первом уровне рекурсии,
        //чтобы избежать вывода некорректных циклов вида: 1-2-1, при наличии, например, всего двух вершин.

        private void DFScycle(int u, int endV, List<Edge> E, int[] color, int unavailableEdge, List<int> cycle)
        {
            //если u == endV, то эту вершину перекрашивать не нужно, иначе мы в нее не вернемся, а вернуться необходимо
            if (u != endV)
                color[u] = 2;
            else
            {
                if (cycle.Count >= 2)
                {
                    cycle.Reverse();
                    string s = cycle[0].ToString();
                    for (int i = 1; i < cycle.Count; i++)
                        s += "-" + cycle[i].ToString();
                    bool flag = false; //есть ли палиндром для этого цикла графа в листбоксе?
                    for (int i = 0; i < listBoxMatrix.Items.Count; i++)
                        if (listBoxMatrix.Items[i].ToString() == s)
                        {
                            flag = true;
                            break;
                        }
                    if (!flag)
                    {
                        cycle.Reverse();
                        s = cycle[0].ToString();
                        for (int i = 1; i < cycle.Count; i++)
                            s += "-" + cycle[i].ToString();
                        listBoxMatrix.Items.Add(s);
                    }
                    return;
                }
            }
            for (int w = 0; w < E.Count; w++)
            {
                if (w == unavailableEdge)
                    continue;
                if (color[E[w].V2] == 1 && E[w].V1 == u)
                {
                    List<int> cycleNEW = new List<int>(cycle);
                    cycleNEW.Add(E[w].V2 + 1);
                    DFScycle(E[w].V2, endV, E, color, w, cycleNEW);
                    color[E[w].V2] = 1;
                }
                else if (color[E[w].V1] == 1 && E[w].V2 == u)
                {
                    List<int> cycleNEW = new List<int>(cycle);
                    cycleNEW.Add(E[w].V1 + 1);
                    DFScycle(E[w].V1, endV, E, color, w, cycleNEW);
                    color[E[w].V1] = 1;
                }
            }
        }

        //О программе
        private void about_Click(object sender, EventArgs e)
        {
            aboutForm FormAbout = new aboutForm();
            FormAbout.ShowDialog();
        }

        private void aboutProg_Click(object sender, EventArgs e)
        {
            AboutProgram FormAbout = new AboutProgram();
            FormAbout.ShowDialog();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (sheet.Image != null)
            {
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title = "Сохранить картинку как...";
                savedialog.OverwritePrompt = true;
                savedialog.CheckPathExists = true;
                savedialog.Filter = "Image Files(*.PNG)|*.PNG";
                savedialog.ShowHelp = true;
                if (savedialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        sheet.Image.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void матрицыСмежностиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog opendialog = new OpenFileDialog();
            opendialog.Title = "Импорт как: матрица смежности";
            opendialog.CheckFileExists = true;
            opendialog.CheckPathExists = true;
            opendialog.Filter = "Text files (*.txt)|*.txt";
            opendialog.ShowHelp = true;

            if (opendialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    listBoxMatrix.Items.Clear();
                    var sr = new StreamReader(opendialog.FileName);
                    while (!sr.EndOfStream)
                        listBoxMatrix.Items.Add(sr.ReadLine());
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void матрицыИнцидентностиToolStripMenuItem_Click(object sender, EventArgs e)
        {
             
            OpenFileDialog opendialog = new OpenFileDialog();
            opendialog.Title = "Импорт как: матрица инцидентности";
            opendialog.CheckFileExists = true;
            opendialog.CheckPathExists = true;
            opendialog.Filter = "Text files (*.txt)|*.txt";
            opendialog.ShowHelp = true;

            if (opendialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    listBoxMatrix.Items.Clear();
                    var sr = new StreamReader(opendialog.FileName);
                    while (!sr.EndOfStream)
                        listBoxMatrix.Items.Add(sr.ReadLine());
                    
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }
        private void parse_input()
        { 
        
        }
    }
}
