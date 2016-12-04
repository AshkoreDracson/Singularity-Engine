using System;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;
using Singularity.Core;

namespace Singularity
{
    public static class Game
    {
        public static GameForm Window { get; set; }

        //public static void Main(string[] args)
        //{
        //    GameCore.Initialize();
        //}

        public static void Initialize()
        {
            GameCore.Initialize();
        }
    }
}