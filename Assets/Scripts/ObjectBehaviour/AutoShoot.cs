using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoShoot : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        foreach(Weapon w in GetComponentsInChildren<Weapon>())
        {
            w.shoot();
        }
    }
}
