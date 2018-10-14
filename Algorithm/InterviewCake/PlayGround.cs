using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problem.InterviewCake
{
    [TestClass]
    public class PlayGround
    {
        public ISet<string> GetPermutations(string inputString)
        {
            // Base case
            if (inputString.Length <= 1)
            {
                return new HashSet<string>(inputString.Select(c => new string(c, 1)));
            }

            string allCharsExceptLast = inputString.Substring(0, inputString.Length - 1);
            char lastChar = inputString[inputString.Length - 1];

            // Recursive call: get all possible permutations for all chars except last
            ISet<string> permutationsOfAllCharsExceptLast = this.GetPermutations(allCharsExceptLast);

            // Put the last char in all possible positions for each of the above permutations
            var permutations = new HashSet<string>();
            foreach (string permutationOfAllCharsExceptLast in permutationsOfAllCharsExceptLast)
            {
                for (int position = 0; position <= allCharsExceptLast.Length; position++)
                {
                    string permutation = permutationOfAllCharsExceptLast.Substring(0, position)
                        + lastChar
                        + permutationOfAllCharsExceptLast.Substring(position);

                    permutations.Add(permutation);
                }
            }

            return permutations;
        }

        [TestMethod]
        public void TestPermutations()
        {
            this.GetPermutations("cats");
        }
    }
}