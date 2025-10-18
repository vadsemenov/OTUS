namespace Compression
{
    public interface ICompressor
    {
        public void CompressInFile(string sourcePath, string destinationPath);
        public string DecompressFromFile(string sourcePath, string destinationPath);
    }
}