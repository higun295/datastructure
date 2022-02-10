using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace NewHashTable {
    class Program {
        static void Main(string[] args) {
            var dict = new ConcurrentDictionary<int, string>();

            Task t1 = Task.Factory.StartNew(() => {
                int key = 1;
                while(key <= 100) {
                    if(dict.TryAdd(key, "D" + key)) {
                        key++;
                    }
                    Thread.Sleep(100);
                }
            });

            Task t2 = Task.Factory.StartNew(() => {
                int key = 1;
                string val;
                while(key <= 100) {
                    if(dict.TryGetValue(key, out val)) {
                        Console.WriteLine($"{key}:{val}");
                        key++;
                    }
                    Thread.Sleep(10);
                }
            });

            Task.WaitAll(t1, t2);
        }
    }
}