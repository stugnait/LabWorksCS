using System;
using System.Collections.Generic;

class SinglyLinkedListExample
{
    static void Main()
    {
        SinglyLinkedList<int> singlyList = new SinglyLinkedList<int>();

        singlyList.AddLast(121);
        singlyList.AddLast(123);
        singlyList.AddLast(122);

        Console.WriteLine("Елементи списку:");
        singlyList.Display();

        singlyList.AddFirst(0);
        Console.WriteLine("\nЕлементи після додавання на початок:");
        singlyList.Display();

        Console.Write("\nВведіть індекс для вставки: ");
        int index = int.Parse(Console.ReadLine());
        singlyList.InsertAt(4, index);
        Console.WriteLine("Елементи після вставки:");
        singlyList.Display();

        Console.Write("\nВведіть елемент для видалення: ");
        int element = int.Parse(Console.ReadLine());
        singlyList.Remove(element);
        Console.WriteLine("Елементи після видалення:");
        singlyList.Display();
        
        DoublyLinkedList<int> intList = new DoublyLinkedList<int>();
        intList.AddLast(121);
        intList.AddLast(123);
        intList.AddLast(122);

        Console.WriteLine("Original List:");
        intList.Display();

        intList.Sort();

        Console.WriteLine("Sorted List:");
        intList.Display();
    }
    class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }
    class SinglyLinkedList<T>
    {
        private Node<T> head;

        public void AddLast(T data)
        {
            Node<T> newNode = new Node<T>(data);

            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node<T> current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = newNode;
            }
        }

        public void AddFirst(T data)
        {
            Node<T> newNode = new Node<T>(data);
            newNode.Next = head;
            head = newNode;
        }
        public int Count()
        {
            int count = 0;
            Node<T> current = head;

            while (current != null)
            {
                count++;
                current = current.Next;
            }

            return count;
        }

        public bool IsEmpty()
        {
            return head == null;
        }
        public void EditElementAt(int index, T newData)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));

            Node<T> current = head;

            for (int i = 0; i < index; i++)
            {
                if (current == null)
                    throw new ArgumentOutOfRangeException(nameof(index));

                current = current.Next;
            }

            if (current != null)
            {
                current.Data = newData;
            }
        }

        public void InsertAt(T data, int index)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));

            if (index == 0)
            {
                AddFirst(data);
            }
            else
            {
                Node<T> newNode = new Node<T>(data);
                Node<T> current = head;

                for (int i = 0; i < index - 1; i++)
                {
                    if (current == null)
                        throw new ArgumentOutOfRangeException(nameof(index));

                    current = current.Next;
                }

                newNode.Next = current.Next;
                current.Next = newNode;
            }
        }
        public void ReplaceAll(T oldValue, T newValue)
        {
            Node<T> current = head;

            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Data, oldValue))
                {
                    current.Data = newValue;
                }

                current = current.Next;
            }
        }
        public void SaveToFile(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                Node<T> current = head;

                while (current != null)
                {
                    writer.WriteLine(current.Data);
                    current = current.Next;
                }
            }
        }
        public Node<T> Find(T value)
        {
            Node<T> current = head;

            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Data, value))
                {
                    return current;
                }

                current = current.Next;
            }

            return null;
        }
        public void Sort()
        {
            Node<T> sorted = null;
            Node<T> current = head;

            while (current != null)
            {
                Node<T> next = current.Next;

                if (sorted == null || Comparer<T>.Default.Compare(current.Data, sorted.Data) < 0)
                {
                    current.Next = sorted;
                    sorted = current;
                }
                else
                {
                    Node<T> temp = sorted;
                    while (temp.Next != null && Comparer<T>.Default.Compare(current.Data, temp.Next.Data) > 0)
                    {
                        temp = temp.Next;
                    }

                    current.Next = temp.Next;
                    temp.Next = current;
                }

                current = next;
            }

            head = sorted;
        }
        public void LoadFromFile(string fileName)
        {
            head = null;

            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    T value = Activator.CreateInstance<T>();
                    AddLast(value);
                }
            }
        }
        public void Remove(T data)
        {
            if (head == null)
                return;

            if (EqualityComparer<T>.Default.Equals(head.Data, data))
            {
                head = head.Next;
                return;
            }

            Node<T> current = head;
            while (current.Next != null && !EqualityComparer<T>.Default.Equals(current.Next.Data, data))
            {
                current = current.Next;
            }

            if (current.Next != null)
            {
                current.Next = current.Next.Next;
            }
        }
        
        public void RemoveAll()
        {
            head = null;
        }

        public void RemoveAt(int index)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));

            if (index == 0)
            {
                head = head?.Next;
                return;
            }

            Node<T> current = head;
            for (int i = 0; i < index - 1; i++)
            {
                if (current == null)
                    throw new ArgumentOutOfRangeException(nameof(index));

                current = current.Next;
            }

            if (current != null && current.Next != null)
            {
                current.Next = current.Next.Next;
            }
        }

        public void RemoveByValue(T value)
        {
            Node<T> current = head;
            Node<T> previous = null;

            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Data, value))
                {
                    if (previous == null)
                    {
                        head = current.Next;
                    }
                    else
                    {
                        previous.Next = current.Next;
                    }
                    return;
                }

                previous = current;
                current = current.Next;
            }
        }

        public void RemoveAllByValue(T value)
        {
            Node<T> current = head;
            Node<T> previous = null;

            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Data, value))
                {
                    if (previous == null)
                    {
                        head = current.Next;
                    }
                    else
                    {
                        previous.Next = current.Next;
                    }
                }
                else
                {
                    previous = current;
                }

                current = current.Next;
            }
        }

        public void Display()
        {
            Node<T> current = head;

            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }

            Console.WriteLine();
        }
        
    }
    class DoublyNode<T>
{
    public T Data { get; set; }
    public DoublyNode<T> Next { get; set; }
    public DoublyNode<T> Prev { get; set; }

