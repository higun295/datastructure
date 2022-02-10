using System;

namespace HashTable {
    public class Program {
        static void Main(string[] args) {
            // Bucket 배열 크기 4로 설정
            Program ht = new Program(4);

            // 6개 엔트리 추가
            ht.Add("James", "425-423-2323");
            ht.Add("Tom", "425-323-1336");
            ht.Add("Jane", "425-733-9853");
            ht.Add("Sam", "425-834-4357");
            ht.Add("Kate", "425-212-3757");
            ht.Add("Ted", "425-744-5557");

            // Bucket 배열 출력
            ht.DebugPrintBuckets();
            Console.WriteLine();

            // Key로부터 Value 얻기
            object val = ht.Get("Jane");
            Console.WriteLine(val);

            // Key가 있는지 체크
            if(ht.Contains("Samuel")) {
                Console.WriteLine("Samuel : Found");
            }
            else {
                Console.WriteLine("Samuel : Not Found");
            }
        }

        // Bucket 배열
        private Node[] buckets;
        private int size;

        public Program(int size = 32) {
            this.buckets = new Node[size];
            this.size = size;
        }

        // Key/Value 엔트리 추가
        public void Add(object key, object value) {
            // 해시함수를 통해 Bucket 인덱스 산출
            int index = HashFunction(key);

            if(buckets[index] == null) {
                buckets[index] = new Node(key, value);
            }
            else {
                // 연결리스트 앞에 추가
                Node node = new Node(key, value);
                node.Next = buckets[index];
                buckets[index] = node;
            }
        }

        // Key로부터 Value 얻기
        public object Get(object key) {
            int index = HashFunction(key);

            Node node = buckets[index];
            while(node != null) {
                // 연결리스트에서 동일한 키 검색
                if(node.Key == key) {
                    return node.Value;
                }
                node = node.Next;
            }
            throw new ApplicationException("Not found");
        }

        // Key가 HashTable에 있는지 체크
        public bool Contains(object key) {
            int index = HashFunction(key);

            Node node = buckets[index];
            while(node != null) {
                if(node.Key == key) {
                    return true;
                }
                node = node.Next;
            }

            return false;
        }

        // 해시함수
        private int HashFunction(object key) {
            int h = Math.Abs(key.GetHashCode());

            int hash = h & 0xff;
            hash += (h >> 8) & 0xff;
            hash += (h >> 16) & 0xff;
            hash += (h >> 24) & 0xff;

            return hash % size;
        }

        // HashTable에서 사용하는 노드
        private class Node {
            public object Key { get; set; }
            public object Value { get; set; }
            public Node Next { get; set; }

            public Node(object key, object value) {
                this.Key = key;
                this.Value = value;
                this.Next = null;
            }
        }

        // Bucket List 출력
        internal void DebugPrintBuckets() {
            for(int i = 0; i < buckets.Length; i++) {
                Console.Write($" {i}: ");

                Node node = buckets[i];
                while(node != null) {
                    Console.Write($"{node.Key} -> ");
                    node = node.Next;
                }

                Console.WriteLine();
            }
        }
    }
}
