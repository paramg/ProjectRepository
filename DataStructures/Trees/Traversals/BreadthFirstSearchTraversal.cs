using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Libraries.Trees
{
    public class BreadthFirstSearchTraversal
    {
        public static void LevelByLevelTraversal(BinaryTreeNode root)
        {
            // Use two queues.
            // Step1: Enqueue item in q1
            // Step2: Dequeue item from q1 and find left and right and Enqueue the items to q2
            // Step3: Print the item, if the queue is empty Print newline.
            // Continue step1-3 until both the queues are empty.

            Queue<BinaryTreeNode> queue1 = new Queue<BinaryTreeNode>();
            Queue<BinaryTreeNode> queue2 = new Queue<BinaryTreeNode>();
            
            if(root != null)
            {
                queue1.Enqueue(root);
            }
            
            while(queue1.Count > 0 || queue2.Count > 0)
            {
                EnumerateQueue(queue1, queue2);

                EnumerateQueue(queue2, queue1);
            }
        }

        private static void EnumerateQueue(Queue<BinaryTreeNode> sourceQueue, Queue<BinaryTreeNode> targetQUeue)
        {
            while (sourceQueue.Count > 0)
            {
                BinaryTreeNode node = sourceQueue.Dequeue();

                if (node != null)
                {
                    // Print the node and append space.
                    Console.Write(node.Value + " ");

                    if (node.Left != null)
                    {
                        targetQUeue.Enqueue(node.Left);
                    }

                    if (node.Right != null)
                    {
                        targetQUeue.Enqueue(node.Right);
                    }

                    if (sourceQueue.Count == 0)
                    {
                        Console.WriteLine();
                    }
                }
            }
        }

        public void LevelOrderTraversal()
        {

        }
    }
}
