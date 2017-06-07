using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning
{
    public class LearnGraph
    {
        public int[,] graph = new int[2, 2];        
    }

    public class LearnStack
    {
        Stack<int> stack = new Stack<int>();
        public void CreateStack()
        {
            stack.Push(10);
            stack.Push(100);
            stack.Push(1000);
        }
        public void ReadStack()
        {
            foreach (int i in stack)
            {
                Console.WriteLine(i);
            }
        }
    }
}
