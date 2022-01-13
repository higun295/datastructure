using System;

namespace Array {
    class Program {
        static void Main(string[] args) {
        }
    }

    public class DynamicArray {
        private object[] arr;
        private const int GROWTH_FACTOR = 2;

        public int Count { get; private set; }
        public int Capacity {
            get { return arr.Length; }
        }

        public DynamicArray(int capacity = 16) {
            arr = new object[capacity];
            Count = 0;
        }

        public void Add(object element) {
            // 배열이 찼을 때 확장
            if(Count >= Capacity) {
                int newSize = Capacity * GROWTH_FACTOR;
                var temp = new object[newSize];
                for(int i = 0; i < arr.Length; i++) {
                    temp[i] = arr[i];
                }
                arr = temp;
            }

            arr[Count] = element;
            Count++;
        }

        public object Get(int index) {
            if(index > Capacity - 1) {
                throw new ApplicationException("Element not found");
            }
            return arr[index];
        }
    }
}