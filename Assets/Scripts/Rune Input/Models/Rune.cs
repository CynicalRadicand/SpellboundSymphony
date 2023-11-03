using System;
public class Rune
{
    public Elements element { get; private set; }
    public string symbol { get; private set; }

    public Rune(Elements element, string symbol)
    {
        this.element = element;
        this.symbol = symbol;
    }
}
