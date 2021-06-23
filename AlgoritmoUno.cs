using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //var result = ValidBracketSequence("{sdkj(vklvl[ ssds ]fdk(vñ)lad)fk}");
            var result = ValidBracketSequence("{sdkj(vklvl[ ssds ]fd}kdsad)fk}");

        }


        /// <summary>
        /// Validar que en el parámetro lleve una secuencia de paréntesis, llaves y corchetes.
        /// que abran y cierren
        /// sequence: "()" result: TRUE.
        /// sequence: "()[]{}" result: TRUE.
        /// sequence: "(]" result: FALSE.
        /// sequence: "([)]" result: FALSE.
        /// sequence: "{[]}" result: TRUE.
        /// </summary>
        /// <param name="sequence">cadena a validar.</param>
        /// <returns>
        /// boolean - indica si la cadena es valida (TRUE) o no (FALSE).
        /// </returns>
        private static bool ValidBracketSequence(string sequence)
        {
            bool result = true;
            Dictionary<string, string> brackets = new Dictionary<string, string> { 
                { "(", ")" },
                { "{", "}" },
                { "[", "]" }
            };


            string copy = sequence;
            List<char> initialBrackets = new List<char>();
            char[] array = sequence.ToCharArray();

            for (int i = 0; i <= array.Length - 1; i++)
            {
                char letter = array[i];
                if (brackets.ContainsKey(letter.ToString()))
                {
                    initialBrackets.Add(letter);
                }
                if (brackets.ContainsValue(letter.ToString()))
                {
                    char lastCharacter = initialBrackets.Last();
                    if (lastCharacter.ToString() == brackets.FirstOrDefault(d => d.Value == letter.ToString()).Key)
                    {
                        initialBrackets.Remove(lastCharacter);
                    }
                    else
                    {
                        result = false;
                        break;
                    }
                }
            }

            result = initialBrackets.Count <= default(int);

            return result;
        }
    }
}
