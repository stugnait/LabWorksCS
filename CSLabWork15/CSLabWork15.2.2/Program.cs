using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        LinkedList<int> L1 = ReadLinkedListFromFile("L1.txt");
        LinkedList<int> L2 = ReadLinkedListFromFile("L2.txt");
        LinkedList<int> L3 = ReadLinkedListFromFile("L3.txt");

        // Замінити перше входження L2 в L1 на L3
        ReplaceFirstOccurrence(L1, L2, L3);

        SaveLinkedListToFile(L1, "ModifiedList.txt", 7);
    }

    static LinkedList<int> ReadLinkedListFromFile(string fileName)
    {
        string[] lines = File.ReadAllLines(fileName);
        return new LinkedList<int>(lines.Select(int.Parse));
    }

    static void ReplaceFirstOccurrence(LinkedList<int> mainList, LinkedList<int> searchList, LinkedList<int> replacementList)
    {
        var node = mainList.First;
        while (node != null)
        {
            if (node.Value == searchList.First?.Value && IsSublist(node, searchList))
            {
                var nextNode = node.Next;
                foreach (var value in searchList)
                {
                    mainList.Remove(node);
                }
                foreach (var value in replacementList)
                {
                    mainList.AddBefore(nextNode, value);
                }
                break;
            }
            node = node.Next;
        }
    }

    static bool IsSublist(LinkedListNode<int> node, LinkedList<int> sublist)
    {
        var sublistNode = sublist.First;
        while (node != null && sublistNode != null && node.Value == sublistNode.Value)
        {
            node = node.Next;
            sublistNode = sublistNode.Next;
        }
        return sublistNode == null;
    }

    static void SaveLinkedListToFile(LinkedList<int> linkedList, string fileName, int elementsPerLine)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            var node = linkedList.First;
            while (node != null)
            {
                IEnumerable<int> lineElements = Enumerable.Range(0, elementsPerLine)
                    .Select(_ => node?.Value)
                    .Where(value => value.HasValue)
                    .Select(value => value.Value);
                writer.WriteLine(string.Join(" ", lineElements));
                node = node.Next;
            }
        }
    }
}
