bool exit = false;

while (!exit)
{
    Console.WriteLine("1,2,3,4, 5 - exit");
    int choose = Convert.ToInt32(Console.ReadLine());

    switch (choose)
    {
        case 1:
            Stack<int> stack = new Stack<int>();
            string expression = "(2-4b/(a*6+(a+3)*(3-a)";

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    stack.Push(i + 1);
                }
                else if (expression[i] == ')')
                {
                    if (stack.Count == 0)
                    {
                        Console.WriteLine("Дужки не збалансовані");
                        return;
                    }
                    else
                    {
                        Console.WriteLine(
                            $"{stack.Pop()}, {i + 1}"); // Якщо знаходимо закриваючу дужку, виводимо пару номерів позицій
                    }
                }
            }

            if (stack.Count != 0)
            {
                Console.WriteLine("Дужки не збалансовані");
            }
            else
            {
                Console.WriteLine("Дужки збалансовані");
            }

            break;
        case 2:

            DoubleEndedQueue deque = new DoubleEndedQueue();

            // Додаємо 10 елементів до деку
            for (int i = 1; i <= 10; i++)
            {
                deque.PushBack(i);
            }

            deque.DisplayDeque();

            Console.WriteLine("Front елемент: " + deque.Front());
            Console.WriteLine("Back елемент: " + deque.Back());
            Console.WriteLine("Розмір деку: " + deque.Size());

            deque.PopFront();
            deque.PopBack();

            Console.WriteLine("Front елемент після видалення з початку: " + deque.Front());
            Console.WriteLine("Back елемент після видалення з кінця: " + deque.Back());

            deque.DisplayDeque();

            deque.Clear();
            Console.WriteLine("Після очищення деку:");
            deque.DisplayDeque();
            break;
        case 3:
            BinaryTree tree = new BinaryTree();

            tree.Insert(50);
            tree.Insert(30);
            tree.Insert(20);
            tree.Insert(40);
            tree.Insert(70);
            tree.Insert(60);
            tree.Insert(80);

            Console.WriteLine("Наше дерево:");
            tree.PreorderTraversal();

            // Delete an element
            tree.Delete(20);
            Console.WriteLine("\nПісля видалення 20:");
            tree.PreorderTraversal();

            // Search in the binary tree
            int searchKey = 40;
            TreeNode searchResult = tree.Search(searchKey);
            if (searchResult != null)
            {
                Console.WriteLine($"\nNode with key {searchKey} found.");
            }
            else
            {
                Console.WriteLine($"\nNode with key {searchKey} not found.");
            }

            break;
        case 4:
            try
                {
                    Console.WriteLine("A->A,A->B,A->E,C->E,D->E,B->E,D->D");
                    string input = Console.ReadLine();
                    List<Tuple<char, char>> edges = ParseEdges(input);
                    Graph graph = new Graph(edges);
    
                    Console.WriteLine("Матриця Суміжності:\n" + MatrixToString(graph.AdjacencyMatrix()));
                    Console.WriteLine("Матриця інцидентності:\n" + MatrixToString(graph.IncidenceMatrix()));
                    Console.WriteLine("Що куда входить:\n" + EdgesToString(graph.EdgeList()));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            break;
        case 5:
            exit = true;
            break;
        default:
            Console.WriteLine("Something went wrong");
            break;
    }
    
}

List<Tuple<char, char>> ParseEdges(string input)
{
    List<Tuple<char, char>> edges = new List<Tuple<char, char>>();
    string[] edgeStrings = input.Split(',');

    foreach (string edgeString in edgeStrings)
    {
        string[] nodes = edgeString.Split(new[] { "->" }, StringSplitOptions.RemoveEmptyEntries);
        if (nodes.Length == 2 && nodes[0].Length == 1 && nodes[1].Length == 1)
        {
            edges.Add(new Tuple<char, char>(nodes[0][0], nodes[1][0]));
        }
        else
        {
            throw new ArgumentException("Invalid edge format: " + edgeString);
        }
    }

    return edges;
}

string MatrixToString(int[,] matrix)
{
    string result = "   ";
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        result += (char)('A' + i) + " ";
    }
    result += "\n";
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        result += (char)('A' + i) + " ";
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            result += matrix[i, j] + " ";
        }
        result += "\n";
    }
    return result;
}

string EdgesToString(List<Tuple<char, char>> edges)
{
    string result = "";
    foreach (var edge in edges)
    {
        result += edge.Item1 + "->" + edge.Item2 + "\n";
    }
    return result;
}

class TreeNode
{
    public int Data;
    public TreeNode Left, Right;

    public TreeNode(int data)
    {
        Data = data;
        Left = Right = null;
    }
}

class BinaryTree
{
    private TreeNode root;

    public BinaryTree()
    {
        root = null;
    }

    public void Insert(int data)
    {
        root = InsertRec(root, data);
    }

    private TreeNode InsertRec(TreeNode root, int data)
    {
        if (root == null)
        {
            root = new TreeNode(data);
            return root;
        }

        if (data < root.Data)
        {
            root.Left = InsertRec(root.Left, data);
        }
        else if (data > root.Data)
        {
            root.Right = InsertRec(root.Right, data);
        }

        return root;
    }

