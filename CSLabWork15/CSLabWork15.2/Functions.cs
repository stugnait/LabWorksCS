using System;
using System.Collections.Generic;
using System.IO;

namespace CSLabWork15._2;

public static class Functions
{
    public static SinglyLinkedList<int> CreateLinkedList(string str)
    {
        SinglyLinkedList<int> linkedList = new SinglyLinkedList<int>();
        int[] array = { Convert.ToInt32(str.Split(" ")) };

        linkedList.Add(array[0]);
        for (int i = 0; i < array.Length; i++)
        {
            linkedList.Add(array[i]);
        }
        
        return linkedList;
    }
} 
public class Node<T>
{
    public T Data;
    public Node<T> Next;

    public Node(T data)
    {
        Data = data;
        Next = null;
    }
}

public class SinglyLinkedList<T>
{
    public Node<T> Head;

    public void Add(T data)
    {
        Node<T> newNode = new Node<T>(data);
        if (Head == null)
        {
            Head = newNode;
        }
        else
        {
            Node<T> current = Head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
    }

    public void ReplaceFirstOccurrence(SinglyLinkedList<T> searchList, SinglyLinkedList<T> replaceList)
    {
        Node<T> current = Head;
        Node<T> previous = null;
        Node<T> searchCurrent = searchList.Head;
        Node<T> searchPrevious = null;
        Node<T> replaceCurrent = replaceList.Head;

        while (current != null)
        {
            if (current.Data.Equals(searchCurrent.Data))
            {
                if (searchCurrent.Next == null)
                {
                    // Found a match for the entire search list
                    if (searchPrevious == null)
                    {
                        // Replace the head of the main list
                        Head = replaceList.Head;
                    }
                    else
                    {
                        // Replace inside the main list
                        searchPrevious.Next = replaceList.Head;
                    }

                    // Connect the replace list to the rest of the main list
                    while (replaceCurrent.Next != null)
                    {
                        replaceCurrent = replaceCurrent.Next;
                    }
                    replaceCurrent.Next = current.Next;

                    break; // Replace completed
                }

                // Move to the next elements of the lists
                searchPrevious = searchCurrent;
                searchCurrent = searchCurrent.Next;
                replaceCurrent = replaceList.Head;
            }
            else
            {
                searchCurrent = searchList.Head;
                searchPrevious = null;
            }

            previous = current;
            current = current.Next;
        }
    }

    public void PrintList()
    {
        Node<T> current = Head;
        while (current != null)
        {
            Console.Write($"{current.Data} -> ");
            current = current.Next;
        }
        Console.WriteLine("null");
    }
}
