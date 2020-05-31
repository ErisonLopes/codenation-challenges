using System;
using System.Collections.Generic;

namespace Codenation.Challenge
{
    public class Math
    {
        public List<int> Fibonacci()
        {
            List<int> fibonacciSequence = new List<int>() { 0, 1 };
            int numero = 2;
            while(fibonacciSequence[numero - 1] + fibonacciSequence[numero - 2] <= 350)
            {
                int soma = fibonacciSequence[numero - 1] + fibonacciSequence[numero - 2];
                fibonacciSequence.Add(soma);

                numero++;
            }
            return fibonacciSequence;
        }

        public bool IsFibonacci(int numberToTest)
        {
            List<int> serieFibonacci = Fibonacci();

            return serieFibonacci.Contains(numberToTest);
        }
    }
}
