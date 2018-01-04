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
    class Clouds
    {
        public PictureBox pictbox = new PictureBox();
        public Clouds(int x1, int y1)
        {
            pictbox.Location = new Point(x1, y1);
            pictbox.Image = new Bitmap("cloud.jpg");
            pictbox.SizeMode = PictureBoxSizeMode.AutoSize;
        }
        public void Move_Left()
        {
            pictbox.Left --;
        }

    }
}
