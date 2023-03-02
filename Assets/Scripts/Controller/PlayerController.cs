using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Moveable))]
public class PlayerController : MonoBehaviour
{
    public InputHandler inputHandler;
    private Moveable moveable;

    void Awake()
    {
        moveable = GetComponent<Moveable>();
    }

    void Start()
    {
        
    }


    private void OnSetDirection(Vector2 direction)
    {
        //Debug.Log("test 123" + direction);
        moveable.setDirection(direction);
    }

    private void OnEnable()
    {
        inputHandler.OnMoveAction += OnSetDirection;
    }

    private void OnDisable()
    {
        inputHandler.OnMoveAction -= OnSetDirection;
    }
}
