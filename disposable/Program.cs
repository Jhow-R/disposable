using System;
using System.Text;

namespace disposable
{
    class Program
    {
        static void Main(string[] args)
        {
            var log = new LogWriter(@"C:/logFile.txt");

            try
            {
                using (FileManager fileManager = new FileManager(@"C:/teste.txt"))
                {
                    Console.Write("Digite algum texto: ");
                    byte[] data = Encoding.ASCII.GetBytes(Console.ReadLine());

                    fileManager.Write(data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                log.Dispose();
            }

            Console.ReadLine();
        }
    }
}
