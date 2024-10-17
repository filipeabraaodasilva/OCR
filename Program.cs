using OCR.pdf;
using OCR.utils;

string caminho = @"D:\arquivos\documento.pdf";
toImage arquivo = new toImage(caminhoDoArquivo: caminho);

arquivo.ConvertToJPEG();
List<MemoryStream> paginas = arquivo.getImages();

foreach (MemoryStream imagem in paginas)
{
    saveImage salvar = new saveImage(image: imagem,
                                     filePath: @"D:\arquivos\teste.jpg");
}

Console.WriteLine($"O caminho do arquivo é: {arquivo.getFilePath()}\n" +
                  $"O arquivo possui: {arquivo.getNumberOfPages()}");
