using Godot;
using System;
using System.Collections.Generic;


namespace AntAlgorithm 
{
	public partial class VoiceArea : Area2D
	{
		private HashSet<Ant> _ants = new HashSet<Ant>(); 
		public IReadOnlyCollection<Ant> Ants =>_ants;

		private AntShouter _shouter;

		public void OnCollisionEnter(Area2D area)
		{
			if (area is Ant)
			{
				var ant = (Ant)area;
				_ants.Add(ant);
				_shouter.Shout(ant);
			}
		}

		public void OnCollisionExit(Area2D area)
		{
			if (area is Ant)
			{
				_ants.Remove((Ant)area);
			}
		}
		public void SetShouter(AntShouter shouter)
		{
			_shouter = shouter;
		}

		public void SetRadius(float radius) 
		{
			Scale = Vector2.One * radius;
		}
	}
}
