using System;
using System.IO;

namespace OCR.utils
{
    public class saveImage
    {
        private MemoryStream Image { get; init; }
        private string Folder { get; init; }
        private string FileName { get; init; }

        public saveImage(MemoryStream image, string folder, string fileName)
        {
            if (image == null || image.Length == 0)
            {
                throw new ArgumentException("A imagem está nula ou está corrompida.", nameof(Image));
            }

            Image = image;
            Folder = folder;
            FileName = fileName;

            using (var fileStream = new FileStream(Path.Combine(Folder, $"{FileName}.jpg"), 
                                                   FileMode.Create, 
                                                   FileAccess.Write))
            {
                Image.WriteTo(fileStream);
            }
        }
    }
}
