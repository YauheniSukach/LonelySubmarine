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
    public partial class Game : Form
    {

        Player pl = new Player(15, 400);
        Button newbtn = new Button();
        Button newbtn1 = new Button();
        Button newbtn2 = new Button();
        List<Health> health = new List<Health>();
        List<Clouds> cloud = new List<Clouds>();
        List<Rockets> rocket = new List<Rockets>();
        List<Coins> coin = new List<Coins>();
        Random rand = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
        Timer timer = new Timer();
        Timer timer1 = new Timer();
        Timer timer2 = new Timer();
        Timer timer3 = new Timer();
        Timer timer4 = new Timer();
        int score = 0;
        int bestscore = 0;
        bool flg;
        public Game()
        {

            InitializeComponent();

            this.Text = "GAME";
            this.Size = new Size(588, 658);
            this.Controls.Add(pl.pictbox);
            this.BackgroundImage = new Bitmap("background.png");
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.DoubleBuffered = true;
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            this.Paint += new PaintEventHandler(Program_Paint);
            health.Add(new Health(460, 6));
            health.Add(new Health(499, 6));
            health.Add(new Health(535, 6));
            add();
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
            timer.Interval = 5;
            timer1.Tick += new EventHandler(Timer_Tick1);
            timer1.Start();
            timer1.Interval = 12000;
            timer2.Tick += new EventHandler(Timer_Tick2);
            timer2.Start();
            timer2.Interval = 2500;
            timer3.Tick += new EventHandler(Timer_Tick3);
            timer3.Start();
            timer3.Interval = 4000;
            timer4.Tick += new EventHandler(Timer_Tick4);
            timer4.Start();
            timer4.Interval = 1;
            newbtn.Size = new Size(200, 100);
            newbtn.BackColor = Color.Red;
            newbtn.Location = new Point(195, 250);
            newbtn.Text = "TRY AGAIN";
            newbtn.Click += Newbtn_Click;
            newbtn1.Size = new Size(100, 50);
            newbtn1.BackColor = Color.Red;
            newbtn1.Location = new Point(235, 6);
            newbtn1.Text = "CONTINUE";
            newbtn1.Click += Newbtn1_Click;
            newbtn2.Size = new Size(150, 100);
            newbtn2.BackColor = Color.Red;
            newbtn2.Location = new Point(220, 350);
            newbtn2.Text = "EXIT";
            newbtn2.Click += Newbtn2_Click;
        }

        private void Newbtn2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Newbtn1_Click(object sender, EventArgs e)
        {
            timer.Start();
            timer1.Start();
            timer2.Start();
            timer3.Start();
            this.Controls.Remove(newbtn1);
        }

        private void Newbtn_Click(object sender, EventArgs e)
        {
            Hide();
            Game gm = new Game();
            gm.ShowDialog();
            Close();
        }

        public void Timer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < cloud.Count; i++)
            {
                cloud[i].Move_Left();
            }
            for (int i = 0; i < rocket.Count; i++)
            {
                rocket[i].Move_Left();
            }
            for (int j = 0; j < coin.Count; j++)
            {
                coin[j].Move_Left();
            }
            CollisionWithRockets();
            CollisionWithCoins();
            Invalidate();
        }
        public void Timer_Tick1(object sender, EventArgs e)
        {
            cloud.Add(new Clouds(rand.Next(590, 600), rand.Next(30, 190)));
            this.Controls.Add(cloud[cloud.Count - 1].pictbox);
        }
        public void Timer_Tick2(object sender, EventArgs e)
        {
            rocket.Add(new Rockets(rand.Next(590, 600), rand.Next(300, 600)));
            this.Controls.Add(rocket[rocket.Count - 1].pictbox);
        }
        public void Timer_Tick3(object sender, EventArgs e)
        {
            coin.Add(new Coins(rand.Next(590, 600), rand.Next(300, 600)));
            this.Controls.Add(coin[coin.Count - 1].pictbox);
        }
        public void Timer_Tick4(object sender,EventArgs e)
        {
            for (int t = 0; t < cloud.Count; t++)
            {
                if (cloud[t].pictbox.Location.X<-110)
                {
                    this.Controls.Remove(cloud[t].pictbox);
                    cloud.Remove(cloud[t]);
                }
            }
            for (int i = 0; i < coin.Count; i++)
            {
                if (coin[i].pictbox.Location.X<-50)
                {
                    this.Controls.Remove(coin[i].pictbox);
                    coin.Remove(coin[i]);
                }
            }
            for (int j = 0; j < rocket.Count; j++)
            {
                if (rocket[j].pictbox.Location.X<-50)
                {
                    this.Controls.Remove(rocket[j].pictbox);
                    rocket.Remove(rocket[j]);
                }
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) pl.move_up();
            if (e.KeyCode == Keys.Down) pl.move_down();
            if (e.KeyCode == Keys.P)  
            {
                timer.Stop();
                timer1.Stop();
                timer2.Stop();
                timer3.Stop();
                this.Controls.Add(newbtn1);
            }
        }

        public void CollisionWithCoins()
        {
            for (int i = 0; i < coin.Count; i++)

                if (pl.pictbox.Right >= coin[i].pictbox.Left && pl.pictbox.Top <= coin[i].pictbox.Bottom
                    && pl.pictbox.Bottom >= coin[i].pictbox.Top)
                {
                    this.Controls.Remove(coin[i].pictbox);
                    coin.Remove(coin[i]);
                    score = score + 10;
                }
        }
      public void CollisionWithRockets()
        {
            for (int i = health.Count-1; i >=0; i--)
            {
                for (int j = 0; j < rocket.Count; j++)
                {
                    if (pl.pictbox.Right >= rocket[j].pictbox.Left && pl.pictbox.Top <= rocket[j].pictbox.Bottom && pl.pictbox.Bottom >= rocket[j].pictbox.Top)
                    {

                        this.Controls.Remove(rocket[j].pictbox);
                        rocket.Remove(rocket[j]);
                        this.Controls.Remove(health[i].pictbox);
                        health.Remove(health[i]);
                        if (i == 0)
                        {
                  
                            this.Paint += new PaintEventHandler(Program_Paint1);
                            this.Controls.Clear();
                            this.Controls.Remove(pl.pictbox);
                            this.Controls.Add(newbtn);
                            this.Controls.Add(newbtn2);
                            timer.Stop();
                            timer1.Stop();
                            timer2.Stop();
                            timer3.Stop();
                           
                        }
                    }
                }
            }
        }
        public void add()
        {
            for(int i = 0; i < health.Count; i++)
            {
                this.Controls.Add(health[i].pictbox);
            }
        }
        void Program_Paint(object sender, PaintEventArgs e)
        {
            if (!flg)
            {
                string state = "Score:" + score.ToString() + "\n";
                e.Graphics.DrawString(state, new Font("Arial", 25, FontStyle.Italic), Brushes.Yellow, new Point(5, 5));
                string health = "Health:";
                e.Graphics.DrawString(health, new Font("Arial", 25, FontStyle.Italic), Brushes.HotPink, new Point(350, 5));
            }
        }
        void Program_Paint1(object sender, PaintEventArgs e)
        {
            string game_over = "GAME OVER";
            string state = "BEST SCORE:" + bestscore.ToString() + "\n";
            e.Graphics.DrawString(state, new Font("Arial", 30, FontStyle.Italic), Brushes.Yellow, new Point(135, 190));
            e.Graphics.DrawString(game_over, new Font("Arial", 60, FontStyle.Italic), Brushes.Black, new Point(30, 100));
        }
    }
 }

