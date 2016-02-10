using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace ImageCompressor
{
    public partial class Form1 : Form
    {
        Bitmap image;
        string file;

        public Form1()
        {
            InitializeComponent();
        }

        private List<int> get565EncodedImageList(Bitmap img)
        {
            List<int> list = new List<int>();

            for (int i = 0; i < img.Height; i++)
            {
                for (int j = 0; j < img.Width; j++)
                {

                    Color pixel = img.GetPixel(j, i);

                    byte red = (byte)((pixel.R >> 3) & 0x1F);
                    byte green = (byte)((pixel.G >> 2) & 0x3F);
                    byte blue = (byte)((pixel.B >> 3) & 0x1F);

                    list.Add(red * 2048 + green * 32 + blue);
                }
            }

            return list;
        }

        private string get565EncodedImageString(Bitmap img)
        {
            string imageString = String.Empty;
            List<int> list = get565EncodedImageList(img);

            for(int i = 0; i < list.Count; i++)
            {
                imageString += "0x" + list[i].ToString("X4") + ", ";
                if ((i + 1) % 16 == 0)
                    imageString += "\r\n";
            }

            return imageString;
        }

        private List<Tuple<int, int>> getRLETuppleList(List<int> list)
        {
            int r = 1;
            int count = 0;
            int i;

            string rleString = String.Empty;
            var tuppleList = new List<Tuple<int, int>>();

            for (i = 0; i < (list.Count - 1); i++ )
            {
                if (list[i] == list[i + 1])
                {
                    r++;
                }
                else
                {
                    tuppleList.Add(new Tuple<int, int>(list[i], r));
                    r = 1;
                    count++;
                }
            }

            // What do we do with the last element?
            if(list[i - 1] == list[i])
            {
                // Its the same as the previous so just bump r on the last tupple
                r++;
                tuppleList.Add(new Tuple<int, int>(list[i], r));
            }
            else
            {
                // Its a new value
                tuppleList.Add(new Tuple<int, int>(list[i], r));
            }

            return tuppleList;

        }

        private void loadBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.

            if (result == DialogResult.OK) // Test result.
            {
                try
                {
                    file = openFileDialog1.FileName;
                    image = (Bitmap)Image.FromFile(file, true);
                    pictureBox1.Image = image;
                    textBoxXdim.Text = image.Width.ToString();
                    textBoxYdim.Text = image.Height.ToString();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void processBtn_Click(object sender, EventArgs e)
        {
            var tuppleList = new List<Tuple<int, int>>();
            List<int> list;

            try
            {
                list = get565EncodedImageList(image);
                tuppleList = getRLETuppleList(list);

                //Console.WriteLine(get565EncodedImageString(image));

                using (StreamWriter outputFile = new StreamWriter(file + ".rle"))
                {
                    foreach (var idx in tuppleList)
                        outputFile.WriteLine("{0}, {1},", "{0x" + idx.Item1.ToString("X4"), "0x" + idx.Item2.ToString("X4") + "}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MessageBox.Show("Success! " + tuppleList.Count.ToString() + " elements");
            }
        }

        private void textBoxXdim_TextChanged(object sender, EventArgs e)
        {
            if(image != null)
            {
                    
            }
        }

        private void textBoxYdim_TextChanged(object sender, EventArgs e)
        {
            if (image != null)
            {

            }
        }

        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                //graphics.CompositingMode = CompositingMode.SourceCopy;
                //graphics.CompositingQuality = CompositingQuality.HighQuality;
                //graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                //graphics.SmoothingMode = SmoothingMode.HighQuality;
                //graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
    }
}
