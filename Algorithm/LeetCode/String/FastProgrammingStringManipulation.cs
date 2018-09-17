using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.String
{
    [TestClass]
    public class FastProgrammingStringManipulation
    {
        public bool IsAnagram(string str1, string str2)
        {
            if (str1.Length != str2.Length) return false;

            int[] hash = new int[256];
            for (int i=0; i< str1.Length; i++)
            {
                int asciiVal =  (int)str1[i];
                hash[asciiVal] += 1;
            }

            for (int i= 0;i < str2.Length; i++)
            {
                if ( hash[(int)str2[i]] > 0)
                {
                    hash[(int)str2[i]]--;
                }
                else
                {
                    return false;
                }
            }

            for (int i = 0; i < str1.Length; i++)
            {
                if (hash[(int)str1.Length] > 0)
                {
                    return false;
                }
            }
            return true;
        }

        public string ReverseWordsInSentence(string sentence)
        {
            int startIndex = 0;
            int endIndex = 0;

            // My name is Paramaguru
            for (int i = 0; i < sentence.Length; i++)
            {
                endIndex = i;

                if (sentence[i] == ' ' || i == sentence.Length - 1)
                {
                    if (i == sentence.Length - 1) endIndex = sentence.Length;

                    // Reverse the word the start and endIndex
                    string reverseWord = this.ReverseWords(sentence.ToCharArray(), startIndex, endIndex -1);
                    sentence = sentence.Replace(sentence.Substring(startIndex, endIndex - startIndex), reverseWord);

                    startIndex = i + 1;
                }
            }

            string reversedSentence = this.ReverseWords(sentence.ToCharArray(), 0, sentence.Length - 1);

            return reversedSentence;
        }
        private string ReverseWords(char[] sentence, int orgstartIndex, int orgendIndex)
        {
            int startIndex = orgstartIndex;
            int endIndex = orgendIndex;

            while(startIndex < endIndex)
            {
                char temp = sentence[startIndex];
                sentence[startIndex] = sentence[endIndex];
                sentence[endIndex] = temp;

                startIndex++;
                endIndex--;
            }

            string tempStr = new string(sentence);

            return tempStr.Substring(orgstartIndex, (orgendIndex - orgstartIndex) + 1);
        }

        [TestMethod]
        public void TestReverseWords()
        {
            string str = "My name is paramaguru";
            string result = this.ReverseWordsInSentence(str);
        }

        [TestMethod]
        public void TestIsAnagram()
        {
            string str1 = "badcredit";
            string str2 = "debitcard";

            bool result = this.IsAnagram(str1, str2);
        }
     }
}