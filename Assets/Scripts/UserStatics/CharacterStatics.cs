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
        
        public static int Coin=0;
        public static int Fans=0;
        
        public static Dictionary<string,int> PlayerStatsDict=new Dictionary<string,int>();
    }
}