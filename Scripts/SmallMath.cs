using Godot;
using System;

public static partial class SmallMath
{
	    public static float DegToRad(float angle) {
            return ((float)Math.PI / 180) * angle;
        }


        public static float NextFloat(float min, float max){
            System.Random random = new System.Random();
            double val = (random.NextDouble() * (max - min) + min);
            return (float)val;
        }
}
