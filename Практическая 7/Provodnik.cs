using System.Diagnostics;

namespace Pract7
{
    public class Provodnik
    {
        public static string currentDir = "";
        public static List<string> choises = new List<string>();

        public static void ShowDrives()
        {
            Console.Clear();
            choises.Clear();

            Console.WriteLine("Проводник");
            Console.WriteLine("Выберите диск");
            Console.WriteLine("-------------------------------------");

            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in allDrives)
            {
                choises.Add(drive.Name);
                double freeSpace = Math.Round(drive.TotalFreeSpace / 1000000000f, 2);
                double totalSpace = Math.Round(drive.TotalSize / 1000000000f, 2);

                Console.WriteLine($"  {drive.Name} свободно {freeSpace} ГБ из {totalSpace} ГБ");
            }
        }

        public static void ShowFiles()
        {
            Console.Clear();
            choises.Clear();

            Console.WriteLine($"Текущая директория: {currentDir}");
            Console.WriteLine("-------------------------------------");

            string[] files = Directory.GetFiles(currentDir);
            string[] dirs = Directory.GetDirectories(currentDir);
            foreach (string dirPath in dirs)
            {
                choises.Add(dirPath);
                DirectoryInfo directoryInfo = new DirectoryInfo(dirPath);
                Console.WriteLine("  {0, -30}\t\t{1, 15}", directoryInfo.Name, directoryInfo.CreationTime);
            }
            foreach (string filePath in files)
            {
                choises.Add(filePath);
                FileInfo fileInfo = new FileInfo(filePath);
                Console.WriteLine("  {0, -30}\t\t{1, 15}\t\t{2, 15}", fileInfo.Name, fileInfo.CreationTime, fileInfo.Extension);
            }
        }

        public static bool Open(int n)
        {
            if (n == -1 && currentDir.Length > 0)
            {
                DirectoryInfo? parent = Directory.GetParent(currentDir);
                currentDir = parent != null ? parent.FullName : "";
                return true;
            }
            if (n == -1 && currentDir.Length == 0)
            {
                return false;
            }
            if (Directory.Exists(choises[n]))
            {
                currentDir = choises[n];
                return true;
            }
            if (File.Exists(choises[n]))
            {
                OpenFile(choises[n]);
                return false;
            }
            return false;
        }

        private static void OpenFile(string path)
        {
            Process.Start(new ProcessStartInfo { FileName = path, UseShellExecute = true });
        }
    }
}
