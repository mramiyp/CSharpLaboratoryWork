﻿namespace Store;

internal class Customer
{
    public const ConsoleColor COLOR = ConsoleColor.Cyan;

    public int X { get; set; }

    public int Y { get; set; }

    public Item Item { get; } = new Item();

    public void StoreProduct(Item item)
    {
        Item.X = X;
        Item.Y = Y;
        Item.Char = item.Char;
        Item.Color = item.Color;
        Item.Product = item.Product;
        Item.Store = item.Store;
    }

    public void EmptyProduct()
    {
        Item.X = X;
        Item.Y = Y;
        Item.Char = Constants.OPERATOR;
        Item.Color = COLOR;
        Item.Product = null;
        Item.Store = null;
    }

    public void Write(char c = Constants.OPERATOR)
    {
        Write(c != Constants.EMPTY ? c : Constants.OPERATOR, COLOR);
    }
    public void Write(char c, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.SetCursorPosition(X, Y);
        Console.CursorVisible = false;
        Console.Write(c);
    }
}
