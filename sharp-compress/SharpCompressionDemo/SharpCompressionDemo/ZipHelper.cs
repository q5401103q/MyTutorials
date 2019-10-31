using SharpCompress.Archives;
using SharpCompress.Archives.Zip;
using SharpCompress.Common;
using SharpCompress.Writers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCompressionDemo
{
    /// <summary>
    /// 压缩工具类
    /// </summary>
    public class ZipHelper
    {
        /// <summary>
        /// 压缩文件
        /// </summary>
        /// <param name="sourceFilePaths">待压缩的文件路径，可包含单个或多个文件</param>
        /// <param name="targetFilePath">压缩后的文件路径，格式为.zip</param>
        public static void ZipFiles(IList<string> sourceFilePaths, string targetFilePath)
        {
            ArchiveEncoding ArchiveEncoding = new ArchiveEncoding();
            ArchiveEncoding.Default = Encoding.GetEncoding("utf-8");
            WriterOptions zipOptions = new WriterOptions(CompressionType.Deflate);
            zipOptions.ArchiveEncoding = ArchiveEncoding;

            using (var archive = ZipArchive.Create())
            {
                foreach (var sourceFilePath in sourceFilePaths)
                {
                    var sourceFile = new FileInfo(sourceFilePath);
                    archive.AddEntry(sourceFile.Name, sourceFile.OpenRead());
                }

                using (var zipStream = File.OpenWrite(targetFilePath))
                {
                    archive.SaveTo(zipStream, zipOptions);
                }
            }
        }

        /// <summary>
        /// 压缩文件夹
        /// </summary>
        /// <param name="sourceFolderPath">待压缩的文件夹路径</param>
        /// <param name="targetFilePath">压缩后的文件路径，格式为.zip</param>
        public static void ZipFolders(string sourceFolderPath, string targetFilePath)
        {
            ArchiveEncoding ArchiveEncoding = new ArchiveEncoding();
            ArchiveEncoding.Default = Encoding.GetEncoding("utf-8");
            WriterOptions zipOptions = new WriterOptions(CompressionType.Deflate);
            zipOptions.ArchiveEncoding = ArchiveEncoding;

            using (var archive = ZipArchive.Create())
            {
                archive.AddAllFromDirectory(sourceFolderPath);
                using (var zipStream = File.OpenWrite(targetFilePath))
                {
                    archive.SaveTo(zipStream, zipOptions);
                }
            }
        }

        /// <summary>
        /// 解压文件
        /// </summary>
        /// <param name="sourceFilePath">压缩文件路径</param>
        /// <param name="targetFolderPath">解压到路径</param>
        public static void UnZip(string sourceFilePath, string targetFolderPath)
        {
            if (!Directory.Exists(targetFolderPath))
            {
                Directory.CreateDirectory(targetFolderPath);
            }

            var archive = ArchiveFactory.Open(sourceFilePath);
            foreach (var entry in archive.Entries)
            {
                if (!entry.IsDirectory)
                {
                    entry.WriteToDirectory(targetFolderPath, new ExtractionOptions { ExtractFullPath = true, Overwrite = true });
                }
            }
        }
    }
}
