using System;
namespace Meow 
{
    public class StringStack 
    {
        private const int Capacity = 100;
        private string[] _array = new string[Capacity];
        private int _pointer;

        public int Count => _pointer;
        public bool IsEmpty => _pointer == 0;

        public void Push(string value) 
        {
            if (_pointer >= Capacity) {
				throw new Exception("Stack overflowed");
			}
            _array[_pointer++] = value;
        }

        public string Pop() 
        {
            if (IsEmpty) {
				throw new Exception("Stack underflowed");
			}
            return _array[--_pointer];
        }

        public string Peek() 
        {
            if (IsEmpty) {
				return null;
			}
			else {
				return _array[_pointer - 1];
			}
        }
    }
	
	public class NumStack 
    {
        private const int Capacity = 100;
        private double[] _array = new double[Capacity];
        private int _pointer;

        public int Count => _pointer;
        public bool IsEmpty => _pointer == 0;

        public void Push(double value) 
        {
            if (_pointer >= Capacity) {
				throw new Exception("Stack overflowed");
			}
            _array[_pointer++] = value;
        }

        public double Pop() 
        {
            if (IsEmpty) {
				throw new Exception("Stack underflowed");
			}
            return _array[--_pointer];
        }

        public double Peek() 
        {
            if (IsEmpty) {
				throw new Exception("Nothing to peek at");
			}
			
			return _array[_pointer - 1];
        }
    }
}
	
