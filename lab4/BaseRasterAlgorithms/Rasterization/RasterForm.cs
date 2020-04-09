using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace BaseRasterAlgorithms
{
    public partial class RasterForm : Form
    {
        private static int PIXEL_VALUE = 1;

        private static int MID_X = 0;
        private static int MID_Y = 0;

        private static HashSet<(int, int)> POINTS = new HashSet<(int, int)>();

        public RasterForm()
        {
            InitializeComponent();
        }

        private void pointsPictureBox_Paint(object sender, PaintEventArgs e)
        {
            int w = 1000;
            int h = 600;

            Font drawFont = new Font("Times New Roman", 10);  
            SolidBrush drawBrush = new SolidBrush(Color.Red);
            int startX = -w / (PIXEL_VALUE * 2) + MID_X;
            int endX = startX + w / PIXEL_VALUE; 
            int padding = 30;
            int full = endX - startX;
            int pause = full / 20;
            int k = 0;
            for (int i = startX; i <= endX; i += pause / 2)
            {
                int newX = (i - startX) * PIXEL_VALUE + padding;
                if (k % 2 == 0)
                    e.Graphics.DrawString(i.ToString(), drawFont, drawBrush, newX - 5, 0);

                e.Graphics.DrawLine(new Pen(Brushes.Yellow), new Point(newX,
                    padding), new Point(newX, h + padding));

                k++;
            }

            k = 0;
            int startY = -h / (PIXEL_VALUE * 2) + MID_Y;
            int endY = startY + h / PIXEL_VALUE;
            full = endY - startY;
            pause = full / 10;

            for (int i = startY; i <= endY; i += pause / 2)
            {
                int newY = (i - startY) * PIXEL_VALUE + padding;
                if (k % 2 == 0)
                    e.Graphics.DrawString(i.ToString(), drawFont, drawBrush, 0, newY - 5);

                e.Graphics.DrawLine(new Pen(Brushes.BlueViolet), new Point(padding,
                    newY), new Point(w + padding, newY));

                k++;
            }

            drawAllPoints(e.Graphics);
            if (startX <= 0 && endX >= 0)
            {
                int newX = -startX * PIXEL_VALUE + padding;
                e.Graphics.DrawLine(new Pen(Brushes.Green), new Point(newX,
                        padding), new Point(newX, h + padding));
            }

            if (startY <= 0 && endY >= 0)
            {
                int newY = -startY * PIXEL_VALUE + padding;
                e.Graphics.DrawLine(new Pen(Brushes.Green), new Point(padding,
                        newY), new Point(w + padding, newY));
            }
        }

        private void drawAllPoints(Graphics g)
        {
            int frameLeftX = MID_X - 500 / PIXEL_VALUE;
            int frameRightX = MID_X + 500 / PIXEL_VALUE;
            int frameLeftY = MID_Y - 300 / PIXEL_VALUE;
            int frameRightY = MID_Y + 300 / PIXEL_VALUE;

            int newP = 25 / PIXEL_VALUE;

            foreach ((int, int) tuple in POINTS)
            {
                if (tuple.Item1 >= frameLeftX && tuple.Item1 < frameRightX &&
                    tuple.Item2 >= frameLeftY && tuple.Item2 < frameRightY)
                {
                    int newX = (tuple.Item1 - frameLeftX) * PIXEL_VALUE + 30;
                    int newY = (tuple.Item2 - frameLeftY) * PIXEL_VALUE + 30;
                    g.FillRectangle(Brushes.Black, newX, newY, PIXEL_VALUE, PIXEL_VALUE);
                }
            }
        }

        private void pointsPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            int frameLength = 500 / PIXEL_VALUE;
            int frameHeight = 300 / PIXEL_VALUE;
            int realX = (e.X - 30) / PIXEL_VALUE - frameLength;
            int realY = (e.Y - 30) / PIXEL_VALUE - frameHeight;

            if (e.Button == MouseButtons.Right)
            {
                if (PIXEL_VALUE != 1)
                {
                    PIXEL_VALUE /= 5;
                    MID_X += realX;
                    MID_Y += realY;
                }
            }
            else
            {
                if (PIXEL_VALUE < 25)
                {
                    PIXEL_VALUE *= 5;
                    MID_X += realX;
                    MID_Y += realY;
                }
            }

            if (PIXEL_VALUE == 1)
            {
                MID_X = 0;
                MID_Y = 0;
            }
            
            pointsPictureBox.Refresh();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            POINTS.Clear();
            pointsPictureBox.Refresh();
        }

        private void stepByStepButton_Click(object sender, EventArgs e)
        {
            long ticks;
            (POINTS, ticks) = Algorithms.StepByStep(int.Parse(tbx.Text), int.Parse(tbY.Text),
                int.Parse(tbX2.Text), int.Parse(tbY2.Text));

            timeLabel.Text = $"Time: {ticks} ms";

            pointsPictureBox.Refresh();
        }

        private void ddaButton_Click(object sender, EventArgs e)
        {
            long ticks;
            (POINTS, ticks) = Algorithms.DDA(int.Parse(tbx.Text), int.Parse(tbY.Text),
            int.Parse(tbX2.Text), int.Parse(tbY2.Text));

            pointsPictureBox.Refresh();

            timeLabel.Text = $"Time: {ticks} ms";
        }

        private void brezenhemButton_Click(object sender, EventArgs e)
        {
            long ticks;
            (POINTS, ticks) = Algorithms.Brezenhem(int.Parse(tbx.Text), int.Parse(tbY.Text),
                int.Parse(tbX2.Text), int.Parse(tbY2.Text));

            pointsPictureBox.Refresh();

            timeLabel.Text = $"Time: {ticks} ms";
        }

        private void brezenhemCircleButton_Click(object sender, EventArgs e)
        {
            long ticks;
            (POINTS, ticks) = Algorithms.BrezenhemCircle(int.Parse(tbx.Text), int.Parse(tbY.Text),
                int.Parse(tbRadius.Text));

            pointsPictureBox.Refresh();

            timeLabel.Text = $"Time: {ticks} ms";
        }
    }
}
