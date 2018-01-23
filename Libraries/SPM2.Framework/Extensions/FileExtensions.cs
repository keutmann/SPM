using System;
using System.IO;

namespace SPM2.Framework
{
    public static class FileExtensions
    {
        public static void SaveStream(string filename, Stream sourceStream)
        {
            int length = 1024;
            int bytesRead = 0;
            Byte[] buffer = new Byte[length];

            // write the required bytes
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                do
                {
                    bytesRead = sourceStream.Read(buffer, 0, length);
                    fs.Write(buffer, 0, bytesRead);
                }
                while (bytesRead == length);
            }
        }
    }
}
