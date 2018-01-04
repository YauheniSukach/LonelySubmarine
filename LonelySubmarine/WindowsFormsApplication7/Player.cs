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
    class Player
    {
        public PictureBox pictbox = new PictureBox();
        public Player(int x, int y)
        {
            pictbox.Location = new Point(x, y);
            pictbox.Image = new Bitmap("lodka.jpg");
            pictbox.SizeMode = PictureBoxSizeMode.AutoSize;
        }
        public void move_up()
        {
            if (pictbox.Top > 250) pictbox.Top = pictbox.Top - 10;
        }
        public void move_down()
        {
            if (pictbox.Bottom < 610) pictbox.Top = pictbox.Top + 10;
        }
    }
}