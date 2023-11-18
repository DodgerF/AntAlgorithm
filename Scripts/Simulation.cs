using AntAlgorithm;
using Godot;
using System;

public partial class Simulation : Node2D
{
	// Called when the node enters the scene tree for the first time.

	private PackedScene _antScene = GD.Load<PackedScene>("res://Scences/Ant.tscn");

	public override void _Ready()
	{
		for (int i = 0; i < 500; i++)
		{
			var instance = (Ant)_antScene.Instantiate();
			instance.Position = new Vector2(i % 500, i % 500);
			AddChild(instance);
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
