using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float fireRate;
    public List<float> fireRateModifiers;
    public PoolObjectType type;

    private float timer = 0;
    
    void Awake()
    {
        fireRateModifiers = new List<float>();
    }

    void Start()
    {
        
    }

    
    void Update()
    {

        timer = timer - Time.deltaTime > 0 ? timer - Time.deltaTime : 0f; 
    }

    internal void addFireRateModifier(float modifier)
    {
        fireRateModifiers.Add(modifier);
    }

    internal void removeFireRateModifier(float modifier)
    {
        fireRateModifiers.Remove(modifier);
    }

    public void shoot()
    {
        if (timer == 0f)
        {
            // Debug.Log("tembak");
            ObjectPool.GetInstance().requestObject(type).activate(transform.position, transform.rotation);
            timer = fireRate / getFireRateModifier();
        }
    }

    private float getFireRateModifier()
    {
        float mod = 1;

        foreach(float f in fireRateModifiers)
        {
            mod += f;
        }
        return mod;
    }

    internal void clearModifier()
    {
        fireRateModifiers.Clear();
    }

}
