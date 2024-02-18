using System.Collections.Generic;
using System.Linq;

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
    public override bool Equals(object obj)
    {
        //
        // See the full list of guidelines at
        //   http://go.microsoft.com/fwlink/?LinkID=85237
        // and also the guidance for operator== at
        //   http://go.microsoft.com/fwlink/?LinkId=85238
        //

        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        RuneSequence comparison = (RuneSequence)obj;

        for (int i = 0; i < runes.Length; i++)
        {
            Elements thisElement = runes[i].element;
            Elements thatElement = comparison.runes[i].element;

            if (!thisElement.Equals(thatElement))
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// Necessary override when overriding Equals()
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
