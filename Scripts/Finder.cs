using Godot;
using System;


namespace AntAlgorithm 
{
	public static partial class Finder
	{
		/// <summary>
        /// Находит нужный скрипт в дочерних Node.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
		public static Variant FindInChildren(Node parent, Type type)
        {
            var childrens = parent.GetChildren();

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