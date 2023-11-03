using System.Collections.Generic;

public class Spell
{
    public string name { private set; get; }
    public List<Rune> runes { private set; get; }

    public Spell(string name)
    {
        this.name = name;
    }
}
