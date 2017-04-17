using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problem.Strings
{
    [TestClass]
    public class Palindrome
    {
        public Palindrome()
        {
        }

        public int FindLongestPalindromeTrivial(string palindromeString)
        {
            // odd length.
            int longPalindrome = 1;
            int palindromeLength = 0;

            int start = 0;
            int end = 0;

            for(int i=0; i< palindromeString.Length - 1; i++)
            {
                start = i;
                end = i + 1;

                while (start > 0 && end <= palindromeString.Length - 1 &&
                    palindromeString[start] == palindromeString[end])
                {
                    start--;
                    end++;

                    palindromeLength += 2;
                }

                longPalindrome = Math.Max(longPalindrome, palindromeLength);

                start = i - 1;
                end = i + 1;

                palindromeLength = 1;
                while (start > 0 && end <= palindromeString.Length - 1 &&
                    palindromeString[start] == palindromeString[end])
                {
                    start--;
                    end++;

                    palindromeLength += 2;
                }

                longPalindrome = Math.Max(longPalindrome, palindromeLength);
            }

            return longPalindrome;
        }
        
        public int FindMaximumPalindromeString(string palindromeString)
        {
            int[] Table = new int[palindromeString.Length - 1];
            int start = 0;
            int end = 0;

            for(int i=0; i < palindromeString.Length -1;)
            { 
                // alg to validate that the string is palindrome or not.
                while(start > 0 && end < palindromeString.Length - 1 
                        && palindromeString[start - 1] == palindromeString[end + 1])
                {
                    start--;
                    end++;
                }

                Table[i] = end - start + 1;

                // Exit case...
                if (end == palindromeString.Length - 1)
                {
                    break;
                }

                // Set the new center to end. 
                // int newCenter = end + ((i % 2 == 0) ? 1 : 0);
                int newCenter = end + 1;

                /// If the new center is not the edge and it is between the current center and right edge (end)
                /// In this case we have to choose what is next center
                /// j = i+1 = Evaluate if j can be next center.
                for (int j = i + 1; j <= end; j++)
                {
                    /// Table[i-(j-i)] - mirror of the i (when you choose i as center)
                    /// 2 * (end - j + 1)
                    /// (end - j + 1) = distance between center (j = i + 1) and right edge (end)
                    /// We need to compare which one is min -  
                    /// the mirror value or distance between start and end (the left and right edge within the boundary).
                    /// Basically, some previous palindrome string could go beyond left edge, in such cases we have to take min within the boundary.
                    Table[j] = Math.Min(Table[i - (j - i)], 2 * (end - j + 1));
                    
                    /// When choosing the new center we have to evaluate :
                    /// whether the current center + mirror value / 2 is equal to the right edge (end).
                    if(end == j + Table[i - (j-i)] / 2)
                    {
                        newCenter = j;
                        break;
                    }
                }

                i = newCenter;

                /// The Table[i] contains the mirror value which is already compared, no need to compare it again.
                /// Therefore, adjust the start and end index to prevent the comparing again.
                start = i - Table[i] / 2;
                end = i + Table[i] / 2;
            }

            int maximum = 0;

            for (int i=0; i < palindromeString.Length - 1; i++)
            {
                if(maximum < Table[i])
                {
                    maximum = Table[i];
                }
            }

            return maximum;
        }

        [TestMethod]
        public void TestLongestPalindromeString()
        {
            string palindromeString = "abbababba";

            int longestPalindrome = this.FindMaximumPalindromeString(palindromeString);

            Assert.AreEqual(longestPalindrome, 9);
        }
    }
}
