using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private static ObjectPool instance;
    public GameObject[] prefabs;
    public int size;
    [SerializeField]private List<PoolObject> poolObjects;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        instantiateObjects();
    }

    private void instantiateObjects()
    {
        poolObjects = new List<PoolObject>();
        for (int i = 0; i < size; i++)
        {
            foreach(GameObject go in prefabs)
            {
                poolObjects.Add(Instantiate(go, transform).GetComponent<PoolObject>());
            }
        }
    }

    public PoolObject requestObject(PoolObjectType type)
    {
        foreach(PoolObject po in poolObjects)
        {
            if (po.type == type && !po.isActive())
            {
                return po;
            }
        }
        return null;
    }

    public static ObjectPool GetInstance()
    {
        return instance;
    }

    public void deactivateAllObject()
    {
        foreach(PoolObject po in poolObjects)
        {
            po.deactivate();
        }
    }
}
