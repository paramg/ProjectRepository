using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.BackTrack
{
    public class TrieDataStructure
    {
        public class TrieNode
        {
            public TrieNode[] children;
            public bool isEndOfString;
        }

        public void Insert(TrieNode root, string str)
        {
            TrieNode parent = root;
            for (int i=0;i < str.Length; i++)
            {
                int charAscii = str[i];
                if (parent.children[charAscii] == null)
                {
                    parent.children[charAscii] = new TrieNode();
                    parent.children[charAscii].isEndOfString = false;
                }
                parent = parent.children[charAscii];
            }

            parent.isEndOfString = true;
        }
    }
}
