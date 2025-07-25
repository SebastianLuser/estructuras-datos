﻿namespace Estructuras_de_Datos.Structures.Hierarchical
{
    public class AVLNode<T>
    {
        public T Data { get; set; }
        public AVLNode<T> Left { get; set; }
        public AVLNode<T> Right { get; set; }
        public AVLNode<T> Parent { get; set; }
        public int Height { get; set; }

        public AVLNode(T data)
        {
            Data = data;
            Left = null;
            Right = null;
            Parent = null;
            Height = 1;
        }

        public bool IsLeaf()
        {
            return Left == null && Right == null;
        }

        public bool HasBothChildren()
        {
            return Left != null && Right != null;
        }

        public bool HasOnlyLeftChild()
        {
            return Left != null && Right == null;
        }

        public bool HasOnlyRightChild()
        {
            return Left == null && Right != null;
        }
    }
    public class AVLTree<T> : ITree<T>
    {
        public AVLNode<T> Root { get; set; }
        private IComparer<T> comparer;

        public AVLTree()
        {
            Root = null;
            comparer = Comparer<T>.Default;
        }

        public AVLTree(IComparer<T> customComparer)
        {
            Root = null;
            comparer = customComparer;
        }

        public AVLTree(T rootData)
        {
            Root = new AVLNode<T>(rootData);
            comparer = Comparer<T>.Default;
        }

        public AVLTree(T rootData, IComparer<T> customComparer)
        {
            Root = new AVLNode<T>(rootData);
            comparer = customComparer;
        }

        public void SetComparer(IComparer<T> customComparer)
        {
            comparer = customComparer;
        }

        public void Insert(T element)
        {
            Root = InsertRecursive(Root, element);
        }

        public bool Search(T element)
        {
            return SearchRecursive(Root, element);
        }

        public bool Remove(T element)
        {
            int initialCount = CountNodes();
            Root = RemoveRecursive(Root, element);
            return CountNodes() < initialCount;
        }

        public bool IsEmpty()
        {
            return Root == null;
        }

        public int CountNodes()
        {
            return CountNodesRecursive(Root);
        }

        public int Height()
        {
            return HeightRecursive(Root);
        }

        private int HeightRecursive(AVLNode<T> node)
        {
            if (node == null) return -1;
    
            int leftHeight = HeightRecursive(node.Left);
            int rightHeight = HeightRecursive(node.Right);
    
            return Math.Max(leftHeight, rightHeight) + 1;
        }
        
        public T FindMinimum()
        {
            if (Root == null)
                throw new InvalidOperationException("Tree is empty");
            
            AVLNode<T> minNode = FindMinimumNode(Root);
            return minNode.Data;
        }

        public T FindMaximum()
        {
            if (Root == null)
                throw new InvalidOperationException("Tree is empty");
            
            AVLNode<T> maxNode = FindMaximumNode(Root);
            return maxNode.Data;
        }

        public T FindSuccessor(T element)
        {
            AVLNode<T> node = SearchNodeRecursive(Root, element);
            if (node == null)
                throw new ArgumentException("Element not found in tree");

            AVLNode<T> successor = FindSuccessorNode(node);
            if (successor == null)
                throw new ArgumentException("No successor found");

            return successor.Data;
        }

        public T FindPredecessor(T element)
        {
            AVLNode<T> node = SearchNodeRecursive(Root, element);
            if (node == null)
                throw new ArgumentException("Element not found in tree");

            AVLNode<T> predecessor = FindPredecessorNode(node);
            if (predecessor == null)
                throw new ArgumentException("No predecessor found");

            return predecessor.Data;
        }

        public void InOrder()
        {
            if (Root == null)
            {
                Console.WriteLine("Tree is empty");
                return;
            }

            Console.Write("InOrder: ");
            InOrderRecursive(Root);
            Console.WriteLine();
        }

        public void PreOrder()
        {
            if (Root == null)
            {
                Console.WriteLine("Tree is empty");
                return;
            }

            Console.Write("PreOrder: ");
            PreOrderRecursive(Root);
            Console.WriteLine();
        }

        public void PostOrder()
        {
            if (Root == null)
            {
                Console.WriteLine("Tree is empty");
                return;
            }

            Console.Write("PostOrder: ");
            PostOrderRecursive(Root);
            Console.WriteLine();
        }

        public void LevelOrder()
        {
            if (Root == null)
            {
                Console.WriteLine("Tree is empty");
                return;
            }

            Console.Write("LevelOrder: ");
            Queue<AVLNode<T>> queue = new Queue<AVLNode<T>>();
            queue.Enqueue(Root);

            while (queue.Count > 0)
            {
                AVLNode<T> current = queue.Dequeue();
                Console.Write(current.Data + " ");

                if (current.Left != null)
                    queue.Enqueue(current.Left);
                if (current.Right != null)
                    queue.Enqueue(current.Right);
            }
            Console.WriteLine();
        }

        public bool IsValidBST()
        {
            return IsValidBSTRecursive(Root, default(T), default(T), false, false);
        }

        public List<T> GetElementsInRange(T min, T max)
        {
            List<T> result = new List<T>();
            GetElementsInRangeRecursive(Root, min, max, result);
            return result;
        }

        public List<T> GetSortedElements()
        {
            List<T> result = new List<T>();
            InOrderToList(Root, result);
            return result;
        }

        public void DisplayTree()
        {
            if (Root == null)
            {
                Console.WriteLine("Tree is empty");
                return;
            }

            DisplayTreeRecursive(Root, 0, "Root: ");
        }

        public bool IsBalanced()
        {
            return CheckBalanced(Root) != -1;
        }

        private AVLNode<T> InsertRecursive(AVLNode<T> node, T element)
        {
            if (node == null)
                return new AVLNode<T>(element);

            int comparison = comparer.Compare(element, node.Data);

            if (comparison < 0)
            {
                node.Left = InsertRecursive(node.Left, element);
                if (node.Left != null)
                    node.Left.Parent = node;
            }
            else if (comparison > 0)
            {
                node.Right = InsertRecursive(node.Right, element);
                if (node.Right != null)
                    node.Right.Parent = node;
            }
            else
                return node;

            node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));
            int balance = GetBalanceFactor(node);

            if (balance > 1 && comparer.Compare(element, node.Left.Data) < 0)
                return RotateRight(node);

            if (balance < -1 && comparer.Compare(element, node.Right.Data) > 0)
                return RotateLeft(node);

            if (balance > 1 && comparer.Compare(element, node.Left.Data) > 0)
            {
                node.Left = RotateLeft(node.Left);
                return RotateRight(node);
            }

            if (balance < -1 && comparer.Compare(element, node.Right.Data) < 0)
            {
                node.Right = RotateRight(node.Right);
                return RotateLeft(node);
            }

            return node;
        }

        private bool SearchRecursive(AVLNode<T> node, T element)
        {
            if (node == null) return false;

            int comparison = comparer.Compare(element, node.Data);
            
            if (comparison == 0) return true;
            else if (comparison < 0) return SearchRecursive(node.Left, element);
            else return SearchRecursive(node.Right, element);
        }

        private AVLNode<T> SearchNodeRecursive(AVLNode<T> node, T element)
        {
            if (node == null) return null;

            int comparison = comparer.Compare(element, node.Data);
            
            if (comparison == 0) return node;
            else if (comparison < 0) return SearchNodeRecursive(node.Left, element);
            else return SearchNodeRecursive(node.Right, element);
        }

        private AVLNode<T> RemoveRecursive(AVLNode<T> node, T element)
        {
            if (node == null) return null;

            int comparison = comparer.Compare(element, node.Data);

            if (comparison < 0)
            {
                node.Left = RemoveRecursive(node.Left, element);
            }
            else if (comparison > 0)
            {
                node.Right = RemoveRecursive(node.Right, element);
            }
            else
            {
                if (node.IsLeaf())
                    return null;
                
                if (node.HasOnlyLeftChild())
                    return node.Left;
                
                if (node.HasOnlyRightChild())
                    return node.Right;
                
                AVLNode<T> successor = FindMinimumNode(node.Right);
                node.Data = successor.Data;
                node.Right = RemoveRecursive(node.Right, successor.Data);
            }

            if (node == null) return null;

            node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));
            int balance = GetBalanceFactor(node);

            if (balance > 1 && GetBalanceFactor(node.Left) >= 0)
                return RotateRight(node);

            if (balance > 1 && GetBalanceFactor(node.Left) < 0)
            {
                node.Left = RotateLeft(node.Left);
                return RotateRight(node);
            }

            if (balance < -1 && GetBalanceFactor(node.Right) <= 0)
                return RotateLeft(node);

            if (balance < -1 && GetBalanceFactor(node.Right) > 0)
            {
                node.Right = RotateRight(node.Right);
                return RotateLeft(node);
            }

            return node;
        }

        private int GetHeight(AVLNode<T> node)
        {
            return node?.Height ?? 0;
        }

        private int GetBalanceFactor(AVLNode<T> node)
        {
            return node == null ? 0 : GetHeight(node.Left) - GetHeight(node.Right);
        }

        private AVLNode<T> RotateRight(AVLNode<T> y)
        {
            AVLNode<T> x = y.Left;
            AVLNode<T> T2 = x.Right;

            x.Right = y;
            y.Left = T2;

            if (T2 != null) T2.Parent = y;
            x.Parent = y.Parent;
            y.Parent = x;

            y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;
            x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;

            return x;
        }

        private AVLNode<T> RotateLeft(AVLNode<T> x)
        {
            AVLNode<T> y = x.Right;
            AVLNode<T> T2 = y.Left;

            y.Left = x;
            x.Right = T2;

            if (T2 != null) T2.Parent = x;
            y.Parent = x.Parent;
            x.Parent = y;

            x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;
            y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;

            return y;
        }

        private AVLNode<T> FindMinimumNode(AVLNode<T> node)
        {
            while (node.Left != null)
                node = node.Left;
            return node;
        }

        private AVLNode<T> FindMaximumNode(AVLNode<T> node)
        {
            while (node.Right != null)
                node = node.Right;
            return node;
        }

        private AVLNode<T> FindSuccessorNode(AVLNode<T> node)
        {
            if (node.Right != null)
                return FindMinimumNode(node.Right);

            AVLNode<T> current = node;
            AVLNode<T> parent = node.Parent;
            
            while (parent != null && current == parent.Right)
            {
                current = parent;
                parent = parent.Parent;
            }
            
            return parent;
        }

        private AVLNode<T> FindPredecessorNode(AVLNode<T> node)
        {
            if (node.Left != null)
                return FindMaximumNode(node.Left);

            AVLNode<T> current = node;
            AVLNode<T> parent = node.Parent;
            
            while (parent != null && current == parent.Left)
            {
                current = parent;
                parent = parent.Parent;
            }
            
            return parent;
        }

        private int CountNodesRecursive(AVLNode<T> node)
        {
            if (node == null) return 0;
            return 1 + CountNodesRecursive(node.Left) + CountNodesRecursive(node.Right);
        }

        private void InOrderRecursive(AVLNode<T> node)
        {
            if (node != null)
            {
                InOrderRecursive(node.Left);
                Console.Write(node.Data + " ");
                InOrderRecursive(node.Right);
            }
        }

        private void PreOrderRecursive(AVLNode<T> node)
        {
            if (node != null)
            {
                Console.Write(node.Data + " ");
                PreOrderRecursive(node.Left);
                PreOrderRecursive(node.Right);
            }
        }

        private void PostOrderRecursive(AVLNode<T> node)
        {
            if (node != null)
            {
                PostOrderRecursive(node.Left);
                PostOrderRecursive(node.Right);
                Console.Write(node.Data + " ");
            }
        }

        private bool IsValidBSTRecursive(AVLNode<T> node, T min, T max, bool hasMin, bool hasMax)
        {
            if (node == null) return true;

            if (hasMin && comparer.Compare(node.Data, min) <= 0) return false;
            if (hasMax && comparer.Compare(node.Data, max) >= 0) return false;

            return IsValidBSTRecursive(node.Left, min, node.Data, hasMin, true) &&
                   IsValidBSTRecursive(node.Right, node.Data, max, true, hasMax);
        }

        private void GetElementsInRangeRecursive(AVLNode<T> node, T min, T max, List<T> result)
        {
            if (node == null) return;

            if (comparer.Compare(node.Data, min) > 0)
                GetElementsInRangeRecursive(node.Left, min, max, result);

            if (comparer.Compare(node.Data, min) >= 0 && comparer.Compare(node.Data, max) <= 0)
                result.Add(node.Data);

            if (comparer.Compare(node.Data, max) < 0)
                GetElementsInRangeRecursive(node.Right, min, max, result);
        }

        private void InOrderToList(AVLNode<T> node, List<T> result)
        {
            if (node != null)
            {
                InOrderToList(node.Left, result);
                result.Add(node.Data);
                InOrderToList(node.Right, result);
            }
        }

        private void DisplayTreeRecursive(AVLNode<T> node, int level, string prefix)
        {
            if (node == null) return;

            string indentation = new string(' ', level * 4);
            Console.WriteLine($"{indentation}{prefix}{node.Data} (h:{node.Height}, bf:{GetBalanceFactor(node)})");

            if (node.Left != null || node.Right != null)
            {
                DisplayTreeRecursive(node.Left, level + 1, "L--- ");
                DisplayTreeRecursive(node.Right, level + 1, "R--- ");
            }
        }

        private int CheckBalanced(AVLNode<T> node)
        {
            if (node == null) return 0;

            int leftHeight = CheckBalanced(node.Left);
            if (leftHeight == -1) return -1;

            int rightHeight = CheckBalanced(node.Right);
            if (rightHeight == -1) return -1;

            if (Math.Abs(leftHeight - rightHeight) > 1)
                return -1;

            return Math.Max(leftHeight, rightHeight) + 1;
        }
    }
}