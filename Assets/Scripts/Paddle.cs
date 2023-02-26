using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float speed;
    public InputManager inputManager;
    float screenHalfWidthInWorldUnits;

    void Start()
    {
        // getting half of player width and half of screen width 
        float halfPlayerWidth = transform.localScale.x / 2f;
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize - halfPlayerWidth;
    }

    private void HandleMovement()
    {
        Vector2 input = inputManager.GetMovementInput();
        transform.Translate(input * speed * Time.deltaTime);
    }

    void Update()
    {
        HandleMovement();
        // blocking paddle from going out of the screen
        if (transform.position.x > screenHalfWidthInWorldUnits)
            transform.position = new Vector3(screenHalfWidthInWorldUnits, transform.position.y, 0f);
        else if (transform.position.x < -screenHalfWidthInWorldUnits)
            transform.position = new Vector3(-screenHalfWidthInWorldUnits, transform.position.y, 0f);
    }
}
