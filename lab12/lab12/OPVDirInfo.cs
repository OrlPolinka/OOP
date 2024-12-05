using System;
using System.IO;

namespace Lab12
{
    public class OPVDirInfo
    {
        private OPVLog log;

        public OPVDirInfo(OPVLog log)
        {
            this.log = log;
        }

        // Метод для получения количества файлов в директории
        public void GetFileCount(string directoryPath)
        {
            log.WriteLog("GetFileCount", $"Path: {directoryPath}");
            if (Directory.Exists(directoryPath))
            {
                int fileCount = Directory.GetFiles(directoryPath).Length;
                Console.WriteLine($"Количество файлов в директории {directoryPath}: {fileCount}");
            }
            else
            {
                Console.WriteLine($"Директория {directoryPath} не найдена.");
            }
        }

        // Метод для получения времени создания директории
        public void GetCreationTime(string directoryPath)
        {
            log.WriteLog("GetCreationTime", $"Path: {directoryPath}");
            if (Directory.Exists(directoryPath))
            {
                DirectoryInfo dirInfo = new DirectoryInfo(directoryPath);
                Console.WriteLine($"Время создания директории {directoryPath}: {dirInfo.CreationTime}");
            }
            else
            {
                Console.WriteLine($"Директория {directoryPath} не найдена.");
            }
        }

        // Метод для получения количества поддиректорий
        public void GetSubdirectoryCount(string directoryPath)
        {
            log.WriteLog("GetSubdirectoryCount", $"Path: {directoryPath}");
            if (Directory.Exists(directoryPath))
            {
                int subdirectoryCount = Directory.GetDirectories(directoryPath).Length;
                Console.WriteLine($"Количество поддиректорий в директории {directoryPath}: {subdirectoryCount}");
            }
            else
            {
                Console.WriteLine($"Директория {directoryPath} не найдена.");
            }
        }

        // Метод для получения списка родительских директорий
        public void GetParentDirectories(string directoryPath)
        {
            log.WriteLog("GetParentDirectories", $"Path: {directoryPath}");
            DirectoryInfo dirInfo = new DirectoryInfo(directoryPath);
            if (dirInfo.Exists)
            {
                Console.WriteLine("Список родительских директорий:");
                DirectoryInfo parentDirectory = dirInfo.Parent;
                while (parentDirectory != null)
                {
                    Console.WriteLine(parentDirectory.FullName);
                    parentDirectory = parentDirectory.Parent;
                }
            }
            else
            {
                Console.WriteLine($"Директория {directoryPath} не найдена.");
            }
        }
    }
}
