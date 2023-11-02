using System.Collections.Generic;

/// <summary>
/// Used for storing a sequence of runes or as an empty store for runes.
/// </summary>
public class RuneSequence
{
    public Rune[] runes { private set; get; }

    public RuneSequence(List<Rune> runes)
    {
        for (int i = 0; i < 4; i++)
        {
            Rune rune = runes[i];

            if (rune == null)
            {
                rune = new Rune(Elements.NONE);
            }

            this.runes[i] = rune;
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
            output += $"({rune.element})";
        }
        output += "]";

        return output;
    }
}
