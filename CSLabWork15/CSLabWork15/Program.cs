using CSLabWork15;
Console.WriteLine("1-12 choose option");
int choose = Convert.ToInt32(Console.ReadLine());
LinkedList<Company> linkedList = new LinkedList<Company>( new[] { new Company("default") });
LinkedListNode<Company> node;
switch (choose)
{
    case 1 :
        break;
    case 2 :
        Console.WriteLine(linkedList);
        break;
    case 3 :
        Console.WriteLine(linkedList.Count);
        break;
    case 4:
        string check = Console.ReadLine();
        Functions.ElementIsAbsence(linkedList, check);
        break;
    case 5:
        Console.WriteLine("Adding start/end/position");
        choose = Convert.ToInt32(Console.ReadLine());
        switch (choose)
        {
            case 1:
                linkedList.AddFirst(new Company(Console.ReadLine()));
                break;
            case 2:
                linkedList.AddLast(new Company(Console.ReadLine()));
                break;
            case 3:
                Console.WriteLine("Enter position, than a string");
                int position = Convert.ToInt32(Console.ReadLine());
                node = linkedList.First;
                string valueToAdd = Console.ReadLine();
                for (int i = 0; i < position - 1; i++)
                {
                    node = node.Next;
                }
                linkedList.AddAfter(node,new Company(valueToAdd));
                break;
            default:
                Console.WriteLine("We go Back");
                break;
        }

        break;
    case 6:
        Console.WriteLine("Delete all/index/element/elements");
        choose = Convert.ToInt32(Console.ReadLine());
        switch (choose)
        {
            case 1:
                linkedList.Clear();
                break;
            case 2:
                
                Console.WriteLine("Enter position");
                choose = Convert.ToInt32(Console.ReadLine());
                node = linkedList.First;

                for (int i = 0; i < choose - 1; i++)
                {
                    node = node.Next;
                }
                linkedList.Remove(node);
                break;
            case 3:
                Console.WriteLine("Enter a string");
                linkedList.Remove(new Company(Console.ReadLine()));
                break;
            default:
                Console.WriteLine("Enter a string");
                linkedList.Remove(new Company(Console.ReadLine()));
                break;
        }

        break;
    case 7 :
        Console.WriteLine("choose one to edit(index)");
        Console.WriteLine(linkedList);
        choose = Convert.ToInt32(Console.ReadLine());
        node = linkedList.First;

        for (int i = 0; i < choose - 1; i++)
        {
            node = node.Next;
        }
        
        Console.WriteLine("BAD LAB");
        
        break;
    case 8 :
        Console.WriteLine("BAD LAB");
        break;
    case 9 :
        Console.WriteLine("choose one to find");
        choose = Convert.ToInt32(Console.ReadLine());
        string find = Console.ReadLine();
        node = linkedList.First;
        string output= "";

        for (int i = 0; i < choose - 1; i++)
        {
            if (node.Next.Equals(new Company(find)))
            {
                output += node + "\n";
            }
            node = node.Next;
        }
        break;
        
    case 10:
        Functions.SortList(linkedList);
        break;
    case 11:
        Functions.SaveListToFile(linkedList);
        break;
    case 12:
        Functions.LoadListFromFile(linkedList);
        break;
}

