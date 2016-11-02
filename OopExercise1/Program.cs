// <copyright file="Program.cs" company="Maxim Prokoshin">
// Copyright (c) Maxim Prokoshin. All rights reserved.
// </copyright>

namespace OopExercise1
{
    using System;

    internal class Program
    {
        public static void Main(string[] args)
        {
            HashTableArray repository = new HashTableArray(20, new HashFuctionExample());

            repository.Add("1", "item 1");
            repository.Add("2", "item 2");
            repository.Add("dsfdsdsd", "item 3");
            Console.WriteLine(repository.Find("1"));
            Console.WriteLine(repository.Find("2"));
            Console.WriteLine(repository.Find("dsfdsdsd"));
            repository.Remove("1");
            Console.WriteLine(repository.Find("1"));
            Console.WriteLine("Changing hash function.");
            repository.HashFunction = new HashFuctionExample();
            Console.WriteLine(repository.Find("2"));
            Console.WriteLine("Press any key.");
            Console.ReadLine();
        }
    }
}
