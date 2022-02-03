using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace ResizerImages
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 100; i++)
            {
                System.Console.WriteLine("Rodando o For, tentando fazer o resize em várias images...");

                //original dimension of image 223 x 240
                Bitmap img = new Bitmap($@"C:\Users\heric\Downloads\TesteImagens\resize ({i}).jpeg");

                //we are resizing to 110 x 120
                var resizedImg = ResizeImage(img, 300, 300);

                //save file
                resizedImg.Save($@"C:\Users\heric\Downloads\Resized\resized({i}).jpeg");


            }

        }
        //image resize method
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            //local que a imagem irá ficar, tipo um molde
            var destRect = new Rectangle(0, 0, width, height);

            //Bitmap trabalha com os pixels da imagem, e será reutilizado p mandar a nova imagem com a nova resolução
            var destImage = new Bitmap(width, height);

            //usado p manter a quantidade de DPI
            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            //graphics é para manter a qualidade da imagem
            using (var graphics = Graphics.FromImage(destImage))
            {
                //determina se os pixels de uma imagem de origem sobrescrevem ou são combinados com pixels de fundo.
                //.CompositingMode = CompositingMode.SourceCopy;

                //determina o nível de qualidade de renderização de imagens em camadas
                //.CompositingQuality = CompositingQuality.HighQuality;

                //determina como os valores intermediários entre dois pontos finais são calculados
                //graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

                //especifica se linhas, curvas e bordas de áreas preenchidas usam suavização
                //graphics.SmoothingMode = SmoothingMode.HighQuality;

                //afeta a qualidade de renderização ao desenhar a nova imagem
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                //ImagesAttributes é para manter as cores da imagem
                using (var wrapMode = new ImageAttributes())
                {
                    //evita fantasmas ao redor das bordas da imagem
                    // wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
    }
}
