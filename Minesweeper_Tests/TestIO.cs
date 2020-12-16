using System;
using System.Collections.Generic;

namespace Minesweeper_App
{
    public class TestIO:IIO
    {
        private readonly Queue<string> _valueWrite = new Queue<string>();
        private readonly Queue<string> _valueRead = new Queue<string>();
        public void Write(string text) => _valueWrite.Enqueue(text);

        public string GetText() => _valueWrite.Dequeue();

        public bool HasText(string text)
        {
            var hasText = 0;
            foreach (var value in _valueWrite)
            {
                if (value.Contains(text))
                {
                    hasText += 1; 
                }
            }
            return hasText != 0;
        }
        public void SetToBeRead(string valueRead) => _valueRead.Enqueue(valueRead);
        public string Read() => _valueRead.Dequeue();
        
    }
}
