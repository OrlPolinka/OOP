using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using lab12;
using Lab12;

namespace lab12
{
    class Program
    {
        static void Main(string[] args) 
        {
            // 1, 6
            string logFilePath = "opvlogfile.txt";
            OPVLog log = new OPVLog(logFilePath);

            log.WriteLog("Создание файла", @"C:\Temp\example1.txt");
            log.WriteLog("Чтение файла", @"C:\Temp\example2.txt");
            log.WriteLog("Удаление файла", @"C:\Temp\example3.txt");

            Console.WriteLine("Содержимое лога:");
            Console.WriteLine(log.ReadLog());

            Console.WriteLine("\nПоиск по ключевому слову 'Создание':");
            Console.WriteLine(log.SearchLog("Создание"));

            DateTime today = DateTime.Now;
            Console.WriteLine($"\nЗаписи за {today:yyyy-MM-dd}:");
            Console.WriteLine(log.SearchByDate(today));

            Console.WriteLine($"\nКоличество записей в логе: {log.CountRecords()}");

            log.RetainCurrentHourLogs();
            Console.WriteLine("\nСодержимое лога после удаления старых записей:");
            Console.WriteLine(log.ReadLog());



            // 2
            OPVDiskInfo diskInfo = new OPVDiskInfo(log);

            Console.WriteLine(diskInfo.GetFreeSpace("C"));

            Console.WriteLine(diskInfo.GetFileSystem("C"));

            Console.WriteLine("\nИнформация обо всех дисках:");
            diskInfo.DisplayAllDrivesInfo();



            // 3
            OPVFileInfo fileInfo = new OPVFileInfo(log);

            string testFilePath = "example.txt";

            if (!File.Exists(testFilePath))
            {
                File.WriteAllText(testFilePath, "Это пример содержимого файла.");
            }

            Console.WriteLine("a. Полный путь:");
            fileInfo.GetFullPath(testFilePath);

            Console.WriteLine("\nb. Информация о файле:");
            fileInfo.GetFileInfo(testFilePath);

            Console.WriteLine("\nc. Даты файла:");
            fileInfo.GetFileDates(testFilePath);



            // 4
            OPVDirInfo dirInfo = new OPVDirInfo(log);

            string testDirectoryPath = "TestDirectory";

            if (!Directory.Exists(testDirectoryPath))
            {
                Directory.CreateDirectory(testDirectoryPath);
                File.Create(Path.Combine(testDirectoryPath, "test.txt")).Close();
                Directory.CreateDirectory(Path.Combine(testDirectoryPath, "SubDirectory1"));
                Directory.CreateDirectory(Path.Combine(testDirectoryPath, "SubDirectory2"));
            }

            Console.WriteLine("a. Количество файлов:");
            dirInfo.GetFileCount(testDirectoryPath);

            Console.WriteLine("\nb. Время создания:");
            dirInfo.GetCreationTime(testDirectoryPath);

            Console.WriteLine("\nc. Количество поддиректорий:");
            dirInfo.GetSubdirectoryCount(testDirectoryPath);

            Console.WriteLine("\nd. Список родительских директорий:");
            dirInfo.GetParentDirectories(testDirectoryPath);



            // 5
            OPVFileManager fileManager = new OPVFileManager(log);

            string diskName = "C:\\";

            Console.WriteLine("a. Создание диска:");
            fileManager.InspectDisk(diskName);

            string sourceDirectory = "C:\\TestSource";
            string targetDirectory = "C:\\TestTarget";
            string extension = "txt";

            Console.WriteLine("\nb. Копирование файлов с расширением:");
            fileManager.CopyFilesWithExtension(sourceDirectory, extension, targetDirectory);

            string archivePath = Path.Combine(targetDirectory, "OPVFiles.zip");
            string extractPath = Path.Combine(targetDirectory, "ExtractedFiles");

            Console.WriteLine("\nc. Архивация:");
            fileManager.ArchiveFiles(Path.Combine(targetDirectory, "OPVInspect", "OPVFiles"), archivePath);

            Console.WriteLine("\nc. Разархивация:");
            fileManager.ExtractArchive(archivePath, extractPath);
        }
    }
}