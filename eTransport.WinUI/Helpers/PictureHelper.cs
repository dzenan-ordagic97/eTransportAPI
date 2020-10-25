using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eTransport.WinUI.Helpers
{
    public static class PictureHelper
    {
        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            if (byteArrayIn != null || byteArrayIn?.Length>0)
            {
                MemoryStream ms = new MemoryStream(byteArrayIn);
                Image returnImage = Image.FromStream(ms);
                return returnImage;
            }
            return Properties.Resources.truck2;
        }
        public static byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            if (imageIn != null)
            {

            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
            }
            return imageToByteArray(Properties.Resources.truck2);
        }
        
        public static byte[] loadImageFromDocument()
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files (*.png;*.jpg;*.jpeg;.*.gif;)|*.png;*.jpg;*.jpeg;.*.gif";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                return imageToByteArray(new Bitmap(opnfd.FileName));
            }
            return imageToByteArray(Properties.Resources.truck2);
        }
    }
}
