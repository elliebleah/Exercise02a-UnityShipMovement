using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    
    private Camera mainCamera;
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    void Start()
    {
        mainCamera = Camera.main;
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    void Update()
    {
        WrapScreen();
    }

    void WrapScreen()
    {
        Vector3 viewPos = transform.position;
        float newX = viewPos.x;
        float newY = viewPos.y;

        // Check if the sprite is outside the screen horizontally

        newX = viewPos.x + objectWidth < -screenBounds.x ?  screenBounds.x + objectWidth : newX;
        newX = viewPos.x - objectWidth >  screenBounds.x ? -screenBounds.x - objectWidth : newX;

        newY = viewPos.y + objectHeight < -screenBounds.y ?  screenBounds.y + objectHeight : newY;
        newY = viewPos.y - objectHeight > screenBounds.y ? -screenBounds.y - objectHeight : newY;
        
        if (newX != viewPos.x || newY != viewPos.y)
        {
            transform.position = new Vector3(newX, newY, viewPos.z);
        }
    }
}

