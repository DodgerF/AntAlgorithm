using System;
using Godot;

// Ant
namespace AntAlgorithm 
{
    public partial class Ant : Area2D
    {
        // Fields

        //TODO: цель хождения
        private int _distQueen; 
        private int _distEat;
        private float _velocity = 1f;
        public float Velocity { get { return _velocity; } private set { _velocity = value; } }

        private float _changeDirVelocity = 0.01f;
        public float ChangeDirVelocity { get { return _changeDirVelocity; } private set { _changeDirVelocity = value; } }

        private Vector3 _dir;

        private AntMover _mover;
        private VoiceArea _voiceArea;

        // Godot events
        public override void _Ready()
        {
            _mover = (AntMover)FindInChildren(typeof(AntMover));
            _voiceArea = (VoiceArea)FindInChildren(typeof(VoiceArea));

            // TODO: Переделать в будущем
            _distEat = 0;
            _distQueen = 0;
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
        /// <param name="distEat"></param>
        public void HearDistances(Vector2 dir, int distQueen, int distEat)
        {  
            //TODO: добавить LookAt и вынести этот самый лукзюк
            if (distEat < _distEat)
            {
                _distEat = distEat;
            }

            if (distQueen < _distQueen)
            {
                _distQueen = distQueen;
            }
        }


        // Private methods

        private void Shout()
        {
            foreach(Ant ant in _voiceArea.Ants)
            {
                if (ant == this) continue;

                ant.HearDistances(Position, _distQueen, _distEat);
            }
        }

        /// <summary>
        /// Делаем шаг и увеличиваем счетчики на один.
        /// </summary>
        private void Move()
        {
            _mover.Move(this);
            _distEat++;
            _distQueen++;
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