using Godot;
using System;
using System.Collections.Generic;


namespace AntAlgorithm 
{
	public partial class VoiceArea : Area2D
	{
		private HashSet<Ant> _ants = new HashSet<Ant>(); 
		public IReadOnlyCollection<Ant> Ants =>_ants;
		 
		public override void _Ready() 
		{
		}
		public void OnCollisionEnter(Area2D area)
		{
			if (area.GetType() == typeof(Ant))
			{
				_ants.Add((Ant)area);
			}
		}

		public void OnCollisionExit(Area2D area)
		{
			if (area.GetType() == typeof(Ant))
			{
				_ants.Remove((Ant)area);
			}
		}
	}
}
