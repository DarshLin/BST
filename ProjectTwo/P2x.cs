//Darsh Lin
//P2
//September 1, 2015

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTwo
{
    class P2x
    {
        static void Main(string[] args)
        {
            BST<int> binary = new BST<int>();
            /*
                                                [80]
             *                        [60]                   [100]
             *                  [40]         [75]       [95]           [120]     
             *               [20]  [50]  [65]        [85]           [110]   [140]
             */

            binary.Insert(80);//insert list of numbers
            binary.Insert(60);
            binary.Insert(40);
            binary.Insert(20);     
            binary.Insert(100);
            binary.Insert(120);
            binary.Insert(140);
            binary.Insert(75);
            binary.Insert(50);
            binary.Insert(65);
            binary.Insert(90);
            binary.Insert(95);
            binary.Insert(85); //deleted
            binary.Insert(110);
            
            binary.Delete(90); //delete 85 and rearrange

            Console.Write("Display level order: "); //extra credit
            binary.DisplayLevelOrder();
            Console.WriteLine();
            Console.WriteLine("Width: {0}", binary.GetWidth());

            Console.WriteLine("Empty tree? {0}", binary.Empty());//check for empty, should be false
            Console.WriteLine("Search: {0}",binary.Search(110)); //search for 110 should be true
            Console.WriteLine("Number of nodes in tree: {0}",binary.NumNodes()); //find number of nodes through count 14 - 1 nodes
            Console.WriteLine("Number of leaf nodes in tree: {0}", binary.NumLeafNodes()); // find nodes with no children 6
            Console.WriteLine("Height of tree: {0}", binary.GetHeight()); //get height of the tree not including root, should be 4
            Console.WriteLine("Level Search: {0}", binary.Level(65)); //search how fr down 65 is which is 3 down


            binary.DisplayInOrder(); //display in order
            Console.WriteLine();
            binary.DisplayPreOrder(); //display pre order
            Console.WriteLine();
            binary.DisplayPostOrder(); //display post order
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Ancestors: {0}", binary.DisplayAncestors(85));//should be 95 100 and 80 behind it from the tree
            
            Console.ReadKey();

        }
    }
}
