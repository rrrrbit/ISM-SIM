using UnityEngine;
using System.Collections;
public class Variablesandfuncs : MonoBehaviour
{
    int myInt = 5;

    void Start()
    {
        MultiplyByTwo(myInt);
        Debug.Log(myInt);
    }

    int MultiplyByTwo(int number)
    {
        int result;
        result = number * 4;
        return result;

    }
    
}
