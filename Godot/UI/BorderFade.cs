using Godot;
using System;
using System.Diagnostics;

public partial class BorderFade : NinePatchRect
{
	private double beat;

	public override void _Ready()
	{
		var conductor = GetNode<Conductor>("../../Conductor");
		conductor.Fade += SetAlpha;
	}

	public void SetAlpha(double beat)
	{
		float alpha = (float)(1 - (beat % 1));
		Modulate = new Color(1, 1, 1, alpha);
	}
}
