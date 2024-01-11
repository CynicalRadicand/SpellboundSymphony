using System;
public class Rune
{
    public Elements element { get; private set; }
    public string symbol { get; private set; }
    public Accuracy accuracy { get; private set; }

    public Rune(Elements element, string symbol, Accuracy accuracy)
    {
        this.element = element;
        this.symbol = symbol;
        this.accuracy = accuracy;
    }
}
