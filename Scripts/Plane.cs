using AntAlgorithm;
using Godot;
using System;
using System.Drawing;


public partial class Plane : Area2D
{
	// Called when the node enters the scene tree for the first time.
	private Vector2 _planeSize;

	public override void _Ready()
	{
		_planeSize = this.GetViewportRect().Size;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// GD.Print(GetOverlappingAreas());
	}

	public void OnAreaExit(Area2D area) {
		if (area.GetType() == typeof(Ant)) {
			Ant ant = (Ant)area;

			ant.Rotation = DegToRad(360f) - ant.Rotation;
			if (Math.Abs(ant.Position.X * 2) > _planeSize.X) {
				ant.Rotate((float)Math.PI);
			}
		}

	}

	public float DegToRad(float angle) {
		return ((float)Math.PI / 180) * angle;
	}

	public void OnAreaEntered(Area2D area) {
		
	}
	

}
