using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public struct MineCell
    {
        public bool Mine;
        public Color cellColor;
        public Image? img;

        public MineCell()
        {
            cellColor = Color.Gray;
            Mine = false;
            img = null;
        }
    }

    public partial class Form1 : Form
    {
        Graphics? graphics = null;
        Pen? brush;
        Pen? OutlineBrush;

        readonly float outlineWidth = 20;
        readonly float brushWidth = 5;
        readonly Size FieldSize = new Size(1230, 1230);

        // Changeble -----------------------
        int FieldWidth  = 4;    //Number of cells
        int FieldHeight = 4;    //Number of cells

        int NumberOfMines = 0;
        //Chengeble -----------------------

        Random r = new();
        Bitmap flag = null;

        //Data Tables
        MineCell[,] Mines;


        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            flag = Properties.Resources.flag;

            RegenerateMineField();

            brush = new Pen(Color.Black, brushWidth);
            OutlineBrush = new Pen(Color.Black, outlineWidth);

        }

        private void RegenerateMineField()
        {

            Mines = new MineCell[FieldWidth, FieldHeight];
            
            for (int i = 0; i < (int)MaximumMines.Value; i++)
            {
                GenerateBomb();
            }
        }

        private void GenerateBomb()
        {
            int x = r.Next(0, FieldWidth);
            int y = r.Next(0, FieldHeight);

            if (Mines[y, x].Mine)
            {
                GenerateBomb();
            }
            else
            {
                var m = Mines[y, x];
                m.Mine = true;
                Mines[y, x] = m;
            }
        }

        private void button1_Click(object sender, EventArgs e)  // Generate Button
        {
            FieldHeight = (int)fieldHeight.Value;
            FieldWidth = (int)fieldWidth.Value;

            NumberOfMines = (int)MaximumMines.Value;

            RegenerateMineField();
            
            this.Refresh();
        }

        private void panel1_Click(object sender, EventArgs e) // Clearing handling
        {
            MouseEventArgs mouse = (MouseEventArgs)e;

            int X, Y;
            MouseLocationEx(e, out X, out Y);

            if (mouse.Button == MouseButtons.Left)
            {
                if (!Mines[Y,X].Mine)
                {
                    Mines[Y, X] = new()
                    {
                        Mine = false,
                        cellColor = Color.White,
                        img = NumberGenerator.GetNumber((byte)Mines.GetSurroundingCells(new Point(X, Y), new Size(FieldWidth, FieldHeight)).Length, new Size(FieldSize.Width / FieldWidth, FieldSize.Height / FieldHeight))
                    };

                }
                else
                {
                    MessageBox.Show("You Lose!");
                    RegenerateMineField();
                }
            }else if (mouse.Button == MouseButtons.Right)
            {
                var m = Mines[Y, X];
                if (m.img == null)
                {
                    m.img = flag;
                }else if (m.img != null)
                {
                    if (m.img.Equals(flag))
                    {
                        m.img = null;
                    }
                }

                Mines[Y, X] = m;
                
            }
            if (CheckWin())
            {
                MessageBox.Show("You win!");
                RegenerateMineField();
            }

            this.Refresh();

        }

        private bool CheckWin()
        {
            int flaggedMines = 0;
            int flaggedNotMines = 0;

            for (int y = 0; y < Mines.GetLength(0); y++)
            {
                for (int x = 0; x < Mines.GetLength(1); x++)
                {
                    if (Mines[y,x].Mine)
                    {
                        if (Mines[y,x].img != null)
                        {
                            if (Mines[y, x].img.Equals(flag))
                            {
                                flaggedMines++;
                            }
                        }
                    }
                    else
                    {
                        if (Mines[y, x].img != null)
                        {
                            if (Mines[y, x].img.Equals(flag))
                            {
                                flaggedNotMines++;
                            }
                        }
                    }
                }
            }

            if (flaggedMines == NumberOfMines && flaggedNotMines == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void MouseLocationEx(EventArgs e, out int X, out int Y)
        {
            MouseEventArgs args = (MouseEventArgs)e;

            float SpacingX = FieldSize.Width / FieldWidth;
            float SpacingY = FieldSize.Height / FieldHeight;
            X = CheckCell(args.X, SpacingX) - 1;
            Y = CheckCell(args.Y, SpacingY) - 1;
        }

        private int CheckCell(int args, float Spacing)
        {
            int X = -1;
            float Xpos = brushWidth + 0;
            for (int i = 1; i <= FieldWidth; i++)
            {
                if (args >= Xpos && args <= Xpos + Spacing)
                {
                    X = i;
                }
                Xpos += Spacing;
            }
            if (X == -1)
            {
                MessageBox.Show("Fatal error", "your mom is gay");
            }

            return X;
        }



        private void panel1_Paint(object sender, PaintEventArgs e) // Painter
        {
            graphics = e.Graphics;

            DrawOutline(OutlineBrush, graphics); // Outline Box
            DrawCellsX(brush, graphics); // x axis lines
            DrawCellsY(brush, graphics); // y axis lines
            ColorCells(graphics); // cell colorer
            
        }

        private void DrawCellsX(Pen b, Graphics g)
        {
            PointF startingPoint = new PointF(0, 0);

            float Spacing = ((float)FieldSize.Width) / (float)FieldWidth;

            for (int i = 1; i <= FieldWidth-1; i++)
            {
                PointF top = new PointF(Spacing * i, startingPoint.Y);
                PointF bottom = new PointF(Spacing * i, FieldSize.Height);

                g.DrawLine(b, top, bottom);
            }
        }
        private void DrawCellsY(Pen b, Graphics g)
        {
            PointF startingPoint = new PointF(0, 0);

            float Spacing = ((float)FieldSize.Height) / (float)FieldHeight;

            for (int i = 1; i <= FieldHeight - 1; i++)
            {
                PointF left = new PointF(startingPoint.X, Spacing * i);
                PointF right = new PointF(FieldSize.Width, Spacing * i);

                g.DrawLine(b, left, right);
            }
        }

        private void DrawOutline(Pen brush, Graphics g)
        {

            Point _start = new Point(0, 0);
            Point _end = new Point(FieldSize.Width, 0);

            g.DrawLine(brush, _start, _end);                                                                //Top
            g.DrawLine(brush, _start, new Point(0, FieldSize.Height));                                      //Left
            g.DrawLine(brush, 0, FieldSize.Height, FieldSize.Height, FieldSize.Width);                      //Bottom
            g.DrawLine(brush, new Point(FieldSize.Width, 0), new Point(FieldSize.Width, FieldSize.Height)); // Right
        }
        private void ColorCells(Graphics g)
        {
            for (int y = 0; y < Mines.GetLength(0); y++)
            {
                for (int x = 0; x < Mines.GetLength(1); x++)
                {
                    ColorCell(g, Mines[y, x], new Tuple<int, int>(y, x));
                }
            }
        } // goes through cells
        private void ColorCell(Graphics g, MineCell mineCell, Tuple<int, int> coords)
        {
            float xSpacing = FieldSize.Width / FieldWidth;
            float ySpacing = FieldSize.Height / FieldHeight;

            PointF startingPoint = new PointF((xSpacing * coords.Item2 + brushWidth), (ySpacing * coords.Item1 + brushWidth));
            SizeF size = new SizeF(xSpacing-brushWidth, ySpacing-brushWidth);

            g.FillRectangle(new SolidBrush(mineCell.cellColor), startingPoint.X, startingPoint.Y, size.Width, size.Height);

            if (mineCell.img != null)
            {
                Bitmap image = new(mineCell.img, (int)xSpacing, (int)ySpacing);
                g.DrawImage(image, startingPoint);
            }

        } // Colors cells

    }
    public static class Extensions
    {
        public static Tuple<MineCell, Point>[] GetSurroundingCells(this MineCell[,] mines, Point coords, Size MineFieldSize)
        {
            List<Tuple<MineCell, Point>> SurroundingCells = new();

            if (coords.X > 0)
            {
                if (mines[coords.Y, coords.X - 1].Mine)
                {
                    SurroundingCells.Add(new Tuple<MineCell, Point>(mines[coords.Y, coords.X - 1], new Point(coords.X - 1, coords.Y)));
                }
            }
            if (coords.X < MineFieldSize.Width-1)
            {
                if (mines[coords.Y, coords.X + 1].Mine)
                {
                    SurroundingCells.Add(new Tuple<MineCell, Point>(mines[coords.Y, coords.X + 1], new Point(coords.X + 1, coords.Y)));
                }
            }

            if (coords.Y > 0)
            {
                if (mines[coords.Y - 1, coords.X].Mine)
                {
                    SurroundingCells.Add(new Tuple<MineCell, Point>(mines[coords.Y - 1, coords.X], new Point(coords.X, coords.Y - 1)));
                }
            }
            if (coords.Y < MineFieldSize.Height-1)
            {
                if (mines[coords.Y + 1, coords.X].Mine)
                {
                    SurroundingCells.Add(new Tuple<MineCell, Point>(mines[coords.Y + 1, coords.X], new Point(coords.X, coords.Y + 1)));
                }
            }



            if (coords.X > 0)
            {
                if (coords.Y > 0)
                {
                    if (mines[coords.Y - 1, coords.X - 1].Mine)
                    {
                        SurroundingCells.Add(new Tuple<MineCell, Point>(mines[coords.Y - 1, coords.X - 1], new Point(coords.X - 1, coords.Y - 1)));
                    }
                }
                if (coords.Y < MineFieldSize.Height-1)
                {
                    if (mines[coords.Y + 1, coords.X - 1].Mine)
                    {
                        SurroundingCells.Add(new Tuple<MineCell, Point>(mines[coords.Y + 1, coords.X - 1], new Point(coords.X - 1, coords.Y + 1)));
                    }
                }
            }

            if (coords.X < MineFieldSize.Width-1)
            {
                if (coords.Y > 0)
                {
                    if (mines[coords.Y - 1, coords.X + 1].Mine)
                    {
                        SurroundingCells.Add(new Tuple<MineCell, Point>(mines[coords.Y - 1, coords.X + 1], new Point(coords.X + 1, coords.Y - 1)));
                    }
                }
                if (coords.Y < MineFieldSize.Height-1)
                {
                    if (mines[coords.Y + 1, coords.X + 1].Mine)
                    {
                        SurroundingCells.Add(new Tuple<MineCell, Point>(mines[coords.Y + 1, coords.X + 1], new Point(coords.X + 1, coords.Y + 1)));
                    }
                }
            }

            return SurroundingCells.ToArray();
        }
    }
    class NumberGenerator
    {
        public static Bitmap GetNumber(byte number, Size picSize)
        {
            Bitmap bmp = new Bitmap(1000, 1000);
            Graphics g = Graphics.FromImage(bmp);
            g.DrawString(number.ToString(), new Font(FontFamily.GenericSerif, 300), Brushes.Black, 0, 0);

            bmp.SetResolution(picSize.Width, picSize.Height);

            return bmp;
        }
    }
}
