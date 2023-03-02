using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FireRateModifier : MonoBehaviour
{
    public float modifier = 0.2f;

    private List<Weapon> weapons;

    private void Awake()
    {
        weapons = GetComponentsInChildren<Weapon>().ToList<Weapon>();
    }
   
    void Start()
    {
        //foreach(Weapon w in weapons)
        //{
        //  w.addFireRateModifier(modifier);

        //}
    }

    private void OnDestroy()
    {
        foreach (Weapon w in weapons)
        {
            w.removeFireRateModifier(modifier);

        }
    }

    public void addComponentObject(GameObject go)
    {
        go.AddComponent<FireRateModifier>();
        go.GetComponent<WeaponSetController>().weaponUpgradeCheck();
    }

}
