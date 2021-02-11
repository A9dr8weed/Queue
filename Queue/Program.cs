using Queue.Model;

using System;

namespace Queue
{
    internal static class Program
    {
        private static void Main()
        {
            EasyQueue<int> easyQueue = new EasyQueue<int>();

            easyQueue.Enqueue(1);
            easyQueue.Enqueue(2);
            easyQueue.Enqueue(3);
            Console.WriteLine(easyQueue.Contains(5));

            Console.WriteLine(easyQueue.Dequeue());
            Console.WriteLine(easyQueue.Peek());
            Console.WriteLine(easyQueue.Dequeue());

            ArrayQueue<int> arrayQueue = new ArrayQueue<int>();
            arrayQueue.Enqueue(10);
            arrayQueue.Enqueue(20);
            arrayQueue.Enqueue(30);
            Console.WriteLine(arrayQueue.Contains(10));

            Console.WriteLine(arrayQueue.Dequeue());
            Console.WriteLine(arrayQueue.Dequeue());
            Console.WriteLine(arrayQueue.Dequeue());

            LinkedQueue<int> linkedQueue = new LinkedQueue<int>();
            linkedQueue.Enqueue(100);
            linkedQueue.Enqueue(200);
            linkedQueue.Enqueue(300);

            Console.WriteLine(linkedQueue.Dequeue());
            Console.WriteLine(linkedQueue.PeekFirst());
            Console.WriteLine(linkedQueue.PeekLast());
            Console.WriteLine(linkedQueue.Dequeue());
        }
    }
}