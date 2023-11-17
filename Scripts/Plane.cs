using Godot;
using System;


public partial class Plane : Area2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// GD.Print(GetOverlappingAreas());
	}

	public void OnAreaExit(Area2D area) {
		GD.Print("Exited: " + area);

		// if (RotationDegrees < 90 && RotationDegrees > 0 ) {
		// 	Rotation = (float)Math.PI * RotationDegrees;
		// }
	}

	public void OnAreaEntered(Area2D area) {
		GD.Print("Entered: " + area.GetType());
	}
	

}
