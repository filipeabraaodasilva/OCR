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
                                     filePath: $@"{tempPath}\pagina_{i + 1}.jpg");
}

//Console.WriteLine($"O caminho do arquivo é: {arquivo.getFilePath()}\n" +
//                  $"O arquivo possui: {arquivo.getNumberOfPages()}");
