using System;
using Godot;

// Ant
namespace AntAlgorithm 
{
    public enum TargetType 
    {
        Queen,
        Food
    }

    public partial class Ant : Area2D
    {
        // Fields

        private int _distQueen; 
        public int DistQueen {get { return _distQueen;} }
        private int _distFood;
        public int DistFood {get { return _distFood;} }
        [Export] private float _velocity;
        public float Velocity { get { return _velocity; } private set { _velocity = value; } }

        [Export] private float _radius;
        public float Radius {get { return _radius;} }
        private TargetType _target;

        private AntMover _mover;
        private AntShouter _shouter;

        // Godot events
        public override void _Ready()
        {
            _mover = (AntMover)Finder.FindInChildren(this, typeof(AntMover));

            _shouter = (AntShouter)Finder.FindInChildren(this, typeof(AntShouter));

            VoiceArea voiceArea = (VoiceArea)Finder.FindInChildren(this, typeof(VoiceArea));
            voiceArea.SetRadius(_radius);
            voiceArea.SetShouter(_shouter);

            _shouter.SetVoiceArea(voiceArea);

            _distFood = 1000;
            _distQueen = 1000;

            _velocity += SmallMath.NextFloat(0f, 1f);

            _target = TargetType.Queen;
        }
        

        public override void _PhysicsProcess(double delta)
        {
            Move();
        }

        // Public methods
        /// <summary>
        /// Сравниваем полученные данные и при необходимости перезаписываем свои.
        /// </summary>
        /// <param name="distQueen"></param>
        /// <param name="distFood"></param>
        public void HearDistances(Vector2 dir, int distQueen, int distFood)
        {  
            if (distFood < _distFood)
            {
                _distFood = distFood;
                if (_target == TargetType.Food)
                {
                    LookAt(dir);
                }
            }

            if (distQueen < _distQueen)
            {
                _distQueen = distQueen;
                if (_target == TargetType.Queen)
                {
                    LookAt(dir);
                }
            }
        }

        public void OnCollisionEnter(Area2D area)
		{
			if (area.GetType() == typeof(Queen))
			{
				_distQueen = 0;
                Rotate((float)Math.PI);
                _shouter.ShoutEveryoneInArea();

                if (_target == TargetType.Queen)
                {
                    _target = TargetType.Food;
                    
                }
			}

            if (area.GetType() == typeof(Food))
			{

				_distFood = 0;
                Rotate((float)Math.PI);
                _shouter.ShoutEveryoneInArea();

                if (_target == TargetType.Food)
                {
                    _target = TargetType.Queen;
                    
                }
			}
		}

        // Private methods
        

        /// <summary>
        /// Делаем шаг и увеличиваем счетчики на один.
        /// </summary>
        private void Move()
        {
            _mover.Move(this);
            _mover.Rotate(this);
            _distFood++;
            _distQueen++;
        }


    }
}