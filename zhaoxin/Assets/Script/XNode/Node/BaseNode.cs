using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class BaseNode : Node
{
  
   public NodeType nodeType;
    public string id;
} 

public enum NodeType
    {
        DialogueNode,
        Select,
        Task,
        EndTaskDiscribe
    }