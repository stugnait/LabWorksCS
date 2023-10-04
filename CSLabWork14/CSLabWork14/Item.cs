using System;
using System.Runtime.InteropServices.JavaScript;

namespace CSLabWork14;

public struct Item
{
    public string name;
    public string company;
    public DateOnly createdDateTime;
    public DateOnly expireDateOnly;
    public int price;

    public Item(string name, string company, DateOnly createdDateTime, DateOnly expireDateOnly, int price)
    {
        this.name = name;
        this.company = company;
        this.createdDateTime = createdDateTime;
        this.expireDateOnly = expireDateOnly;
        this.price = price;
    }

    public override string ToString()
    {
        return name + " " + company + " " + createdDateTime + " -> " + expireDateOnly + " " + price+"\n";
    }
}