using System;
using System.IO;
using System.Linq;

namespace Lab12
{
    public class OPVLog
    {
        private string logFileName;

        public OPVLog(string logFileName)
        {
            this.logFileName = logFileName;
        }

        public void WriteLog(string action, string filePath)
        {
            string logInfo = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}\tAction: {action}\tFile: {filePath}";
            using (StreamWriter sw = new StreamWriter(logFileName, true)) 
            {
                sw.WriteLine(logInfo);
            }
        }

        public string ReadLog()
        {
            if (!File.Exists(logFileName))
                return "Лог-файл отсутствует.";

            using (StreamReader sr = new StreamReader(logFileName))
            {
                return sr.ReadToEnd();
            }
        }

        // Метод поиска записей по ключевому слову
        public string SearchLog(string keyword)
        {
            if (!File.Exists(logFileName))
                return "Лог-файл отсутствует.";

            var lines = File.ReadAllLines(logFileName);
            var results = lines.Where(line => line.Contains(keyword)).ToList();

            return results.Count > 0
                ? string.Join(Environment.NewLine, results)
                : $"'{keyword}' не найдено в лог-файле.";
        }

        // Метод поиска записей за указанный день
        public string SearchByDate(DateTime date)
        {
            if (!File.Exists(logFileName))
                return "Лог-файл отсутствует.";

            var lines = File.ReadAllLines(logFileName);
            string datePrefix = date.ToString("yyyy-MM-dd");
            var results = lines.Where(line => line.StartsWith(datePrefix)).ToList();

            return results.Count > 0
                ? string.Join(Environment.NewLine, results)
                : $"Записей за {datePrefix} не найдено.";
        }

        // Подсчет количества записей в логе
        public int CountRecords()
        {
            if (!File.Exists(logFileName))
                return 0;

            return File.ReadAllLines(logFileName).Length;
        }

        // Удаление записей, оставляя только записи за текущий час
        public void RetainCurrentHourLogs()
        {
            if (!File.Exists(logFileName))
                return;

            string hourPrefix = DateTime.Now.ToString("yyyy-MM-dd HH");
            var lines = File.ReadAllLines(logFileName)
                            .Where(line => line.StartsWith(hourPrefix))
                            .ToList();

            File.WriteAllLines(logFileName, lines);
        }
    }
}
