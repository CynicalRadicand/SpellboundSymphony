using System;

[Serializable]
public class SpellNotFoundException : Exception
{
    public SpellNotFoundException(string message) : base(message) { }
}