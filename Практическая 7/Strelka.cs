namespace Pract7
{
    public class Strelka
    {
        public int currentPos = 0;
        private int maxPos;
        private int minPos;

        public Strelka(int minPosParam, int maxPosParam)
        {
            Console.SetCursorPosition(0, 0);
            minPos = minPosParam;
            maxPos = maxPosParam;

            currentPos = minPosParam;
            Show(-1);
        }

        private void Show(int prevPos)
        {
            if (prevPos >= 0)
            {
                Console.SetCursorPosition(0, prevPos);
                Console.WriteLine("  ");
            }

            Console.SetCursorPosition(0, currentPos);
            Console.WriteLine("->");

            int viewPosition = Math.Max(currentPos - minPos, 0);
            Console.SetCursorPosition(0, viewPosition);
        }

        public void Next()
        {
            int prevPos = currentPos;
            currentPos += 1;
            currentPos = currentPos >= maxPos ? minPos : currentPos;
            Show(prevPos);
        }
        public void Prev()
        {
            int prevPos = currentPos;
            currentPos -= 1;
            currentPos = currentPos < minPos ? maxPos - 1 : currentPos;
            Show(prevPos);
        }

        public int GetIndex()
        {
            return currentPos - minPos;
        }
    }
}
