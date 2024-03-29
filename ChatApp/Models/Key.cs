﻿using System.Numerics;

namespace SignalRSample.Models
{
    internal class Key
    {
        private readonly int n;
        private readonly int e;
        private int d;

        internal Key(int primeOne, int primeTwo, int primeThree, List<int> primes)
        {
            n = primeOne * primeTwo * primeThree;
            var phi = (primeOne - 1) * (primeTwo - 1) * (primeThree - 1);
            var end = primes.Count - 1;
            var start = end / 4;
            var random = new Random();
            do
            {
                do
                {
                    e = primes[random.Next(start, end)];
                } while (e == primeOne || e == primeTwo || e == primeThree);
            } while (!IsFoundD(phi));
            Console.WriteLine("Public Key: (e, n) = (" + e + ", " + n + ")");
        }

        private bool IsFoundD(int phi)
        {
            for (var i = phi - 1; i > 1; i--)
            {
                var mul = BigInteger.Multiply(e, i);
                var result = BigInteger.Remainder(mul, phi);
                if (result.Equals(1))
                {
                    d = i;
                    Console.WriteLine("Private Key: (d, n) = (" + d + ", " + n + ")");
                    return true;
                }
            }
            return false;
        }

        internal int[] Encrypt(string message)
        {
            var charArray = message.ToCharArray();
            var array = new int[charArray.Length];
            for (var i = 0; i < array.Length; i++)
            {
                array[i] = (int)BigInteger.ModPow(charArray[i], e, n);
            }
            return array;
        }

        internal string Decrypt(int[] cyphertext)
        {
            var array = new char[cyphertext.Length];
            for (var i = 0; i < array.Length; i++)
            {
                array[i] = (char)BigInteger.ModPow(cyphertext[i], d, n);
            }
            return new string(array);
        }


    }
}
