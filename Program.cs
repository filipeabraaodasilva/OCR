using OCR.pdf;
using OCR.utils;

string pathOfDocument = @"D:\arquivos\documento.pdf";
string tempPath = @"D:\arquivos";

toImage arquivo = new toImage(caminhoDoArquivo: pathOfDocument);

arquivo.ConvertToJPEG();
List<MemoryStream> paginas = arquivo.getImages();

for (int i = 0; i < paginas.Count; i++)
{
    MemoryStream imagem = paginas[i];
    saveImage salvar = new saveImage(image: imagem,
                                     folder: tempPath,
                                     fileName: $"pagina_{i + 1}");
}
