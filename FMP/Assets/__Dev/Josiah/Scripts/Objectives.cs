using System;
using UnityEngine;
public class Objectives : MonoBehaviour
{

    public class  Node_Objective { }

    public Action OnComplete;

    public Action OnValuechange;
  

    public string EventTrigger { get; }
    public bool IsComplete { get; private set; }
    public int MaxValue { get; }
    public int CurrentValue {  get; private set; }


    void Start()
    {
        
    }

    

    void Update()
    {
        
    }
}
