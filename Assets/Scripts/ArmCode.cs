using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ArmCode : MonoBehaviour
{
    public Transform hand; // The position of the hand object
    public Transform shoulder; // The position of the shoulder object
    public float maxDistance; // The maximum distance the arm can go

    // Update is called once per frame
    void Update()
    {
        // A vector is created at the cursor
        Vector3 cursor = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // This vectors z is set to zero, and clamped using the maxDistance variable
        cursor.z = 0;
        cursor.x = Mathf.Clamp(cursor.x, shoulder.position.x - maxDistance, shoulder.position.x + maxDistance);
        cursor.y = Mathf.Clamp(cursor.y, shoulder.position.y - maxDistance, shoulder.position.y + maxDistance);

        // A temp variable is created to feed into transform.up
        Vector2 pointing = cursor - transform.position;
        transform.up = pointing;

        // Creates a temp variable for the scale
        Vector2 localScale = transform.localScale;

        // Sets the scale to be the distance between the arm and the hand
        localScale.y = Vector2.Distance(transform.position, hand.position) * 2;

        // Creates a position inbetween the shoulder and the hand
        Vector2 localPos = Vector2.Lerp(shoulder.position, hand.position, 0.5f);
        
        // Applies both temp variables
        transform.position = localPos;
        transform.localScale = localScale;
    }
}
