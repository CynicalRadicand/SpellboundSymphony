using Godot;
using System;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata;

public partial class Conductor : AudioStreamPlayer2D
{
    [Export] public int bpm;

    private const int BEATNUMS = 4;

    [Export] private double secPerBeat = 0;

    [Export] private double songPosSec = 0;

    [Export] private double songPosBeats = 0;

    [Export] private int lastReportedBeat = -1;

    [Export] private double lastReportedSec = 0;

    [Export] private int beatNum = 0;

    [Export] private bool casting = false;

    [Export] private NodePath runeInputManagerPath;

    [Signal] public delegate void FadeEventHandler(double beat);

    [Signal] public delegate void BeatEventHandler(int beatNum, bool casting);

    [Signal] public delegate void ConductorInputEventHandler(InputDTO inputDTO, double inputSec, double beatSec);


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
        //Calculate the number of seconds in each beat
        secPerBeat = 60f / bpm;


        var runeInputManager = GetNode<RuneInputManager>(runeInputManagerPath);
        runeInputManager.InputSignal += ReportInput;
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
        if (Playing)
        {
            //AudioServer.GetTimeSinceLastMix() gets the time between updates 
            songPosSec = GetPlaybackPosition() + AudioServer.GetTimeSinceLastMix() - AudioServer.GetOutputLatency();

            songPosBeats = songPosSec / secPerBeat;

            EmitSignal(SignalName.Fade, songPosBeats);

            ReportBeat();

        }
    }

    private void ReportBeat()
    {
        int songPosBeatsInt = (int)Math.Floor(songPosBeats);

        if (lastReportedBeat < songPosBeatsInt)
        {
            beatNum++;
            if (beatNum > BEATNUMS)
            {
                casting = !casting;
                beatNum = 1;
            }
            lastReportedBeat = songPosBeatsInt;
            lastReportedSec = songPosSec;

            EmitSignal(SignalName.Beat, beatNum, casting);
        }
    }

    private void ReportInput(InputDTO inputDTO)
    {
        double inputSec = songPosSec;
        double beatSec = lastReportedSec;

        if (songPosBeats % 1 <= 0.5)
        {
            GD.Print(songPosBeats % 1);
            inputDTO.BeatNum = beatNum;
        }
        else
        {
            GD.Print(songPosBeats % 1);
            inputDTO.BeatNum = beatNum + 1;
            beatSec += secPerBeat;
        }

        EmitSignal(SignalName.ConductorInput, inputDTO, inputSec, beatSec);
    }
}
