using System;
using System.IO;

namespace disposable
{
    /// <summary>
    /// Classe com implementação básica do Dispose
    /// </summary>
    class FileManager : IDisposable
    {
        private readonly FileStream fileStream;

        public FileManager(string filePath)
        {
            fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        }

        public void Write(byte[] data)
        {
            fileStream.Write(data, 0, data.Length);
        }

        public void Dispose()
        {
            fileStream.Close();
        }
    }
}
