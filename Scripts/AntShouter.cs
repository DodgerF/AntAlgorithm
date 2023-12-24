using AntAlgorithm;
using Godot;
using System;

public partial class AntShouter : Node
{
	private Ant _ant;
	private VoiceArea _voiceArea;
	public override void _Ready()
	{
		_ant = GetParent<Ant>();
	}

	public void SetVoiceArea(VoiceArea voiceArea)
	{
		_voiceArea = voiceArea;
	}

	public void ShoutEveryoneInArea()
    {
        foreach(Ant ant in _voiceArea.Ants)
        {
            if (ant == _ant) continue;

            Shout(ant);
        }
    }
    public void Shout(Ant ant)
    {
        ant.HearDistances(_ant.Position, _ant.DistQueen + (int)_ant.Radius, _ant.DistFood + (int)_ant.Radius);
    }	
}
