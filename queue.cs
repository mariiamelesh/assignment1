namespace Meow
{
    using System;

    public class StringQueue
    {
        private const int Capacity = 50;
        private string[] _array = new string[Capacity];
        private int _pointer;
		public int Count => _pointer;
		
        public bool IsEmpty => _pointer == 0;

        public void Enqueue(string element)
		{ 	
			if (_pointer == _array.Length)
				{
					throw new StackOverflowException("Queue overflowed");
				}
            _array[_pointer] = element;
            _pointer += 1;
            
        }

        public string Dequeue()
        {
			if (IsEmpty) {
				throw new InvalidOperationException("Queue underflowed");
			}
			string value = _array[0];
			int i;
			for (i = 0; i < _pointer-1; i++) {
				_array[i] = _array[i+1];
			}
			--_pointer;
			return value;
        }
		

    }
}