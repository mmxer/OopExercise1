﻿// <copyright file="IHashFuction.cs" company="Maxim Prokoshin">
// Copyright (c) Maxim Prokoshin. All rights reserved.
// </copyright>

namespace OopExercise1
{
    public interface IHashFuction
    {
        /// <summary>
        /// Returns the hash code for a key.
        /// </summary>
        /// <param name="key">A key.</param>
        /// <returns>Hash code.</returns>
        int GetHashCode(string key);
    }
}