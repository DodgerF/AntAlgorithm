using AntAlgorithm;
using Godot;
using System;

public partial class Simulation : Node2D
{
	// Called when the node enters the scene tree for the first time.

	private PackedScene _antScene = GD.Load<PackedScene>("res://Scences/Ant.tscn");

	public override void _Ready()
	{
		var plane = (Plane)Finder.FindInChildren(this, typeof(Plane));
		var collision = (CollisionShape2D)Finder.FindInChildren(plane, typeof(CollisionShape2D));

		Vector2 to = new Vector2( ((RectangleShape2D)collision.Shape).Size.X, ((RectangleShape2D)collision.Shape).Size.Y) * collision.Scale/2;
		Vector2 from = to * -1;

		 for (int i = 0; i < 500; i++)
		 {
		 	AddChild(SpawnAnt(from, to));
		 }
	}
	//TODO: коорды
	private Ant SpawnAnt(Vector2 from, Vector2 to) {
		var instance = (Ant)_antScene.Instantiate();
		instance.Position = new Vector2(SmallMath.NextFloat(from.X , to.X), SmallMath.NextFloat(from.Y, to.Y));
		return instance;
	}
}
