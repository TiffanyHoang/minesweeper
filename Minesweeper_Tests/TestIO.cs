using System;
using System.Collections.Generic;

namespace Minesweeper_App
{
    public class TestIO:IIO
    {
        private readonly Queue<string> _value = new Queue<string>();
        public void Write(string text) => _value.Enqueue(text);

        public string GetText() => _value.Dequeue();

        public bool HasText(string text)
        {
            var hasText = 0;
            foreach (var value in _value)
            {
                if (value.Contains(text))
                {
                    hasText += 1; 
                }
            }
            return hasText != 0;
        }
        public void SetToBeRead(string value) => _value.Enqueue(value);
        public string Read() => _value.Dequeue();
        
    }
}
