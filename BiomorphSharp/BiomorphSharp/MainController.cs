using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace BiomorphSharp
{
    public class MainController
    {
        public Biomorph[,] Biomorphs { get; set; }

        public MainController()
        {
            Biomorphs = new Biomorph[7,5];
            Biomorphs[0,0] = new Biomorph(new Genome());
        }


        public void Reproduce(Biomorph currentBiomorph)
        {
            throw new NotImplementedException();
        }
    }

    public class Biomorph
    {
        public ImageBrush Brush { get; set; }

        public Biomorph() : this(new Genome())
        { }

        public Biomorph(Genome genome)
        {
            Brush = new ImageBrush();
            Pen drawPen = new Pen();
            drawPen.Thickness = 2;
            drawPen.Brush = Brushes.White;

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

    public class Genome
    {
        private readonly int GENE_COUNT = 9;
        private int[] genes;
        private int[][] phenotype;

        public Genome()
        {
            genes = new int[GENE_COUNT];

            Random rnd = new Random();
            for (int i = 0; i < GENE_COUNT - 1; i++)
            {
                // First 8 genes have values between -5 and 5.
                genes[i] = rnd.Next(11) - 5;
            }
        }

        public int[][] GetPhenotype()
        {
            if (phenotype == null)
            {
                //Decode the genes as per Dawkins' rules.
                int[] dx = new int[GENE_COUNT - 1];
                dx[3] = genes[0];
                dx[4] = genes[1];
                dx[5] = genes[2];

                dx[1] = -dx[3];
                dx[0] = -dx[4];
                dx[7] = -dx[5];

                dx[2] = 0;
                dx[6] = 0;

                int[] dy = new int[GENE_COUNT - 1];
                dy[2] = genes[3];
                dy[3] = genes[4];
                dy[4] = genes[5];
                dy[5] = genes[6];
                dy[6] = genes[7];

                dy[0] = dy[4];
                dy[1] = dy[3];
                dy[7] = dy[5];

                phenotype = new int[][] { dx, dy };
            }

            return phenotype;
        }
        
    }

}
