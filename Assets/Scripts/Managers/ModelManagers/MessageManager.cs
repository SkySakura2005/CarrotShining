using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

namespace Managers
{
    public class MessageNode
    {
        public MessageNode(string path,MessageNode fatherNode)
        {
            MessageNum = 0;
            selfMessage = false;
            Father = fatherNode;
            Children = new Dictionary<string, MessageNode>();
            if (fatherNode != null)
            {
                //fatherNode.Children.Add(path,this);
                Path = fatherNode.Path+"/"+path;
            }
            else
            {
                Path = path;
            }
        }
        public string Path;
        private bool selfMessage;
        public int MessageNum;
        public MessageNode Father;
        public Dictionary<string, MessageNode> Children;

        public void UpdateNewMessage()
        {
            if(selfMessage) return;
            MessageNum++;
            selfMessage = true;
            MessageNode fatherNode = Father;
            while (fatherNode != null)
            {
                fatherNode.MessageNum++;
                fatherNode = fatherNode.Father;
            }
        }

        public void ReadMessage()
        {
            if(!selfMessage) return;
            MessageNum--;
            selfMessage = false;
            MessageNode fatherNode = Father;
            while (fatherNode != null)
            {
                fatherNode.MessageNum--;
                fatherNode = fatherNode.Father;
            }
        }
    }
    public class MessageManager:MonoBehaviour
    {
        public static MessageManager Instance;
        
        private static MessageNode _rootNode;
        //private static List<MessageNode> _nodeList;
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
            _rootNode = new MessageNode("",null);
            Initialize();
        }

        private void Initialize()
        {
            CreateNewNode("phoneMainPage");
            CreateNewNode("phoneMainPage/MessagePage");
            CreateNewNode("phoneMainPage/BlogPage");
        }

        public void CreateNewNode(string fullPath)
        {
            MessageNode currentNode = _rootNode;
            MatchCollection matches = Regex.Matches(fullPath, @"([^/\\]+)");

            foreach (Match match in matches)
            {
                if (!currentNode.Children.ContainsKey(match.Groups[1].Value))
                {
                    currentNode.Children.Add(match.Groups[1].Value, new MessageNode(match.Groups[1].Value, currentNode));
                }
                currentNode=currentNode.Children[match.Groups[1].Value];
            }
        }

        public MessageNode GetNode(string fullPath)
        {
            MessageNode currentNode = _rootNode;
            MatchCollection matches = Regex.Matches(fullPath, @"([^/\\]+)");

            foreach (Match match in matches)
            {
                if (!currentNode.Children.ContainsKey(match.Groups[1].Value))
                {
                    Debug.LogError("The path "+match.Groups[1].Value+" in "+fullPath+" is not exists!");
                    return null;
                }
                currentNode=currentNode.Children[match.Groups[1].Value];
            }
            return currentNode;
        }
    }
}