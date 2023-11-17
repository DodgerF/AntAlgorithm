using Godot;

namespace AntAlgorithm
	{
	public partial class AntMover : Node2D
	{
		public void Move(Ant ant)
		{
			ant.Position += ant.Transform.X * ant.Velocity;
		}
	}
}
