using System;
using System.IO;

namespace OCR.utils
{
    public class saveImage
    {
        private MemoryStream Image { get; init; }
        private string FilePath { get; init; }

        public saveImage(MemoryStream image, string filePath)
        {
            //if (Image == null || Image.Length == 0)
            //{
            //    throw new ArgumentException("A imagem está nula ou está corrompida.", nameof(Image));
            //}

            Image = image;
            FilePath = filePath;

            using (var fileStream = new FileStream(FilePath, FileMode.Create, FileAccess.Write))
            {
                Image.WriteTo(fileStream);
            }
        }
    }
}
