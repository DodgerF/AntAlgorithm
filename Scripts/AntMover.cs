using Godot;

public partial class AntMover : Node2D
{
	public override void _Ready()
	{
	}

	public override void _PhysicsProcess(double delta)
    {
		
	    Position += Transform.Y *_velocity;
    }
}
