using System.Collections.Generic;
using System.Linq;

namespace FindTheEquation.App
{
    public class DigitsIterator
    {
        private int _currentIndex = -1;
        private readonly IEnumerable<string> _collection;
        
        public bool Completed => _currentIndex == _collection.Count() - 1;
        public string Current => _collection.ElementAt(_currentIndex);

        public DigitsIterator(string collection)
        {
            _collection = collection.ToCharArray().Select(x => x.ToString()).ToArray();
        }

        public void Next()
        {
            if (_currentIndex < _collection.Count() - 1)
            {
                _currentIndex++;
            }
        }
    }
}