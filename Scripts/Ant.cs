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
        private int _distFood;
        [Export] private float _velocity;
        public float Velocity { get { return _velocity; } private set { _velocity = value; } }

        [Export] private float _radius;

        [Export] private float _distGo;
        private Vector2 _startPos;

        private TargetType _target;

        private AntMover _mover;
        private VoiceArea _voiceArea;

        // Godot events
        public override void _Ready()
        {
            _mover = (AntMover)FindInChildren(typeof(AntMover));

            _voiceArea = (VoiceArea)FindInChildren(typeof(VoiceArea));
            _voiceArea.SetRadius(_radius);

            _distFood = 0;
            _distQueen = 0;

            _velocity += NextFloat(0f, 1f);

            _target = TargetType.Queen;

            _startPos = Position;
        }
        

        public override void _PhysicsProcess(double delta)
        {
            Move();
            //Shout();
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
        public void Shout(Ant ant)
        {
            ant.HearDistances(Position, _distQueen + (int)_radius, _distFood + (int)_radius);
        }

        public void OnCollisionEnter(Area2D area)
		{
			if (area.GetType() == typeof(Queen))
			{
				_distQueen = 0;
                Rotate((float)Math.PI);
                ShoutEveryoneInArea();

                if (_target == TargetType.Queen)
                {
                    _target = TargetType.Food;
                    
                }
			}

            if (area.GetType() == typeof(Food))
			{
				_distFood = 0;
                Rotate((float)Math.PI);
                ShoutEveryoneInArea();

                if (_target == TargetType.Food)
                {
                    _target = TargetType.Queen;
                    
                }
			}
		}

        // Private methods
        
        private void ShoutEveryoneInArea()
        {
            foreach(Ant ant in _voiceArea.Ants)
            {
                if (ant == this) continue;

                Shout(ant);
            }
        }

        /// <summary>
        /// Делаем шаг и увеличиваем счетчики на один.
        /// </summary>
        private void Move()
        {
            _mover.Move(this);
            _distFood++;
            _distQueen++;
            Rotate(NextFloat(DegToRad(-5), DegToRad(5)));

            if (_startPos.Y + _distGo < Math.Abs(Position.Y))
            {
                Rotation = DegToRad(360f) - Rotation;
            }

            if (Math.Abs(Position.X) > _startPos.Y + _distGo) 
            {
				    Rotate((float)Math.PI);
			}
        }

        public float DegToRad(float angle) {
            return ((float)Math.PI / 180) * angle;
        }


        static float NextFloat(float min, float max){
            System.Random random = new System.Random();
            double val = (random.NextDouble() * (max - min) + min);
            return (float)val;
        }

        /// <summary>
        /// Находит нужный скрипт в дочерних Node.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private Variant FindInChildren(Type type)
        {
            var childrens = GetChildren();

            foreach(Node node in childrens)
            {
                if (node.GetType() == type)
                {
                    return node;
                }
            }
            GD.PrintErr("Такого скрипта нет в детях!");
            return new Variant();
        }

    }
}