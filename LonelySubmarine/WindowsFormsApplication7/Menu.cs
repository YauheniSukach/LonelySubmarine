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
    public partial class Form2 : Form
    {
        Player pl = new Player(15,400);
        List<Clouds> cloud = new List<Clouds>();
        Random rand = new Random();
        public Form2()
        {
            InitializeComponent();
            this.Text = "MENU";
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
            newbtn.Location = new Point(135, 150);
            newbtn.BackColor = Color.Red;
            newbtn.Size = new Size(300, 100);
            newbtn.Text = "NEW GAME";
            Button newbtn1 = new Button();
            newbtn1.Click += Newbtn_Click1;
            newbtn1.Location = new Point(208, 350);
            newbtn1.BackColor = Color.Red; 
            newbtn1.Size = new Size(150, 100);
            newbtn1.Text = "EXIT";
            Button newbtn2 = new Button();
            newbtn2.Click += Newbtn2_Click;
            newbtn2.Location = new Point(183, 250);
            newbtn2.BackColor = Color.Red;
            newbtn2.Size = new Size(200, 100);
            newbtn2.Text = "HELP";
            Controls.Add(newbtn);
            Controls.Add(newbtn1);
            Controls.Add(newbtn2);
        }
        private void Newbtn_Click(object sender, EventArgs e)
        {
            Hide();
            Game f = new Game();
            f.ShowDialog();
            Close();
        }
        private void Newbtn_Click1(object sender, EventArgs e)
        {
            Close();
        }
        private void Newbtn2_Click(object sender, EventArgs e)
        {
            Hide();
            Help f = new Help();
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
            string game = "LONELY SUBMARINE";

            e.Graphics.DrawString(game, new Font("Arial", 30, FontStyle.Underline), Brushes.Green, new Point(80, 20));

        }

     }
}
