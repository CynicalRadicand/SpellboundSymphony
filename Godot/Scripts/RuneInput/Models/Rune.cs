using System;
public class Rune
{
    public Elements element { get; private set; } = Elements.EMPTY;
    public string symbol { get; private set; } = null;
    public Accuracy accuracy { get; private set; } = Accuracy.EMPTY;

    public Rune(Elements element, string symbol, Accuracy accuracy)
    {
        this.element = element;
        this.symbol = symbol;
        this.accuracy = accuracy;
    }

    public Rune(Elements element)
    {
        this.element = element;
    }
}
