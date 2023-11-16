using System;
using Godot;

// Ant
public partial class Ant : Node2D
{
	private float _velocity = 1f;
	public float Velocity { get { return _velocity; } private set { _velocity = value; } }

	private Vector3 _dir;

    public override void _Ready()
    {

    }

    public override void _PhysicsProcess(double delta)
    {

    }
}
