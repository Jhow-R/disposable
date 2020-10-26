using System;
using System.IO;

namespace disposable
{
    /// <summary>
    /// Classe com padrão Dispose implementado
    /// </summary>
    class LogWriter : IDisposable
    {
        private readonly StreamWriter streamWriter;

        // Booleano para detectar chamadas redundantes ao método Dispose
        private bool disposedValue = false;

        public LogWriter(string logFile)
        {
            streamWriter = new StreamWriter(logFile, true);
            streamWriter.WriteLine("Iniciando o log às {0}", DateTime.Now);
        }

        ~LogWriter()
        {
            Dispose(false);
        }

        public void WriteLine(string text)
        {
            streamWriter.WriteLine(text);
        }

        // O método Dispose() definido pela interface IDisposable é um invólucro em torno de um método de protegido Dispose(bool disposing) que faz todo o trabalho.
        // Primeiro, ele verifica uma flag para garantir que não estamos liberando o recurso duas vezes.
        public void Dispose()
        {
            Dispose(true);
            
            // Permite que o coletor de lixo libere a memória do objeto diretamente quando ele não estiver mais em uso.
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    streamWriter.Close();
                }
                
                disposedValue = true;
            }
        }
    }
}
