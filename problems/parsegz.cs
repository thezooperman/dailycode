using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace problems
{
    class ParseGzFiles
    {
        private static string BASE_PATH = @"../data";

        public async Task readFile(string fileName = "")
        {
            fileName = String.IsNullOrEmpty(fileName) ? "sample-2mb-text-file.txt.gz" : fileName;
            fileName = string.Join('/', BASE_PATH, fileName);

            using (FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (GZipStream unzip = new GZipStream(fileStream, CompressionMode.Decompress))
                {
                    using (BufferedStream bs = new BufferedStream(unzip))
                    {
                        using (StreamReader reader = new StreamReader(bs))
                        {
                            while (!reader.EndOfStream)
                                System.Console.WriteLine(await reader.ReadLineAsync());
                        }
                    }
                }
            }
        }
    }
}