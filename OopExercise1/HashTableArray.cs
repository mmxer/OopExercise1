// <copyright file="HashTableArray.cs" company="Maxim Prokoshin">
// Copyright (c) Maxim Prokoshin. All rights reserved.
// </copyright>

namespace OopExercise1
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Hash table array uses hash table to store and access items.
    /// </summary>
    public sealed class HashTableArray
    {
        private readonly int size;
        private LinkedList<KeyValue>[] items;
        private IHashFuction hashFunction;

        /// <summary>
        /// Initializes a new instance of the <see cref="HashTableArray"/> class.
        /// </summary>
        /// <param name="size">Array size.</param>
        /// <param name="hashFunction">Hash function.</param>
        public HashTableArray(int size, IHashFuction hashFunction)
        {
            this.size = size;
            this.hashFunction = hashFunction;
            this.items = new LinkedList<KeyValue>[size];
        }

        /// <summary>
        /// Gets or sets hash function.
        /// </summary>
        public IHashFuction HashFunction
        {
            get
            {
                return this.hashFunction;
            }

            set
            {
                // Update our hash table with new hash function:
                // move all items to new positions.
                var tempItems = new LinkedList<KeyValue>[this.size];
                for (var i = 0; i < this.items.Length; i++)
                {
                    var linkedList = this.items[i];
                    if (linkedList != null)
                    {
                        var tempLinkedList = new LinkedList<KeyValue>();
                        foreach (var item in linkedList)
                        {
                            tempLinkedList.AddLast(item);
                        }

                        tempItems[i] = tempLinkedList;
                    }
                }

                this.items = new LinkedList<KeyValue>[this.size];
                this.hashFunction = value;
                for (var i = 0; i < tempItems.Length; i++)
                {
                    var linkedList = tempItems[i];
                    if (linkedList != null)
                    {
                        foreach (var item in linkedList)
                        {
                            this.Add(item.Key, item.Value);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Finds an element by it's key.
        /// </summary>
        /// <param name="key">Element's key.</param>
        /// <returns>Element's value.</returns>
        public string Find(string key)
        {
            var position = this.GetArrayPosition(key);
            var linkedList = this.GetLinkedList(position);
            foreach (var item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    return item.Value;
                }
            }

            return null;
        }

        /// <summary>
        /// Adds an element to the array.
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        public void Add(string key, string value)
        {
            var position = this.GetArrayPosition(key);
            var linkedList = this.GetLinkedList(position);

            // Check if we already have this key.
            foreach (var item in linkedList)
            {
                // We don't want to duplicate keys.
                if (item.Key.Equals(key))
                {
                    linkedList.Remove(item);
                    break;
                }
            }

            linkedList.AddLast(new KeyValue() { Key = key, Value = value });
        }

        /// <summary>
        /// Removes am element from the array.
        /// </summary>
        /// <param name="key">Element's key.</param>
        public void Remove(string key)
        {
            var position = this.GetArrayPosition(key);
            var linkedList = this.GetLinkedList(position);
            var itemFound = false;
            var foundItem = default(KeyValue);
            foreach (var item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    itemFound = true;
                    foundItem = item;
                }
            }

            if (itemFound)
            {
                linkedList.Remove(foundItem);
            }
        }

        /// <summary>
        /// Gets bucket's position in the array.
        /// </summary>
        /// <param name="key">Bucket's key.</param>
        /// <returns>Position.</returns>
        private int GetArrayPosition(string key)
        {
            var position = this.HashFunction.GetHashCode(key) % this.size;
            return Math.Abs(position);
        }

        /// <summary>
        /// Get bucket by it's position.
        /// Creates new bucket if not exist in the array.
        /// </summary>
        /// <param name="position">Bucket's position.</param>
        /// <returns>Bucket of elements.</returns>
        private LinkedList<KeyValue> GetLinkedList(int position)
        {
            LinkedList<KeyValue> linkedList = this.items[position];
            if (linkedList == null)
            {
                linkedList = new LinkedList<KeyValue>();
                this.items[position] = linkedList;
            }

            return linkedList;
        }

        /// <summary>
        /// Array's element.
        /// </summary>
        private struct KeyValue
        {
            public string Key { get; set; }

            public string Value { get; set; }
        }
    }
}
