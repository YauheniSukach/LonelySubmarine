using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication7
{
    public partial class Help : Form
    {
        Player pl = new Player(0, 400);
        List<Clouds> cloud = new List<Clouds>();
        Random rand = new Random();
        public Help()
        {
            InitializeComponent();
            this.Text = "HELP";
            this.Size = new Size(588, 658);
            this.BackgroundImage = new Bitmap("background.png");
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Paint += new PaintEventHandler(Program_Paint);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.DoubleBuffered = true;
            this.Controls.Add(pl.pictbox);
            Button newbtn = new Button();
            Timer timer, timer1;
            timer = new Timer();
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
            timer.Interval = 1;
            timer1 = new Timer();
            timer1.Tick += new EventHandler(Timer_Tick1);
            timer1.Start();
            timer1.Interval = 4000;
            newbtn.Click += Newbtn_Click;
            newbtn.Image = new Bitmap("red.jpg");
            newbtn.Size = new Size(100, 40);
            newbtn.Location = new Point(220, 390);
            newbtn.Text = "BACK";
            this.Controls.Add(newbtn);
        }

        private void Newbtn_Click(object sender, EventArgs e)
        {
            Hide();
            Form2 f = new Form2();
            f.ShowDialog();
            Close();
        }

        public void Timer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < cloud.Count; i++)
            {
                cloud[i].Move_Left();
            }
        }
        public void Timer_Tick1(object sender, EventArgs e)
        {
            cloud.Add(new Clouds(rand.Next(590, 600), rand.Next(65, 190)));
            this.Controls.Add(cloud[cloud.Count - 1].pictbox);
        }
        void Program_Paint(object sender, PaintEventArgs e)
        {
            string Move = "MOVE UP - ↑";
            string Move3 = "MOVE DOWN - ↓";
            string Pause = "PAUSE - P";
            string game = "LONELY SUBMARINE";
            e.Graphics.DrawString(game, new Font("Arial", 30, FontStyle.Underline), Brushes.Green, new Point(80, 20));
            e.Graphics.DrawString(Move, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(185, 250));
            e.Graphics.DrawString(Move3, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(185, 300));
            e.Graphics.DrawString(Pause, new Font("Arial", 20, FontStyle.Regular), Brushes.Red, new Point(185, 350));

        }
    }
}
