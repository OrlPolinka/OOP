using System;
using System.IO;
using System.IO.Compression;

namespace Lab12
{
    public class OPVFileManager
    {
        private OPVLog log;

        public OPVFileManager(OPVLog log)
        {
            this.log = log;
        }

        // a. Прочитать список файлов и папок заданного диска
        public void InspectDisk(string diskName)
        {
            log.WriteLog("InspectDisk", $"Disk Name: {diskName}");
            string inspectPath = Path.Combine(diskName, "OPVInspect");
            try
            {
                Directory.CreateDirectory(inspectPath);
                string dirInfoPath = Path.Combine(inspectPath, "opvdirinfo.txt");

                using (StreamWriter sw = new StreamWriter(dirInfoPath))
                {
                    sw.WriteLine("Файлы:");
                    foreach (string file in Directory.GetFiles(diskName))
                    {
                        sw.WriteLine(file);
                    }

                    sw.WriteLine("\nПапки:");
                    foreach (string directory in Directory.GetDirectories(diskName))
                    {
                        sw.WriteLine(directory);
                    }
                }

                // Копирование, переименование и удаление
                string copyPath = Path.Combine(inspectPath, "opvdirinfo_copy.txt");
                File.Copy(dirInfoPath, copyPath, true);

                string renamedPath = Path.Combine(inspectPath, "opvdirinfo_renamed.txt");
                File.Move(copyPath, renamedPath);
                File.Delete(dirInfoPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        // b. Скопировать файлы с заданным расширением в OPVFiles
        public void CopyFilesWithExtension(string sourceDirectory, string extension, string targetDirectory)
        {
            log.WriteLog("CopyFilesWithExtension", $"Source: {sourceDirectory}, Extension: {extension}, Target: {targetDirectory}");
            string filesPath = Path.Combine(targetDirectory, "OPVFiles");

            try
            {
                Directory.CreateDirectory(filesPath);
                string[] files = Directory.GetFiles(sourceDirectory, $"*.{extension}");

                foreach (string file in files)
                {
                    string fileName = Path.GetFileName(file);
                    string destinationPath = Path.Combine(filesPath, fileName);
                    File.Copy(file, destinationPath, true);
                }

                // Перемещение директории OPVFiles в OPVInspect
                string inspectPath = Path.Combine(targetDirectory, "OPVInspect");
                Directory.CreateDirectory(inspectPath);
                string destinationFolder = Path.Combine(inspectPath, "OPVFiles");
                if (Directory.Exists(destinationFolder))
                {
                    Directory.Delete(destinationFolder, true);
                }
                Directory.Move(filesPath, destinationFolder);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        // c. Создать архив из файлов директория OPVFiles
        public void ArchiveFiles(string sourceDirectory, string archivePath)
        {
            log.WriteLog("ArchiveFiles", $"Source: {sourceDirectory}, Archive: {archivePath}");
            try
            {
                ZipFile.CreateFromDirectory(sourceDirectory, archivePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        // c. Разархивировать файлы
        public void ExtractArchive(string archivePath, string targetDirectory)
        {
            log.WriteLog("ExtractArchive", $"Archive: {archivePath}, Target: {targetDirectory}");
            try
            {
                ZipFile.ExtractToDirectory(archivePath, targetDirectory);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}

