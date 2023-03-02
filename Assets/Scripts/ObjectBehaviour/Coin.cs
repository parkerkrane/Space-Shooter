using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public ScriptableInteger coin;

    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void OnGain()
    {
        coin.value += 1;
    }
}
