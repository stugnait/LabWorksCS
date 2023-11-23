using System.Collections.Generic;
using System.IO;
using CSLabWork15._2;

class Program
{
    static void Main(string[] args)
    {
        string path = @"C:\Users\itesl\LabWorksCS\CSLabWork15\CSLabWork15.2\NewFile1.txt";
        SinglyLinkedList<int> linkedList1 = Functions.CreateLinkedList(File.ReadAllLines(path)[0]);
        SinglyLinkedList<int> linkedList2 = Functions.CreateLinkedList(File.ReadAllLines(path)[1]);
        SinglyLinkedList<int> linkedList3 = Functions.CreateLinkedList(File.ReadAllLines(path)[2]);

        foreach (int number in linkedList1)
        {
            if (linkedList2 != null)
        }
    }
}