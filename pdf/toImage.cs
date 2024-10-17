using System;
using System.IO;
using PdfiumViewer;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;

#pragma warning disable CA1416
namespace OCR.pdf
{
    public class toImage
    {
        private string CaminhoDoArquivo { get; init; }
        private List<MemoryStream> ImagensEmMemoria { get; }

        public toImage(string caminhoDoArquivo)
        {
            if (string.IsNullOrWhiteSpace(caminhoDoArquivo))
            {
                throw new ArgumentException("O caminho do arquivo não pode ser nulo ou vazio.", nameof(caminhoDoArquivo));
            }

            CaminhoDoArquivo = caminhoDoArquivo;
            ImagensEmMemoria = new List<MemoryStream>();
        }
        public void ConvertToJPEG()
        {
            using (var documento = PdfDocument.Load(CaminhoDoArquivo))
            {
                for (int i = 0; i < documento.PageCount; i++)
                {
                    using (var imagem = RenderizarPagina(documento, i))
                    {
                        var memoryStream = new MemoryStream();
                        imagem.Save(memoryStream, ImageFormat.Jpeg);
                        ImagensEmMemoria.Add(memoryStream);
                    }
                }
            }
        }
        private Bitmap RenderizarPagina(PdfDocument documento, int numeroPagina)
        {
            const int dpi = 300;

            var tamanho = documento.PageSizes[numeroPagina];
            var largura = (int)(tamanho.Width * dpi / 72);
            var altura = (int)(tamanho.Height * dpi / 72);

            var imagem = new Bitmap(largura, altura);

            using (var graphics = Graphics.FromImage(imagem))
            {
                graphics.Clear(Color.White);
                graphics.DrawImage(image: documento.Render(page: numeroPagina, 
                                                           width: largura, 
                                                           height: altura, 
                                                           dpiX: dpi, 
                                                           dpiY: dpi, 
                                                           flags: PdfRenderFlags.Annotations), 
                                   x: 0, 
                                   y: 0, 
                                   width: largura, 
                                   height: altura);
            }

            return imagem;
        }
        public string getFilePath()
        {
            return CaminhoDoArquivo;
        }
        public List<MemoryStream> getImages()
        {
            return ImagensEmMemoria;
        }
        public int getNumberOfPages()
        {
            PdfDocument documento = PdfDocument.Load(CaminhoDoArquivo);
            return documento.PageCount;
        }
    }
}
#pragma warning restore CA1416
