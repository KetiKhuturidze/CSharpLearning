﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericStackTask
{
    /// <summary>
    /// Represents extendable last-in-first-out (LIFO) collection of the specified type T.
    /// Internally it is implemented as an array, so Push can be O(n). Pop is O(1).
    /// </summary>
    /// <typeparam name="T">Specifies the type of elements in the stack.</typeparam>
    public class Stack<T> : IEnumerable<T>
    {
        private T[] items;
        private int count;
        private int version;

        /// <summary>
        /// Initializes a new instance of the <see cref="Stack{T}"/> class class that is empty and has the default initial capacity.
        /// </summary>
        public Stack()
        {
            this.count = 0;
            this.items = Array.Empty<T>();
            this.version = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Stack{T}"/> class that is empty and has the specified initial capacity.
        /// </summary>
        /// <param name="capacity">The initial number of elements of stack.</param>
        public Stack(int capacity)
        {
            this.version = 0;
            this.count = 0;
            this.items = new T[capacity];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Stack{T}"/> class that contains elements copied
        /// from the specified collection and has sufficient capacity to accommodate the  number of elements copied.
        /// </summary>
        /// <param name="collection">The collection to copy elements from.</param>
        public Stack(IEnumerable<T>? collection)
        {
            this.items = collection is null ? Array.Empty<T>() : collection.ToArray();
            this.count = this.items.Length;
            this.version = 0;
        }

        /// <summary>
        /// Gets the number of elements contained in the stack.
        /// </summary>
        public int Count
        {
            get
            {
                return this.count;
            }
        }

        /// <summary>
        /// Removes and returns the object at the top of the stack.
        /// </summary>
        /// <returns>The object removed from the top of the stack.</returns>
        public T Pop()
        {
            T temp = this.items.Length == 0 ? throw new InvalidOperationException(null) : this.items[this.count - 1];
            this.count--;
            this.version++;
            Array.Resize(ref this.items, this.count);
            return temp;
        }

        /// <summary>
        /// Returns the object at the top of the stack without removing it.
        /// </summary>
        /// <returns>The object at the top of the stack.</returns>
        public T Peek()
        {
            T temp = this.items[this.count - 1];
            return temp;
        }

        /// <summary>
        /// Inserts an object at the top of the stack.
        /// </summary>
        /// <param name="item">The object to push onto the stack.
        /// The value can be null for reference types.</param>
        public void Push(T item)
        {
            this.count++;
            this.version++;
            Array.Resize(ref this.items, this.count);
            this.items[this.count - 1] = item;
        }

        /// <summary>
        /// Copies the elements of stack to a new array.
        /// </summary>
        /// <returns>A new array containing copies of the elements of the stack.</returns>
        public T[] ToArray()
        {
            return this.items.Reverse().ToArray();
        }

        /// <summary>
        /// Determines whether an element is in the stack.
        /// </summary>
        /// <param name="item">The object to locate in the stack. The value can be null for reference types.</param>
        /// <returns>Return true if item is found in the stack; otherwise, false.</returns>
        public bool Contains(T item)
        {
            return this.items.Contains(item);
        }

        /// <summary>
        /// Removes all objects from the stack.
        /// </summary>
        public void Clear()
        {
            this.count = 0;
            this.items = Array.Empty<T>();
            this.version = 0;
        }

        /// <summary>
        /// Returns an enumerator for the stack.
        /// </summary>
        /// <returns>Return Enumerator object for the stack.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            var currentVersion = this.version;

            for (int i = this.items.Length - 1; i >= 0; i--)
            {
                if (currentVersion != this.version)
                {
                    throw new InvalidOperationException();
                }

                yield return this.items[i];
            }
        }

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}