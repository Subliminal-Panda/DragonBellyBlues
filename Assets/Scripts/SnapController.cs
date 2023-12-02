using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapController : MonoBehaviour
{


    public List<Transform> snapPoints;
    public List<Draggable> draggableObjects;
    public float snapRange = 1.5f;
    public Vector2 snapOffset = new Vector2(0, -.05f);

    void Start()
    {
        foreach(Draggable draggable in draggableObjects){
            // assign onDragEnded method to dragEndedCallback (delegate) in Draggable script
            draggable.dragEndedCallback = OnDragEnded;
        }
    }

    // find nearest snap point in "Snap Points" array. Update draggable object's transform to it (minus snapOffset) if it is within snapRange
    private void OnDragEnded(Draggable draggable) {
        float closestDistance = -1;
        Transform closestSnapPoint = null;

    // iterate through snapPoints array, setting closestSnapPoint to the nearest snapPoint's location and closestDistance to the difference between the draggable and snapPoint.
        foreach(Transform snapPoint in snapPoints) {
            float currentDistance = Vector2.Distance(draggable.transform.localPosition, snapPoint.localPosition);
            if(closestSnapPoint == null || currentDistance < closestDistance) {
                closestSnapPoint = snapPoint;
                closestDistance = currentDistance;
            }
        }

    // set draggable's transform to closestSnapPoint's transform, plus the snapOffset
        if (closestSnapPoint != null && closestDistance <= snapRange){
            draggable.transform.localPosition = (Vector2)closestSnapPoint.localPosition + snapOffset;
        }
    }
}
