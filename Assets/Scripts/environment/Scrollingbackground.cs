using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrollingbackground : MonoBehaviour
{
    public Transform[] background;
    public float speed;

    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector3(0, -1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        positionUpdate();
        checkPosition();
    }

    private void positionUpdate()
    {
        background[0].position += direction * Time.deltaTime * speed;
        background[1].position += direction * Time.deltaTime * speed;
    }

    private void moveToTop(int index)
    {
        if (index == 0)
        {
            background[0].position = background[1].position + new Vector3(0, 10, 0);
        } else if (index == 1)
        {
            background[1].position = background[0].position + new Vector3(0, 10, 0);
        }
        
    }

    private void checkPosition() 
    {
        if (background[0].position.y <= -10f)
        {
            moveToTop(0);
        }
        if (background[1].position.y <= -10f)
        {
            moveToTop(1);
        }
    }
}
