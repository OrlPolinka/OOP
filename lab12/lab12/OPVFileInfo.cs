using System;
using System.IO;

namespace Lab12
{
    public class OPVFileInfo
    {
        private OPVLog log;

        public OPVFileInfo(OPVLog log)
        {
            this.log = log;
        }

        // Метод для получения полного пути к файлу
        public void GetFullPath(string filePath)
        {
            log.WriteLog("GetFullPath", $"File Path: {filePath}");
            string fullPath = Path.GetFullPath(filePath);
            Console.WriteLine("Полный путь: " + fullPath);
        }

        // Метод для получения информации о файле (имя, размер, расширение)
        public void GetFileInfo(string filePath)
        {
            log.WriteLog("GetFileInfo", $"File Path: {filePath}");
            FileInfo fileInfo = new FileInfo(filePath);

            if (fileInfo.Exists)
            {
                Console.WriteLine($"Имя файла: {fileInfo.Name}");
                Console.WriteLine($"Размер файла: {fileInfo.Length} байт");
                Console.WriteLine($"Расширение файла: {fileInfo.Extension}");
            }
            else
            {
                Console.WriteLine($"Файл {filePath} не найден.");
            }
        }

        // Метод для получения дат создания и изменения файла
        public void GetFileDates(string filePath)
        {
            log.WriteLog("GetFileDates", $"File Path: {filePath}");
            FileInfo fileInfo = new FileInfo(filePath);

            if (fileInfo.Exists)
            {
                Console.WriteLine($"Дата создания: {fileInfo.CreationTime}");
                Console.WriteLine($"Дата последнего изменения: {fileInfo.LastWriteTime}");
            }
            else
            {
                Console.WriteLine($"Файл {filePath} не найден.");
            }
        }
    }
}
