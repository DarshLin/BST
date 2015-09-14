using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTwo
{

    public class BST<T> where T : IComparable
    {
        private BSTNode root; //data fields
        private int count;
        private int lvl;

        public BST()//default constructor
        {
            this.root = null;
            this.count = 0;
        }

        public int Count //properties
        {
            get { return count; }
        }

        public int Lvl
        {
            get { return lvl; }
            set { lvl = value; }
        }


        public int GetWidth()
        {
            return GetWidth(this.root);
        }

        private int GetWidth(BSTNode root) //extra credit
        {
            int level = 0;
            int maxWidth = 0;
            Queue<BSTNode> q = new Queue<BSTNode>();//new queue

            if (root == null) //for when there's nothing
                return 0;
            q.Enqueue(root);//add something

            while (q.Count != 0)//count is at 1 in the beginning
            {
                level = q.Count();//level is the amount the q has which should be 1 at first
                if (level > maxWidth) //max width is assigned level every iteration 
                {
                    maxWidth = level;
                }
                while (level > 0) //level tracker
                {
                    BSTNode n = (BSTNode)q.Dequeue(); //n would equal the first dequeue
                    if (n.left != null) q.Enqueue(n.left); //take in left if there is anything
                    if (n.right != null) q.Enqueue(n.right); //take in right if there is anything
                    level--; //level goes down til it reaches 0
                }
            }
            return maxWidth; //max width is returned after the whole process
        }
        public void DisplayLevelOrder()
        {
            DisplayLevelOrder(this.root);
        }
        private void DisplayLevelOrder(BSTNode root)
        {
            Queue<BSTNode> q = new Queue<BSTNode>();

            while (root != null)
            {
                root.DisplayNode();
                q.Enqueue(root.left);
                q.Enqueue(root.right);
                root = q.Dequeue();
            }
        }

        public bool Empty() //check for empty
        {
            if (root == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Insert(T val)
        {
            BSTNode n = new BSTNode(val);

            if (root == null) //if the tree is empty, make a new node
            {
                root = n;
                count++;
            }
            else
            {
                BSTNode current = root; //if not empty the node current becomes the root
                while (true)
                {
                    BSTNode parent = current; //the node prent gets everything from current
                    if (n.data.CompareTo(current.data) < 0) //if the data from the root is less than the current data
                    {
                        current = current.left; //current moves left
                        if (current == null) //if current left does not exist
                        {
                            parent.left = n; //give the root data to left of parent
                            n = parent; //change root data to parent
                            count++; //this is to count nodes
                            return; //break out of recurse
                        }
                    }

                    else //everything on top but for right
                    {
                        current = current.right;
                        if (current == null)
                        {
                            parent.right = n;
                            n = parent;
                            count++;
                            return;
                        }
                    }
                }
            }
        }
        

       
        public bool Search(T val)
        {
            return Search(this.root, val);
        }
        private bool Search(BSTNode root, T val)
        {
            if (root == null) //cant search nothing
                return false;
            else if (val.CompareTo(root.data) == 0) //if the data = 0, its found
                return true;
            else if (val.CompareTo(root.data) < 0) //if the data is less, move left and recurse
                return Search(root.left, val);
            else
                return Search(root.right, val);//if the data is more, move right and recurse
            
        }
        private BSTNode Min(BSTNode root) //helper function for delete to find the minimum value
        {
            if (root == null)
            {
                return null;
            }
            else if (root.left == null)
            {
                return root;
            }
            return Min(root.left);
        }
        public void Delete(T val)
        {
            if (Search(val) == true)
            {
                Delete(this.root, val);
                count--;
            }
        }
        private BSTNode Delete(BSTNode root, T val)
        {
            if (root == null) //cant delete nothing
                return root;
            else if (val.CompareTo(root.data) < 0) //if value is lower, move left and recurse
                root.left = Delete(root.left, val);
            else if (val.CompareTo(root.data) > 0) //if value is higher, move right and recurse
                root.right = Delete(root.right, val);
            else
            {
                //No child(leaf)
                if (root.left == null && root.right == null)
                {
                    root = null;
                    
                }
                //One child
                else if (root.left == null) //if there's no left, move right
                {
                    BSTNode temp = root;
                    root = root.right;
                    temp = null;
                }
                else if (root.left == null) //if there's no right, move left
                {
                    BSTNode temp = root;
                    root = root.left;
                    temp = null;
                }
                //2 children
                else
                {
                    BSTNode temp = Min(root.right);//find min value in right
                    root.data = temp.data; //move root to temporary storage
                    root.right = Delete(root.right, temp.data); //recurse with right and root data
                }
            }
            return root;

            
        }
        public int NumNodes()
        {
            return NumNodes(this.root);
        }
        private int NumNodes(BSTNode root)
        {
            if (Empty())
                return 0;
            else if (root.left == null && root.right == null)
                return 1;
            else
                return count;
        }
        public int NumLeafNodes()
        {
            return NumLeafNodes(this.root);
        }
        public int NumLeafNodes(BSTNode root)
        {
            if (root == null)
                return 0;
            if (root.left == null && root.right == null)
                return 1;
            else
                return NumLeafNodes(root.left) + NumLeafNodes(root.right);
        }
        public int GetHeight()
        {
            return GetHeight(this.root);
        }

        private int GetHeight(BSTNode root)
        {
            if (root == null)
                return -1;
            else if (root.left == null && root.right == null)
                return 1;
            else
                return Math.Max(GetHeight(root.left), GetHeight(root.right)) + 1;
        }
        public int Level(T val)
        {
            return Level(this.root, val, lvl);
        }
        private int Level(BSTNode root, T val, int lvl)
        {
            if (root == null)
                return -1;
            if (val.CompareTo(root.data) == 0)
                return lvl;
            if (root.left == null && root.right == null)
                return -1;
            int lvlleft = Level(root.left, val, lvl + 1);
            int lvlright = Level(root.right, val, lvl + 1);

            if (lvlleft == -1)
                return lvlright;
            else 
                return lvlleft;
        }
            
        public void DisplayInOrder()
        {
            DisplayInOrder(this.root);

        }
        private void DisplayInOrder(BSTNode root)
        {
            if (root != null)
            {
                if (root.left != null)
                    DisplayInOrder(root.left);
                root.DisplayNode();

                if (root.right != null)
                    DisplayInOrder(root.right);
            }
            else return;
        }
        public void DisplayPreOrder()
        {
            DisplayPreOrder(this.root);
        }
        private void DisplayPreOrder(BSTNode root)
        {
            if (root != null)
            {
                root.DisplayNode();
                DisplayPreOrder(root.left);
                DisplayPreOrder(root.right);
            }
            else return;
        }
        public void DisplayPostOrder()
        {
            DisplayPostOrder(this.root);
        }

        private void DisplayPostOrder(BSTNode root)
        {
            if (root != null)
            {
                DisplayPostOrder(root.left);
                DisplayPostOrder(root.right);
                root.DisplayNode();
            }
            else return;
        }
        public bool DisplayAncestors(T val) //false temp
        {
            return DisplayAncestors(this.root, val);
        }
        private bool DisplayAncestors(BSTNode root, T val)
        {
            if (root == null)
                return false;

            if (val.CompareTo(root.data) == 0)
                return true;
            if (DisplayAncestors(root.left, val) || DisplayAncestors(root.right, val))
            {
                root.DisplayNode();
                return true;
            }
            else 
                return false;
        }
       public class BSTNode
        {
            internal T data { get; set; }
            internal BSTNode left { get; set; }
            internal BSTNode right { get; set; }

            public BSTNode(T data)
            {
                this.data = data;
                this.left = null;
                this.right = null;
            }

            public BSTNode(T data, BSTNode left, BSTNode right)
            {
                this.data = data;
                this.left = left;
                this.right = right;
            }

            public void DisplayNode()
            {
                Console.Write(data + " ");
            }
        } 

    }
}


//Console.Write("Input a Key and a Value: ");
                //Console.WriteLine();
                //Console.Write("Key: ");
                //key = Convert.ToInt32(Console.ReadLine());
                //Console.Write("Value: ");
                //value = Convert.ToInt32(Console.ReadLine());

