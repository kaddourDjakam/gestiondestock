using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GCabinetCompt.Shell.Tools
{
    public class change
    {
        public static ImageSource ByteArrayToImage(byte[] byteArrayIn)
        {
            if (byteArrayIn != null)
            {
                var biImg = new BitmapImage();
                var ms = new MemoryStream(byteArrayIn);
                biImg.BeginInit();
                biImg.StreamSource = ms;
                biImg.EndInit();

                var imgSrc = biImg as ImageSource;

                return imgSrc;
            }
            return null;
        }

        public static byte[] GetJpgFromImageControl(BitmapImage imageC)
        {
            if (imageC == null)
                return null;

            var memStream = new MemoryStream();
            var encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(imageC));
            encoder.Save(memStream);
            return memStream.GetBuffer();
        } 
    }
}