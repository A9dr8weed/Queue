using System;

namespace Queue.Model
{
    /// <summary>
    /// Array-based queue.
    /// </summary>
    /// <typeparam name="T"> The type of data stored on the queue. </typeparam>
    public class ArrayQueue<T>
    {
        /// <summary>
        /// Array elements.
        /// </summary>
        private T[] items;

        /// <summary>
        /// First element.
        /// </summary>
        private T Head => items[Count > 0 ? Count - 1 : 0];

        /// <summary>
        /// Amount of elements.
        /// </summary>
        public int Count { get; private set; }

        public ArrayQueue(int size = 10)
        {
            items = new T[size];
            Count = 0;
        }

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

            if (Count == items.Length)
            {
                Resize(items.Length + 10); // об'єднуємо два масиви в один
                //Count++;
            }

            items[Count++] = item;
        }

        /// <summary>
        /// Get an item from the queue with removal.
        /// </summary>
        /// <returns> Data item. </returns>
        /// <exception cref="NullReferenceException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public T Dequeue()
        {
            // Pop an element from the top of the queue, decreasing the value of the variable count.
            T item = items[--Count];
            // Reset the link.
            items[Count] = default;

            // If there are more than 10 empty cells in the items array.
            if (Count > 0 && Count < items.Length - 10)
            {
                Resize(items.Length - 10);
            }

            return item;
        }

        /// <summary>
        /// Read an item from the queue without deleting it.
        /// </summary>
        /// <returns> Data item. </returns>
        /// <exception cref="NullReferenceException"></exception>
        public T Peek()
        {
            // If the element is empty, then we report an error.
            if (Head == null)
            {
                throw new NullReferenceException("The queue is empty. There are no items to receive.");
            }

            // Get an item from the front of the queue.
            return Head;
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

            for (int i = 0; i < Count; i++)
            {
                if (items[i].Equals(data))
                {
                    return $"Element {data} is in the list.";
                }
            }

            return $"Element {data} is not in the list.";
        }

        /// <summary>
        /// Resizes the array to max.
        /// </summary>
        /// <param name="max"> The size. </param>
        private void Resize(int max)
        {
            // Method creates a new array.
            T[] tempItems = new T[max];

            for (int i = 0; i < Count; i++)
            {
                // Data is copied from the old.
                tempItems[i] = items[i];
            }

            items = tempItems;
        }
    }
}