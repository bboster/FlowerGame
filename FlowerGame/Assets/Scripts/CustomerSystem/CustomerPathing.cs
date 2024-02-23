using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// John Paul Fairbanks - Pathway / Waypoint system understood through tutorial by MetalStrom Games

public class CustomerPathing : MonoBehaviour
{
    // The OnDrawGizmos will only run during scene usage - essentially a visualiser for users and tweaking.

    private void OnDrawGizmos()
    {
        // Essentially used to track all children underneath the "Waypoints" object - form a visible wire in editor
        foreach(Transform t in transform)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(t.position, 1f);
        }

        // Method which will draw a line between the various waypoints.
        Gizmos.color = Color.blue;

        // childCount - 1 prevents an out of bounds error (think of an index system, starts at 0 - last child could be 3 instead of 4)
        for(int i = 0; i < transform.childCount - 1; i++)
        {
            Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(i + 1).position);
        }

    }


    public Transform GetNextPosition(Transform currentPosition)
    {
        if(currentPosition == null)
        {
            return transform.GetChild(0);
        }

        // This will retrieve the following 'children' or siblings within hierarchy.
        // Condition checker for weather or not the customer has reached its final position.
        if(currentPosition.GetSiblingIndex() < transform.childCount - 1)
        {
            return transform.GetChild(currentPosition.GetSiblingIndex() + 1);
        }

        // Occurs for when customer reaches final determined position.
        else
        {
            return transform.transform.GetChild(currentPosition.GetSiblingIndex());
        }
    }
}
