using System;
using System.Collections;
using System.Collections.Generic;

namespace Queue.Model
{
    /// <summary>
    /// Queue.
    /// </summary>
    /// <typeparam name="T"> The type of data stored in the queue. </typeparam>
    public class LinkedQueue<T> : IEnumerable<T>
    {
        /// <summary>
        /// The first item in the list.
        /// </summary>
        private Item<T> Head;

        /// <summary>
        /// The last item in the list.
        /// </summary>
        private Item<T> Tail;

        /// <summary>
        /// Amount of elements.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Create an empty list.
        /// </summary>
        public LinkedQueue() => Clear();

        /// <summary>
        /// Add an item to the queue.
        /// </summary>
        /// <param name="item"> Added data. </param>
        /// <exception cref="ArgumentNullException"><paramref name="item"/> is <c>null</c>.</exception>
        public void Enqueue(T item)
        {
            // Check input data for emptiness.
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            Item<T> current = Tail;
            Tail = new Item<T>(item);

            if (Count == 0)
            {
                Head = Tail;
            }
            else
            {
                current.Next = Tail;
            }

            Count++;
        }

        /// <summary>
        /// Get an item from the queue with removal.
        /// </summary>
        /// <returns> Data item. </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public T Dequeue()
        {
            if (Count == 0)
            {
                throw new ArgumentNullException("Queue is empty.");
            }

            T output = Head.Data;
            Head = Head.Next;
            Count--;

            return output;
        }

        /// <summary>
        /// Read first item from the queue without deleting it.
        /// </summary>
        /// <returns> Data item. </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public T PeekFirst()
        {
            if (Count == 0)
            {
                throw new ArgumentNullException("Queue is empty.");
            }

            // Get an item from the front of the queue.
            return Head.Data;
        }

        /// <summary>
        /// Read last item from the queue without deleting it.
        /// </summary>
        /// <returns> Data item. </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public T PeekLast()
        {
            if (Count == 0)
            {
                throw new ArgumentNullException("Queue is empty.");
            }

            // Get an item from the tail of the queue.
            return Tail.Data;
        }

        /// <summary>
        /// Check for element.
        /// </summary>
        /// <param name="data"> Data to be checked </param>
        /// <returns> String with message </returns>
        /// <exception cref="ArgumentNullException"><paramref name="data"/> is <c>null</c>.</exception>
        public string Contains(T data)
        {
            // Check input data for emptiness.
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            Item<T> current = Head;

            while(current != null)
            {
                if (current.Data.Equals(data))
                {
                    return $"Elements {data} is in the list.";
                }
                current = current.Next;
            }

            return $"Elements {data} is not in the list.";
        }

        /// <summary>
        /// Clear list.
        /// </summary>
        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        /// <summary>
        /// Return an enumerator that iterates through all the elements in a queue.
        /// </summary>
        /// <returns> An enumerator that can be used to iterate over the collection. </returns>
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Item<T> current = Head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        /// <summary>
        /// Return an enumerator that iterates through the queue.
        /// </summary>
        /// <returns> The IEnumerator used to traverse the collection. </returns>
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)this).GetEnumerator();
    }
}