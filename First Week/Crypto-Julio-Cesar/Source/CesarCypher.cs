using System;
using System.Collections.Generic;
using System.Linq;

namespace Codenation.Challenge
{
    public class CesarCypher : ICrypt, IDecrypt
    {
        public string Crypt(string message)
        {
            if (message == null) throw new ArgumentNullException();


            List<char> Alfabeto = "abcdefghijklmnopqrstuvwxyz".ToList();
            string resultado = string.Empty;
            int numeroCasas = 3;

            foreach (char caractere in message.ToLower())
            {
                char letraCodificada = caractere;
                if (Alfabeto.Contains(caractere))
                {
                    int posicao = Alfabeto.IndexOf(caractere);
                    posicao += numeroCasas;

                    if (posicao >= 26)
                    {
                        int posicaCodificada = posicao - Alfabeto.Count();
                        letraCodificada = Alfabeto[posicaCodificada];
                    }
                    else
                        letraCodificada = Alfabeto[posicao];
                }
                else if (!char.IsNumber(caractere) && !char.IsWhiteSpace(caractere))
                    throw new ArgumentOutOfRangeException();

                resultado += letraCodificada;
            }
            return resultado;
        }

        public string Decrypt(string cryptedMessage)
        {
            if (cryptedMessage == null) throw new ArgumentNullException();


            List<char> Alfabeto = "abcdefghijklmnopqrstuvwxyz".ToList();
            string resultado = string.Empty;
            int numeroCasas = 3;

            foreach (char caractere in cryptedMessage.ToLower())
            {
                char letraDecodificada = caractere;

                if (Alfabeto.Contains(caractere))
                {
                    int posicao = Alfabeto.IndexOf(caractere);
                    posicao -= numeroCasas;

                    if (posicao < 0)
                    {
                        int posicaoDecodificada = Alfabeto.Count() + posicao;
                        letraDecodificada = Alfabeto[posicaoDecodificada];
                    }
                    else
                        letraDecodificada = Alfabeto[posicao];
                }
                else if (!char.IsNumber(caractere) && !char.IsWhiteSpace(caractere))
                    throw new ArgumentOutOfRangeException();

                resultado += letraDecodificada;
            }
            return resultado;
        }
    }
}
