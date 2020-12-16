using System;

namespace Minesweeper_App
{
    public interface IIO
    {
        void Write(string text);
        string Read();
    }
}
