﻿// <copyright file="HashTableArray.cs" company="Maxim Prokoshin">
// Copyright (c) Maxim Prokoshin. All rights reserved.
// </copyright>

namespace OopExercise1
{
    using System;
    using System.Collections.Generic;

    public class HashTableArray
    {
        private readonly int size;
        private readonly LinkedList<KeyValue>[] items;

        /// <summary>
        /// Initializes a new instance of the <see cref="HashTableArray"/> class.
        /// </summary>
        /// <param name="size">Array size.</param>
        public HashTableArray(int size)
        {
            this.size = size;
            this.items = new LinkedList<KeyValue>[size];
        }

        /// <summary>
        /// Gets or sets hash function.
        /// </summary>
        public IHashFuction HashFunction { get; set; }

        /// <summary>
        /// Finds an element by it's key.
        /// </summary>
        /// <param name="key">Element's key.</param>
        /// <returns>Element's value.</returns>
        public string Find(string key)
        {
            int position = this.GetArrayPosition(key);
            LinkedList<KeyValue> linkedList = this.GetLinkedList(position);
            foreach (KeyValue item in linkedList)
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
            int position = this.GetArrayPosition(key);
            LinkedList<KeyValue> linkedList = this.GetLinkedList(position);
            KeyValue item = new KeyValue() { Key = key, Value = value };
            linkedList.AddLast(item);
        }

        /// <summary>
        /// Removes am element from the array.
        /// </summary>
        /// <param name="key">Element's key.</param>
        public void Remove(string key)
        {
            int position = this.GetArrayPosition(key);
            LinkedList<KeyValue> linkedList = this.GetLinkedList(position);
            bool itemFound = false;
            KeyValue foundItem = default(KeyValue);
            foreach (KeyValue item in linkedList)
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
        protected int GetArrayPosition(string key)
        {
            int position = this.HashFunction.GetHashCode(key) % this.size;
            return Math.Abs(position);
        }

        /// <summary>
        /// Get bucket by it's position.
        /// Creates new bucket if not exist in the array.
        /// </summary>
        /// <param name="position">Bucket's position.</param>
        /// <returns>Bucket of elements.</returns>
        protected LinkedList<KeyValue> GetLinkedList(int position)
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
        protected struct KeyValue
        {
            public string Key { get; set; }

            public string Value { get; set; }
        }
    }
}