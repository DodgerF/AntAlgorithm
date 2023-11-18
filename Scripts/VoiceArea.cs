using Godot;
using System;
using System.Collections.Generic;


namespace AntAlgorithm 
{
	public partial class VoiceArea : Area2D
	{
		private HashSet<Ant> _ants = new HashSet<Ant>(); 
		public IReadOnlyCollection<Ant> Ants =>_ants;

		private Ant _ant;
		 
		public override void _Ready() 
		{
			_ant = GetParent<Ant>();
		}
		public void OnCollisionEnter(Area2D area)
		{
			if (area.GetType() == typeof(Ant))
			{
				var ant = (Ant)area;
				_ants.Add(ant);
				_ant.Shout(ant);
			}
		}

		public void OnCollisionExit(Area2D area)
		{
			if (area.GetType() == typeof(Ant))
			{
				_ants.Remove((Ant)area);
			}
		}

		public void SetRadius(float radius) 
		{
			Scale = Vector2.One * radius;
		}
	}
}
