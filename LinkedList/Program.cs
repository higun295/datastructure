using System;

namespace LinkedList {
    class Program {
        static void Main(string[] args) {
        }
    }

    public class SinglyLinkedListNode<T> {
        public T Data { get; set; }
        public SinglyLinkedListNode<T> Next { get; set; }

        public SinglyLinkedListNode(T data) {
            this.Data = data;
            this.Next = null;
        }
    }

    public class SinglyLinkedList<T> {
        private SinglyLinkedListNode<T> head;

        public void Add(
            SinglyLinkedListNode<T> newNode) {
            // 리스트가 비어 있으면
            if(head == null) {
                head = newNode;
            }
            else {
                // 비어 있지 않으면
                var current = head;

                // 마지막 노드로 이동하여 추가
                while(current != null &&
                      current.Next != null) {
                    current = current.Next;
                }

                current.Next = newNode;
            }
        }

        public void AddAfter(
            SinglyLinkedListNode<T> current,
            SinglyLinkedListNode<T> newNode) {

        }
    }
}
