using Godot;

namespace AntAlgorithm
	{
	public partial class AntMover : Node2D
	{
		public void Move(Ant ant)
		{
			ant.Position += ant.Transform.X * ant.Velocity;
		}
		public void Rotate(Ant ant)
		{
			ant.Rotate(SmallMath.NextFloat(SmallMath.DegToRad(-5), SmallMath.DegToRad(5)));
		}
	}
}
