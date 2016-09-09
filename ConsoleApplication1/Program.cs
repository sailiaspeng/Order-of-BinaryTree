using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            start:
            Console.WriteLine("Please input the Node(5个):");
            int count = 0;
            int id;
            Random te=new Random();
            
            string name;
            BinaryTree BTree=new BinaryTree(null);
            while (count < 5)
            {
               // Console.WriteLine("Input the Id:");
                id = te.Next(1000);
                   // int.Parse(Console.ReadLine());
                Console.WriteLine("Input the Name:");
                name = Console.ReadLine();
                Data data = new Data(id, name);
                Node node=new Node();
                node._data = data;
                BTree.addNode(node);
                BTree.TempNode = BTree.HeadNode;
                count++;
            }
            Console.WriteLine("先序遍历结果:------------------------------");
            BTree.FrontedDisplay(BTree.HeadNode);
            Console.WriteLine("中序遍历遍历结果:------------------------------");
            BTree.MidDisplay(BTree.HeadNode);
            Console.WriteLine("后序遍历结果:------------------------------");
            BTree.LastDisplay(BTree.HeadNode);
            Console.ReadLine();
            goto start;
        }
    }
    public class BinaryTree
    {
        public Node HeadNode;
        public Node TempNode;
        public BinaryTree(Node node)
        {
            HeadNode = node;
            TempNode = HeadNode;
        }
        public void addNode(Node node)
        {
            //如果没有头结点
            if (this.TempNode == null)
            {
                this.HeadNode = node;
                TempNode = this.HeadNode;
            }
            //有头结点
            else
            {
                if (node._data.Id <= TempNode._data.Id)
                {
                    if (TempNode.leftNode != null)
                    {
                        TempNode = TempNode.leftNode;
                        addNode(node);
                    }
                    else
                    {
                        TempNode.leftNode = node;
                        TempNode = TempNode.leftNode;
                    }
                }
                else {
                    if (TempNode.rightNode != null)
                    {
                        TempNode = TempNode.rightNode;
                        addNode(node);
                    }
                    else
                    {
                        TempNode.rightNode = node;
                        TempNode = TempNode.rightNode;
                    }
                }

            }
        }
        public void FrontedDisplay(Node node)
        {
            if (node != null)
            {
                Console.WriteLine("Id:" + node._data.Id + "   Name:" + node._data.Name);
                FrontedDisplay(node.leftNode);
                FrontedDisplay(node.rightNode);  
            }
        }
        public void MidDisplay(Node node)
        {
            if (node != null)
            {
                MidDisplay(node.leftNode);
                Console.WriteLine("Id:" + node._data.Id + "   Name:" + node._data.Name);
                MidDisplay(node.rightNode);
            }
        }
        public void LastDisplay(Node node)
        {
            if (node != null)
            {
                LastDisplay(node.leftNode);
                LastDisplay(node.rightNode);
                Console.WriteLine("Id:" + node._data.Id + "   Name:" + node._data.Name);
            }
        }

    }
   public class Data
    {
        public int Id;
        public string Name;
        public Data(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
    public class Node
    {
        private Data data;
        private Node left_node;
        private Node right_node;
        public Data _data
        {
            get { return data; }
            set { data=value; }
        }
        public Node leftNode{
            get { return left_node;}
            set { left_node = value; }
        }
        public Node rightNode
        {
            get { return right_node; }
            set { right_node = value; }
        }
    }
}
