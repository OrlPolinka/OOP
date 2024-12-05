using System;
using System.IO;

namespace Lab12
{
    public class OPVDiskInfo
    {
        private OPVLog log;

        public OPVDiskInfo(OPVLog log)
        {
            this.log = log;
        }

        // Метод для получения информации о свободном месте на диске
        public string GetFreeSpace(string driveName)
        {
            log.WriteLog("GetFreeSpace", $"Drive: {driveName}");
            DriveInfo driveInfo = new DriveInfo(driveName);
            if (driveInfo.IsReady)
                return $"Свободное место на диске {driveName}: {driveInfo.TotalFreeSpace / (1024 * 1024 * 1024)} GB";
            else
                return $"Диск {driveName} не готов или отсутствует.";
        }

        // Метод для получения информации о файловой системе
        public string GetFileSystem(string driveName)
        {
            log.WriteLog("GetFileSystem", $"Drive: {driveName}");
            DriveInfo driveInfo = new DriveInfo(driveName);
            if (driveInfo.IsReady)
                return $"Файловая система диска {driveName}: {driveInfo.DriveFormat}";
            else
                return $"Диск {driveName} не готов или отсутствует.";
        }

        // Метод для вывода информации обо всех существующих дисках
        public void DisplayAllDrivesInfo()
        {
            log.WriteLog("DisplayAllDrivesInfo", "Listing all drives");
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives)
            {
                if (drive.IsReady)
                {
                    Console.WriteLine($"Имя диска: {drive.Name}");
                    Console.WriteLine($"Объем диска: {drive.TotalSize / (1024 * 1024 * 1024)} GB");
                    Console.WriteLine($"Свободное место: {drive.TotalFreeSpace / (1024 * 1024 * 1024)} GB");
                    Console.WriteLine($"Файловая система: {drive.DriveFormat}");
                    Console.WriteLine($"Метка тома: {drive.VolumeLabel}");
                }
                else
                {
                    Console.WriteLine($"Диск {drive.Name} не готов.");
                }
                Console.WriteLine(new string('-', 40));
            }
        }
    }
}

