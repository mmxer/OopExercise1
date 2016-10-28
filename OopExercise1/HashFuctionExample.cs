// <copyright file="HashFuctionExample.cs" company="Maxim Prokoshin">
// Copyright (c) Maxim Prokoshin. All rights reserved.
// </copyright>

namespace OopExercise1
{
    public class HashFuctionExample : IHashFuction
    {
        /// <summary>
        /// Returns the default hash code for a key.
        /// </summary>
        /// <param name="key">A key.</param>
        /// <returns>Hash code.</returns>
        public int GetHashCode(string key)
        {
            return key.GetHashCode();
        }
    }
}