    public void Delete(int data)
    {
        root = DeleteRec(root, data);
    }

    private TreeNode DeleteRec(TreeNode root, int data)
    {
        if (root == null)
        {
            return root;
        }

        if (data < root.Data)
        {
            root.Left = DeleteRec(root.Left, data);
        }
        else if (data > root.Data)
        {
            root.Right = DeleteRec(root.Right, data);
        }
        else
        {
            if (root.Left == null)
            {
                return root.Right;
            }
            else if (root.Right == null)
            {
                return root.Left;
            }

            root.Data = MinValue(root.Right);

            root.Right = DeleteRec(root.Right, root.Data);
        }

        return root;
    }

    private int MinValue(TreeNode root)
    {
        int minValue = root.Data;
        while (root.Left != null)
        {
            minValue = root.Left.Data;
            root = root.Left;
        }
        return minValue;
    }

    public void PreorderTraversal()
    {
        PreorderTraversalRec(root);
    }

    private void PreorderTraversalRec(TreeNode root)
    {
        if (root != null)
        {
            Console.Write(root.Data + " ");
            PreorderTraversalRec(root.Left);
            PreorderTraversalRec(root.Right);
        }
    }
    public TreeNode Search(int data)
    {
        return SearchRec(root, data);
    }

    private TreeNode SearchRec(TreeNode root, int data)
    {
        if (root == null || root.Data == data)
        {
            return root;
        }
        if (data < root.Data)
        {
            return SearchRec(root.Left, data);
        }
        return SearchRec(root.Right, data);
    }
    
     private static List<Tuple<char, char>> ParseEdges(string input)
        {
            List<Tuple<char, char>> edges = new List<Tuple<char, char>>();
            string[] edgeStrings = input.Split(',');

            foreach (string edgeString in edgeStrings)
            {
                string[] nodes = edgeString.Split(new[] { "->" }, StringSplitOptions.RemoveEmptyEntries);
                if (nodes.Length == 2 && nodes[0].Length == 1 && nodes[1].Length == 1)
                {
                    edges.Add(new Tuple<char, char>(nodes[0][0], nodes[1][0]));
                }
                else
                {
                    throw new ArgumentException("Invalid edge format: " + edgeString);
                }
            }

            return edges;
        }

        private static string MatrixToString(int[,] matrix)
        {
            string result = "   ";
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                result += (char)('A' + i) + " ";
            }
            result += "\n";
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                result += (char)('A' + i) + " ";
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    result += matrix[i, j] + " ";
                }
                result += "\n";
            }
            return result;
        }

        private static string EdgesToString(List<Tuple<char, char>> edges)
        {
            string result = "";
            foreach (var edge in edges)
            {
                result += edge.Item1 + "->" + edge.Item2 + "\n";
            }
            return result;
        }
    }
public class Graph
{
    private List<Tuple<char, char>> _edges;

    public Graph(List<Tuple<char, char>> edges)
    {
        _edges = edges;
    }

    public int[,] AdjacencyMatrix()
    {
        int[,] matrix = new int[5, 5];

        foreach (var edge in _edges)
        {
            int row = edge.Item1 - 'A';
            int col = edge.Item2 - 'A';
            matrix[row, col] = 1;
        }

        return matrix;
    }

    public int[,] IncidenceMatrix()
    {
        int[,] matrix = new int[5, _edges.Count];

        for (int i = 0; i < _edges.Count; i++)
        {
            matrix[_edges[i].Item1 - 'A', i] = 1;
            matrix[_edges[i].Item2 - 'A', i] = -1;
        }

        return matrix;
    }

    public List<Tuple<char, char>> EdgeList()
    {
        return _edges;
    }
}
class DoubleEndedQueue
{
    private LinkedList<int> deque = new ();

    public void PushFront(int value)
    {
        deque.AddFirst(value);
    }

    public void PushBack(int value)
    {
        deque.AddLast(value);
    }

    public void PopFront()
    {
        if (deque.Count == 0)
        {
            Console.WriteLine("Дек порожній. Неможливо видалити елемент.");
            return;
        }
        deque.RemoveFirst();
    }

    public void PopBack()
    {
        if (deque.Count == 0)
        {
            Console.WriteLine("Дек порожній. Неможливо видалити елемент.");
            return;
        }
        deque.RemoveLast();
    }

    public int Front()
    {
        if (deque.Count == 0)
        {
            Console.WriteLine("Дек порожній.");
            return -1; 
        }
        return deque.First.Value;
    }

    public int Back()
    {
        if (deque.Count == 0)
        {
            Console.WriteLine("Дек порожній");
            return -1; 
        }
        return deque.Last.Value;
    }

    public int Size()
    {
        return deque.Count;
    }

    public void Clear()
    {
        deque.Clear();
    }

    public void DisplayDeque()
    {
        Console.Write("Елементи деку: ");
        foreach (var item in deque)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}

