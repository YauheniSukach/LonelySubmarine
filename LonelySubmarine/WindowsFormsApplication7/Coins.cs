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
    class Coins
    {
       public PictureBox pictbox = new PictureBox();
        public Coins(int x4, int y4)
        {
            pictbox.Location = new Point(x4, y4);
            pictbox.Image = new Bitmap("coin.jpg");
            pictbox.SizeMode = PictureBoxSizeMode.AutoSize;
        }
      public void Move_Left()
        {
            pictbox.Left = pictbox.Left - 2;
        }
    }
}
