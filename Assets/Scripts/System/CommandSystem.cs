using UnityEngine;

namespace System
{
    public class CommandSystem
    {
        private object _result;
        private string[] _words;
        public CommandSystem(string command)
        {
            _words = command.Split();
            switch (_words[0].ToLower())
            {
                case "set":
                    break;
                case "get":
                    break;
                case "judge":
                    break;
                default:
                    Debug.LogError("Invalid command!");
                    break;
            }
        }

        public object GetResult()
        {
            return _result;
        }
    }
}