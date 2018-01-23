using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SPM2.Framework.IO;


namespace SPM2.Framework
{
    public static class FileInfoExtensions
    {
        public static long SizeOnDisk(this FileInfo fileInfo, int clusterSize)
        {
            if (clusterSize <= 0)
            {
                throw new ArgumentException("clustersize may not be equal or below zero!");
            }

            long filelength = fileInfo.Length;
            if (filelength > 0)
            {
                filelength = clusterSize * ((filelength + clusterSize - 1) / clusterSize);
            }
            return filelength;
        }

        /// <summary>
        /// Gets the actual length of the file on disk,
        /// adding the number of bytes left in the cluster,
        /// or getting the compressed file size.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static long SizeOnDisk(this FileInfo file)
        {
            long filelength = file.Length;
            if (filelength > 0)
            {
                // if file is compressed, gets compressed file size
                if ((uint)(file.Attributes & FileAttributes.Compressed) != 0)
                {
                    uint filesizehigh;
                    filelength = Win32.GetCompressedFileSize(file.FullName, out filesizehigh);
                }
                // adds to the file size the number of bytes left in cluster
                else
                {
                    string rootdir = file.Directory.Root.FullName;
                    uint sectorsPerCluster, bytesPerSector, freeClusters, clusters;

                    Win32.GetDiskFreeSpace(rootdir, out sectorsPerCluster, out bytesPerSector, out freeClusters, out clusters);

                    uint clustersize = sectorsPerCluster * bytesPerSector;
                    filelength = (long)(clustersize * ((filelength + clustersize - 1) / clustersize));
                }
            }
            return filelength;
        }

        public static string GetDirectoryPath(string file)
        {
            FileInfo info = new FileInfo(file);
            return info.GetDirectoryPath();
        }

        public static string GetDirectoryPath(this FileInfo file)
        {
            return file.Directory.FullName;
        }
    }
}
