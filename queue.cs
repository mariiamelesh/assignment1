namespace Meow
{
    using System;

    public class StringQueue
    {
        private const int Capacity = 50;
        private string[] _array = new string[Capacity];
        private int _head = 0;
		private int _tail = 0;
		private int _count = 0;
		public int Count => _count;
		
        public bool IsEmpty => _count == 0;

        public void Enqueue(string element)
		{ 	
			if (_count == Capacity)
				{
					throw new Exception("Queue overflowed");
				}
            _array[_tail] = element;
            _tail = (_tail + 1) % Capacity;
			_count++;
            
        }

        public string Dequeue()
        {
			if (IsEmpty) {
				throw new Exception("Queue underflowed");
			}
			string value = _array[_head];
			_array[_head] = null;
			
			_head = (_head + 1 ) % Capacity;
			_count--;
			return value;
        }
		

    }
}
