namespace Balanced
{
    public class Avl
    {
        Node root;

        public Avl(int[] array)
        {
            AddValues(array);
        }

        public Avl(int value)
        {
            Add(value);
        }

        public void AddValues(int[] array)
        {
            int rootIndex = (array.Count() / 2) - 1;
            var sortedItems = array.OrderBy(x => x);
            foreach (int it in sortedItems)
                Add(it);
        }

        public void Add(int value)
        {
            Node newItem = new Node(value);
            if (root == null)
                root = newItem;
            else
                root = root.RecursiveInsert(root, newItem);
        }

        public void Delete(int target)
        {//and here
            root = root.Delete(root, target);
        }

        public void Find(int key)
        {
            if (Find(key, root).Value == key)
            {
                Console.WriteLine("{0} was found!", key);
            }
            else
            {
                Console.WriteLine("Nothing found!");
            }
        }
        private Node Find(int target, Node current)
        {

            if (target < current.Value)
            {
                if (target == current.Value)
                {
                    return current;
                }
                else
                    return Find(target, current.Left);
            }
            else
            {
                if (target == current.Value)
                {
                    return current;
                }
                else
                    return Find(target, current.Right);
            }

        }
        public void DisplayTree()
        {
            if (root == null)
            {
                Console.WriteLine("Tree is empty");
                return;
            }
            root.InOrderDisplayTree(root);
            Console.WriteLine();
        }

        public string ShowTreeBF() => root.ToString().Trim();
    }
    public class Node
    {
        public Node(int value)
        {
            Value = value;
        }
        public int Value { get; set; }
        public Node? Left { get; set; }
        public Node? Right { get; set; }
        public int Height()
        {
            int leftBf = Left != null ? Left.Height() : 0;
            int rightBf = Right != null ? Right.Height() : 0;
            return 1 + Math.Max(leftBf, rightBf);
        }
        public int BF()
        {
            return (Left?.Height() ?? 0) - (Right?.Height() ?? 0);
        }
        public bool IsBalanced => Math.Abs(BF()) <= 1 && ((Left == null || Left.IsBalanced) && (Right == null || Right.IsBalanced));
        public override string ToString()
        {
            string result = string.Empty;
            if (Left != null)
                result += Left.ToString();
            result += $"{Value}(BF={BF()}) ";
            if (Right != null)
                result += Right.ToString();
            return result;
        }

        public Node RecursiveInsert(Node current, Node newNode)
        {
            if (current == null)
                current = newNode;
            if (current.Value == newNode.Value)
                return current;
            else if (newNode.Value < current.Value)
            {
                current.Left = RecursiveInsert(current.Left, newNode);
                current = Balance(current);
            }
            else
            {
                current.Right = RecursiveInsert(current.Right, newNode);
                current = Balance(current);
            }
            return current;
        }

        private Node Balance(Node current)
        {
            int factor = current.BF();
            if (factor > 1)
            {
                if (BalanceFactor(current.Left) > 0)
                    current = RotateLL(current);
                else
                    current = RotateLR(current);
            }
            else if (factor < -1)
            {
                if (BalanceFactor(current.Right) > 0)
                    current = RotateRL(current);
                else
                    current = RotateRR(current);
            }
            return current;
        }

        private int BalanceFactor(Node node)
        {
            return node == null ? 0 : node.BF();
        }

        public Node Delete(Node current, int target)
        {
            Node parent;
            if (current == null)
            { return null; }
            else
            {
                //left subtree
                if (target < current.Value)
                {
                    current.Left = Delete(current.Left, target);
                    if (BalanceFactor(current) == -2)//here
                    {
                        if (BalanceFactor(current.Right) <= 0)
                        {
                            current = RotateRR(current);
                        }
                        else
                        {
                            current = RotateRL(current);
                        }
                    }
                }
                //right subtree
                else if (target > current.Value)
                {
                    current.Right = Delete(current.Right, target);
                    if (BalanceFactor(current) == 2)
                    {
                        if (BalanceFactor(current.Left) >= 0)
                        {
                            current = RotateLL(current);
                        }
                        else
                        {
                            current = RotateLR(current);
                        }
                    }
                }
                //if target is found
                else
                {
                    if (current.Right != null)
                    {
                        //delete its inorder successor
                        parent = current.Right;
                        while (parent.Left != null)
                        {
                            parent = parent.Left;
                        }
                        current.Value = parent.Value;
                        current.Right = Delete(current.Right, parent.Value);
                        if (BalanceFactor(current) == 2)//rebalancing
                        {
                            if (BalanceFactor(current.Left) >= 0)
                            {
                                current = RotateLL(current);
                            }
                            else { current = RotateLR(current); }
                        }
                    }
                    else
                    {   //if current.left != null
                        return current.Left;
                    }
                }
            }
            return current;
        }


        public void InOrderDisplayTree(Node current)
        {
            if (current != null)
            {
                InOrderDisplayTree(current.Left);
                Console.Write("({0}) ", current.Value);
                InOrderDisplayTree(current.Right);
            }
        }

        private Node RotateRR(Node parent)
        {
            Node pivot = parent.Right;
            parent.Right = pivot.Left;
            pivot.Left = parent;
            return pivot;
        }
        private Node RotateLL(Node parent)
        {
            Node pivot = parent.Left;
            parent.Left = pivot.Right;
            pivot.Right = parent;
            return pivot;
        }
        private Node RotateLR(Node parent)
        {
            Node pivot = parent.Left;
            parent.Left = RotateRR(pivot);
            return RotateLL(parent);
        }
        private Node RotateRL(Node parent)
        {
            Node pivot = parent.Right;
            parent.Right = RotateLL(pivot);
            return RotateRR(parent);
        }
    }
}