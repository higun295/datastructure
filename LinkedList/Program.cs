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

        public void Add(SinglyLinkedListNode<T> newNode) {

        }
    }
}
