using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour
{
    public delegate void DragEndedDelegate(Draggable draggableObject);

    public DragEndedDelegate dragEndedCallback;

    private bool isDragged = false;
    private Vector2 mouseDragStartPosi'tion;
    private Vector2 spriteDragStartPosition;

    private void OnMouseDown () 
    {
        isDragged = true;

        // find mouse start position and sprite's start position to calculate their relative locations
        mouseDragStartPosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spriteDragStartPosition = transform.localPosition;
    }

    private void OnMouseDrag ()
    {
        // set draggable's position to mouse position while mouse button is down
        if(isDragged) {
            transform.localPosition = spriteDragStartPosition + ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)mouseDragStartPosition);
        }
    }

    private void OnMouseUp() {
        isDragged = false;

        // run dragEndedCallback (delegate function) in SnapController
        dragEndedCallback(this);
    }
}
