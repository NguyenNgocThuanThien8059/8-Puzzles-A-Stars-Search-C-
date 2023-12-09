using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_Puzzle_A_Star_Search
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int [,] a = new int[3,3] { { 2, 8, 3 }, { 1, 6, 4 }, { 7, 0, 5 } };
            Console.WriteLine("- Init State:");
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    Console.Write(a[i, j] + " ");
                }
                Console.WriteLine();
            }
            Node root = new Node(a);
            A_Stars_Search ui = new A_Stars_Search();
            List<Node> Solution = ui.AStarSearch(root);
            if (Solution.Count > 0)
            {
                Solution.Reverse();
                for (int i = 0; i < Solution.Count; i++)
                {
                    Solution[i].PrintPuzzle();
                }
            }
            else
            {
                Console.WriteLine(" No Path Found ");
            }
            Console.ReadLine();
        }
    }
}
