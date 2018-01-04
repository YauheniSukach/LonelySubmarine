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
    class Health
    {
        public PictureBox pictbox = new PictureBox();
        public Health(int x5,int y5)
        {
            pictbox.Location = new Point(x5, y5);
            pictbox.SizeMode = PictureBoxSizeMode.AutoSize;
            pictbox.Image = new Bitmap("Health.jpg");
        }
    }
}
