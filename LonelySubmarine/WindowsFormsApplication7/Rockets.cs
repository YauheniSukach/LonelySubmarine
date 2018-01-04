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
    class Rockets
    {
        public PictureBox pictbox = new PictureBox();
        public Rockets(int x3, int y3)
        {
            pictbox.Location = new Point(x3, y3);
            pictbox.Image = new Bitmap("rocket.jpg");
            pictbox.SizeMode = PictureBoxSizeMode.AutoSize;
        }
        public void Move_Left()
        {
            pictbox.Left = pictbox.Left - 3;
        }
    }
}
