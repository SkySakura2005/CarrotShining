using System;
using System.Collections.Generic;
using Statics;
using UnityEngine;

namespace Managers
{
    public class PlayerModelManager:MonoBehaviour
    {
        public static PlayerModelManager Instance;

        private Dictionary<string, int> _characteristicDict = new Dictionary<string, int>();
        private Dictionary<string, long> _bigNumDict = new Dictionary<string, long>();
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this);
            }
            Initialize();
        }

        private void Initialize()
        {
            _characteristicDict.Add("Charm", CharacterStatics.Charm);
            _characteristicDict.Add("Posture", CharacterStatics.Posture);
            _characteristicDict.Add("Singing", CharacterStatics.Singing);
            _characteristicDict.Add("Confidence", CharacterStatics.Confidence);
            _characteristicDict.Add("Rhetoric", CharacterStatics.Rhetoric);
            _characteristicDict.Add("Aesthetics", CharacterStatics.Aesthetics);
            _characteristicDict.Add("Rhyme", CharacterStatics.Rhyme);
            _characteristicDict.Add("Darkness", CharacterStatics.Darkness);
            _characteristicDict.Add("Acting", CharacterStatics.Acting);
            _characteristicDict.Add("Luckness", CharacterStatics.Luckness);
            _characteristicDict.Add("Wisdom", CharacterStatics.Wisdom);
            _characteristicDict.Add("Sense", CharacterStatics.Sense);
            
            _bigNumDict.Add("Coin", CharacterStatics.Coin);
            _bigNumDict.Add("Fans", CharacterStatics.Fans);
        }
        public int GetCharacterModel(string modelName)
        {
            if (!_characteristicDict.ContainsKey(modelName))
            {
                Debug.LogError("the name "+modelName+" is not an illegal characteristic name!");
                return -1;
            }
            return _characteristicDict[modelName];
        }

        public string GetBigNumString(string modelName)
        {
            if (!_bigNumDict.ContainsKey(modelName))
            {
                Debug.LogError("the name " + modelName + " is not an illegal big number name.");
                return "";
            }
            long num=_bigNumDict[modelName];
            int digit = num.ToString().Length;
            if (digit >= 5 && digit < 9)
            {
                return ((float)num/1e4).ToString("F1")+"万";
            }
            else if (digit >= 9&&digit < 13)
            {
                return ((float)num/1e8).ToString("F1")+"亿";
            }
            else if (digit >= 13)
            {
                return ((float)num/1e12).ToString("F1")+"万亿";
            }
            return num.ToString();
        }
    }
}