namespace Pract7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            while (true)
            {
                int minPos = 0;
                if (Provodnik.currentDir.Length > 0)
                {
                    Provodnik.ShowFiles();
                    minPos = 2;
                }
                else
                {
                    Provodnik.ShowDrives();
                    minPos = 3;
                }
                Strelka strelka = new Strelka(minPos, Provodnik.choises.Count + minPos);

                bool needUpdate = false;
                while (!needUpdate)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow:
                            strelka.Prev();
                            break;
                        case ConsoleKey.DownArrow:
                            strelka.Next();
                            break;
                        case ConsoleKey.Escape:
                            needUpdate = Provodnik.Open(-1);
                            break;
                        case ConsoleKey.Enter:
                            needUpdate = Provodnik.Open(strelka.GetIndex());
                            break;
                    }
                }
            }
        }
    }
}