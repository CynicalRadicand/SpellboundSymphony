using System.Collections.Generic;

/// <summary>
/// Used for storing a sequence of runes or as an empty store for runes.
/// </summary>
public class RuneSequence
{
    public Rune[] runes { private set; get; }

    public RuneSequence(List<Rune> runes)
    {
        this.runes = runes.ToArray();

        // Replace null items with NONE runes.
        for (int i = 0; i < this.runes.Length; i++)
        {
            if (this.runes[i] == null)
            {
                // FIXME: probably need a better way to get template runes
                this.runes[i] = new Rune(Elements.EMPTY, " ", Accuracy.EMPTY);
            }
        }
    }

    public RuneSequence(Rune rune1, Rune rune2, Rune rune3, Rune rune4)
    {
        runes = new Rune[4] { rune1, rune2, rune3, rune4 };
    }

    public override string ToString()
    {
        string output = "[";

        foreach (Rune rune in runes)
        {
            output += $"({rune.symbol})";
        }
        output += "]";

        return output;
    }
}
