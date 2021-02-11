using System;
using System.Collections.Generic;
using System.Linq;

namespace Queue.Model
{
    /// <summary>
    /// Queue.
    /// </summary>
    /// <typeparam name="T"> The type of data stored in the queue. </typeparam>
    public class EasyQueue<T>
    {
        /// <summary>
        /// The collection of stored data.
        /// </summary>
        private readonly List<T> items = new List<T>();

        /// <summary>
        /// Amount of elements.
        /// </summary>
        public int Count => items.Count;

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

            // Add data to the item collection.
            items.Add(item);
        }

        /// <summary>
        /// Get an item from the queue with removal.
        /// </summary>
        /// <returns> Data item. </returns>
        public T Dequeue()
        {
            // Get an item from the front of the queue.
            T item = GetItem();

            // Remove an item from the collection.
            items.Remove(item);

            // We return the resulting element.
            return item;
        }

        /// <summary>
        /// Read an item from the queue without deleting it.
        /// </summary>
        /// <returns> Data item. </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public T Peek()
        {
            if (Count == 0)
            {
                throw new ArgumentNullException("Queue is empty.");
            }

            // Get an item from the front of the queue.
            return GetItem();
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

            foreach (T item in items)
            {
                if (item.Equals(data))
                {
                    return $"Element {data} is in the list.";
                }
            }

            return $"Element {data} is not in the list.";
        }

        /// <summary>
        /// Get an item from the front of the queue.
        /// </summary>
        /// <returns> The starting element of the queue. </returns>
        /// <exception cref="NullReferenceException"></exception>
        private T GetItem()
        {
            // Get the first item.
            T item = items.FirstOrDefault();

            // If the element is empty, then we report an error.
            if (item == null)
            {
                throw new NullReferenceException("The queue is empty. There are no items to receive.");
            }

            return item;
        }
    }
}