    public DoublyNode(T data)
    {
        Data = data;
        Next = null;
        Prev = null;
    }
}
    class DoublyLinkedList<T>
{
    private DoublyNode<T> head;

    public void AddLast(T data)
    {
        DoublyNode<T> newNode = new DoublyNode<T>(data);

        if (head == null)
        {
            head = newNode;
        }
        else
        {
            DoublyNode<T> current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }

            newNode.Prev = current;
            current.Next = newNode;
        }
    }

    public void AddFirst(T data)
    {
        DoublyNode<T> newNode = new DoublyNode<T>(data);
        newNode.Next = head;

        if (head != null)
        {
            head.Prev = newNode;
        }

        head = newNode;
    }

    public int Count()
    {
        int count = 0;
        DoublyNode<T> current = head;

        while (current != null)
        {
            count++;
            current = current.Next;
        }

        return count;
    }

    public bool IsEmpty()
    {
        return head == null;
    }

    public void EditElementAt(int index, T newData)
    {
        if (index < 0)
            throw new ArgumentOutOfRangeException(nameof(index));

        DoublyNode<T> current = head;

        for (int i = 0; i < index; i++)
        {
            if (current == null)
                throw new ArgumentOutOfRangeException(nameof(index));

            current = current.Next;
        }

        if (current != null)
        {
            current.Data = newData;
        }
    }

    public void InsertAt(T data, int index)
    {
        if (index < 0)
            throw new ArgumentOutOfRangeException(nameof(index));

        if (index == 0)
        {
            AddFirst(data);
        }
        else
        {
            DoublyNode<T> newNode = new DoublyNode<T>(data);
            DoublyNode<T> current = head;

            for (int i = 0; i < index - 1; i++)
            {
                if (current == null)
                    throw new ArgumentOutOfRangeException(nameof(index));

                current = current.Next;
            }

            newNode.Next = current.Next;
            newNode.Prev = current;
            current.Next = newNode;

            if (newNode.Next != null)
            {
                newNode.Next.Prev = newNode;
            }
        }
    }

    public void ReplaceAll(T oldValue, T newValue)
    {
        DoublyNode<T> current = head;

        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Data, oldValue))
            {
                current.Data = newValue;
            }

            current = current.Next;
        }
    }

    public void SaveToFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            DoublyNode<T> current = head;

            while (current != null)
            {
                writer.WriteLine(current.Data);
                current = current.Next;
            }
        }
    }

    public DoublyNode<T> Find(T value)
    {
        DoublyNode<T> current = head;

        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Data, value))
            {
                return current;
            }

            current = current.Next;
        }

        return null;
    }

    public void Sort()
    {
        DoublyNode<T> sorted = null;
        DoublyNode<T> current = head;

        while (current != null)
        {
            DoublyNode<T> next = current.Next;

            if (sorted == null || Comparer<T>.Default.Compare(current.Data, sorted.Data) < 0)
            {
                current.Next = sorted;
                sorted = current;
            }
            else
            {
                DoublyNode<T> temp = sorted;
                while (temp.Next != null && Comparer<T>.Default.Compare(current.Data, temp.Next.Data) > 0)
                {
                    temp = temp.Next;
                }

                current.Next = temp.Next;
                current.Prev = temp;
                temp.Next = current;

                if (current.Next != null)
                {
                    current.Next.Prev = current;
                }
            }

            current = next;
        }

        head = sorted;
    }

    public void LoadFromFile(string fileName)
    {
        head = null;

        using (StreamReader reader = new StreamReader(fileName))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                T value = Activator.CreateInstance<T>();
                AddLast(value);
            }
        }
    }

    public void Remove(T data)
    {
        if (head == null)
            return;

        if (EqualityComparer<T>.Default.Equals(head.Data, data))
        {
            head = head.Next;

            if (head != null)
            {
                head.Prev = null;
            }

            return;
        }

        DoublyNode<T> current = head;
        while (current.Next != null && !EqualityComparer<T>.Default.Equals(current.Next.Data, data))
        {
            current = current.Next;
        }

        if (current.Next != null)
        {
            current.Next.Prev = current;
            current.Next = current.Next.Next;
        }
    }

    public void RemoveAll()
    {
        head = null;
    }

    public void RemoveAt(int index)
    {
        if (index < 0)
            throw new ArgumentOutOfRangeException(nameof(index));

        if (index == 0)
        {
            head = head?.Next;

            if (head != null)
            {
                head.Prev = null;
            }

            return;
        }

        DoublyNode<T> current = head;
        for (int i = 0; i < index - 1; i++)
        {
            if (current == null)
                throw new ArgumentOutOfRangeException(nameof(index));

            current = current.Next;
        }

        if (current != null && current.Next != null)
        {
            current.Next.Prev = current;
            current.Next = current.Next.Next;
        }
    }

    public void RemoveByValue(T value)
    {
        DoublyNode<T> current = head;

        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Data, value))
            {
                if (current.Prev == null)
                {
                    head = current.Next;
                }
                else
                {
                    current.Prev.Next = current.Next;
                }

                if (current.Next != null)
                {
                    current.Next.Prev = current.Prev;
                }

                return;
            }

            current = current.Next;
        }
    }

    public void RemoveAllByValue(T value)
    {
        DoublyNode<T> current = head;

        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Data, value))
            {
                if (current.Prev == null)
                {
                    head = current.Next;
                }
                else
                {
                    current.Prev.Next = current.Next;
                }

                if (current.Next != null)
                {
                    current.Next.Prev = current.Prev;
                }
            }

            current = current.Next;
        }
    }

    public void Display()
    {
        DoublyNode<T> current = head;

        while (current != null)
        {
            Console.Write(current.Data + " ");
            current = current.Next;
        }

        Console.WriteLine();
    }
}
}