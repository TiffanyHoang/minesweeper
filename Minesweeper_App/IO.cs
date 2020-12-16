using System;

namespace Minesweeper_App
{
    public class IO:IIO
    {
        public void Write(string text)
        {
            Console.WriteLine(text);
        }
        public string Read()
        {
            return Console.ReadLine();
        }
        
    }
}
