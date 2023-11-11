using Godot;
using System;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata;

public partial class Conductor : AudioStreamPlayer2D
{
    [Export] public int bpm;

    private int measures = 4;

    [Export] private double secPerBeat = 0;

    [Export] private double songPosSec = 0;

    [Export] private int songPosBeats = 0;

    [Export] private int lastReportedBeat = 0;

    [Export] private int measure = 0;


    // Emit on beat
    [Signal] public delegate void BeatEventHandler(int beat);

    [Signal] public delegate void FadeEventHandler(double beat);


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
        //Calculate the number of seconds in each beat
        secPerBeat = 60f / bpm;

    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
        if (Playing)
        {
            //AudioServer.GetTimeSinceLastMix() gets the time between updates 
            songPosSec = GetPlaybackPosition() + AudioServer.GetTimeSinceLastMix() - AudioServer.GetOutputLatency();

            double beatDouble = songPosSec / secPerBeat;

            EmitSignal(SignalName.Fade, beatDouble);

            songPosBeats = (int)Math.Floor(beatDouble);

            ReportBeat();

        }
    }

    private void ReportBeat()
    {
        if (lastReportedBeat < songPosBeats)
        {
            measure++;
            if (measure > measures)
            {
                measure = 1;
            }
            EmitSignal(SignalName.Beat, songPosBeats);
            lastReportedBeat = songPosBeats;

        }
    }

}
