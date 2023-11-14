using Godot;
using System;

public partial class InputDTO : GodotObject
{
    public Elements KeyAction { get; set; }
    public Accuracy Accuracy { get; set; }
    public int BeatNum { get; set; }
}
