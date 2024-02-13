using System;

public class FieldValidator<T> : IFieldValidator
{
    public string name { private set; get; }
    public Func<T, bool> condition { private set; get; }
    public string description { private set; get; }

    public FieldValidator(string name, Func<T, bool> condition, string description)
    {
        this.name = name;
        this.condition = condition;
        this.description = description;
    }

    public void ValidateValue(T value)
    {
        if (!condition(value))
        {
            throw new Exception($"Invalid value '{value}' for field '{name}' - Failed condition check: '{description}'");
        }
    }
}