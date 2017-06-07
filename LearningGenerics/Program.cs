using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningGenerics
{
    class Program
    {
        static void Main(string[] args)
        {
            //LearnStack ls = new LearnStack();
            //ls.CreateStack();
            //ls.ReadStack();
            //Console.ReadLine();
            //ls.PopStack();
            //Console.ReadLine();
            //ls.ReadStack();
            //Console.ReadLine();
            //ls.PeekStack();
            //Console.ReadLine();
            //ls.ReadStack();
            //Console.ReadLine();

            //LearnQueue lq = new LearnQueue();
            //lq.CreateQueue();
            //lq.ReadQueue();
            //Console.ReadLine();
            //lq.Deque();
            //Console.ReadLine();
            //lq.ReadQueue();
            //Console.ReadLine();
            //lq.PeekQueue();
            //Console.ReadLine();
            //lq.ReadQueue();
            //Console.ReadLine();

            //Node myNode = new Node(7);
            //myNode.AddToEnd(5);
            //myNode.AddToEnd(10);
            //myNode.AddToEnd(15);
            //myNode.Print();
            //Console.ReadLine();

            MyList list = new MyList();
            //list.AddToEnd(10);
            //list.AddToEnd(20);
            //list.AddToEnd(30);
            //list.AddToEnd(40);
            //list.AddToBeginning(10);
            //list.AddToBeginning(20);
            //list.AddToBeginning(30);
            //list.AddToBeginning(40);
            list.AddSorted(10);
            list.AddSorted(30);
            list.AddSorted(20);
            list.AddSorted(40);
            list.Print();
            Console.Read();
        }
    }

    public class LearnStack
    {
        Stack<int> stack = new Stack<int>(); // Stack is Last in First out
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
        public void PopStack()
        {
            int i = stack.Pop();
            Console.WriteLine("Pop element is: " + i);
        }
        public void PeekStack()
        {
            int i = stack.Peek();
            Console.WriteLine("Peek element is: " + i);
        }
    }

    public class LearnQueue
    {
        Queue<int> queue = new Queue<int>(); // Stack is First in First out
        public void CreateQueue()
        {
            queue.Enqueue(10);
            queue.Enqueue(100);
            queue.Enqueue(1000);
        }
        public void ReadQueue()
        {
            foreach (int i in queue)
            {
                Console.WriteLine(i);
            }
        }
        public void Deque()
        {
            int i = queue.Dequeue();
            Console.WriteLine("Deque element is: " + i);
        }
        public void PeekQueue()
        {
            int i = queue.Peek();
            Console.WriteLine("Peek element is: " + i);
        }
    }

    //public class Node
    //{
    //    public int data { get; set; }
    //    public Node left { get; set; }
    //    public Node right { get; set; }

    //    public Node(int value)
    //    {
    //        this.data = value;
    //        this.left = null;
    //        this.right = null;
    //    }
    //}

    public class Node
    {
        public int data { get; set; }
        public Node next { get; set; }

        public Node(int i)
        {
            this.data = i;
            this.next = null;
        }

        public void Print()
        {
            Console.Write("|" + this.data + "|->");

            if (next != null)
                next.Print();
        }

        public void AddSorted(int data)
        {
            if (next == null)
                next = new Node(data);
            else if (data < next.data)
            {
                Node temp = new Node(data);
                temp.next = this.next;
                this.next = temp;
            }
            else
                next.AddSorted(data);
        }

        public void AddToEnd(int data)
        {
            if (next == null)
                next = new Node(data);
            else
                next.AddToEnd(data);
        }
    }

    public class MyList
    {
        public Node headNode;

        public MyList()
        {
            this.headNode = null;
        }

        public void AddToEnd(int data)
        {
            if (headNode == null)
                this.headNode = new Node(data);
            else
                headNode.AddToEnd(data);
        }

        public void AddSorted(int data)
        {
            if (headNode == null)
                headNode = new Node(data);
            else if(data < headNode.data)
                AddToBeginning(data);
            else
                headNode.AddSorted(data);
        }

        public void AddToBeginning(int data)
        {
            if (headNode == null)
                headNode = new Node(data);
            else
            {
                Node temp = new Node(data);
                temp.next = headNode;
                headNode = temp;
            }
        }

        public void Print()
        {
            if (headNode != null)
                headNode.Print();
        }
    }
}