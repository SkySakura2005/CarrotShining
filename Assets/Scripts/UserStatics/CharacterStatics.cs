using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace Statics
{
    public static class CharacterStatics
    {
        public static string PlayerName = "米米毛";
        public static int PlayerHeight=165;
        public static int PlayerWeight=50;

        public const int MaxMood = 100;
        public const int MaxLuck = 100;
        public const int MaxHealth = 100;
        
        public static int Mood=MaxMood;
        public static int Luck=Random.Range(0,MaxLuck+1);
        public static int Health=MaxHealth;
        
        public static long Coin=100000;
        public static long Fans=0;

        public static int Charm=0;
        public static int Posture=0;
        public static int Singing=0;
        public static int Confidence=0;
        public static int Rhetoric=0;
        public static int Aesthetics=0;
        public static int Rhyme=0;
        public static int Darkness=0;
        public static int Acting=0;
        public static int Luckness=0;
        public static int Wisdom=0;
        public static int Sense=0;
    }
}