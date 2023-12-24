using Godot;
using System;


namespace AntAlgorithm 
{
	public partial class AntScout : Ant
	{
		public override void HearDistances(Vector2 dir, int distQueen, int distFood)
		{
			if (distFood < _distFood)
				{
					_distFood = distFood;
					_shouter.ShoutEveryoneInArea();
				}

				if (distQueen < _distQueen)
				{
					_distQueen = distQueen;
					_shouter.ShoutEveryoneInArea();

					if (_target == TargetType.Queen)
					{
						LookAt(dir);
					}
				}
		}
	}
}