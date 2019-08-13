using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BiomorphSharp
{
    public class MainController
    {
        public Biomorph[,] Biomorph { get; set; }

        public MainController()
        {
            Biomorph = new Biomorph[7,5];
        }


        public void Reproduce(Biomorph currentBiomorph)
        {
            throw new NotImplementedException();
        }
    }

    public class Biomorph
    {
        public ImageBrush Brush { get; set; }

        public Biomorph()
        {
            Pen drawPen = new Pen();
            drawPen.Thickness = 2;
            drawPen.Brush = Brushes.Red;

            DrawingVisual visual = new DrawingVisual();
            DrawingContext context = visual.RenderOpen();
            context.DrawRectangle(null, drawPen, new Rect(0, 0, 30, 30));
            context.Close();

            // Create the Bitmap and render the rectangle onto it.
            RenderTargetBitmap bmp = new RenderTargetBitmap(30, 30, 96, 96, PixelFormats.Pbgra32);
            bmp.Render(visual);

            Brush.ImageSource = bmp;
            //BaseImage.Background = parentBrush;
        }

        private void Develop()
        { }
    }
}
