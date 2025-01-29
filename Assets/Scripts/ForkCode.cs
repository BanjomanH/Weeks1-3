using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class ForkCode : MonoBehaviour
{
    public Transform handPos; // The transform of the hands position
    public Transform shoulder; // The transform of the shoulders position
    public Vector3 pastaPos; // The position where the fork should collide with the pasta
    public Vector3 mouthPos; // The position where the fork should collide with the mouth
    public float maxDistance; // The furtherest distance the hand can go
    public float hitbox; // The size of the hitboxes on the mouth and pasta
    public bool spaghetti = true; // Whether spaghetti is dangling from the fork

    // Update is called once per frame
    void Update()
    {
        // A vector is created at the cursor
        Vector3 cursor = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // This vectors z is set to zero, and clamped using the maxDistance variable
        cursor.z = 0;
        cursor.x = Mathf.Clamp(cursor.x, shoulder.position.x - maxDistance, shoulder.position.x + maxDistance);
        cursor.y = Mathf.Clamp(cursor.y, shoulder.position.y - maxDistance, shoulder.position.y + maxDistance);

        // Finally, the position is set to the cursor
        handPos.position = cursor;

        // Checks to see if the fork hits any hitbox and sets spaghetti appropriately
        if (checkArea(pastaPos))
        {
            spaghetti = true;
        }
        if (checkArea(mouthPos))
        {
            spaghetti = false;
        }

        // Tests to see if spaghetti is true, and hides it by shrinking it to zero if false
        if (spaghetti == true)
        {
            transform.localScale = Vector3.one * 1.5f;
        } else
        {
            transform.localScale = Vector3.zero;
        }
    }

    // This code is used to see if the mouse occupies the relevant area
    bool checkArea(Vector3 area)
    {
        // Creates 2 temporary variables to reduce on line length
        bool isInArea = false;
        Vector2 forkPos = handPos.position;

        // Tests to see if the mouse falls within the x and y of the area (plus the hitbox for some tolerance)
        if (forkPos.x > area.x - hitbox && forkPos.x < area.x + hitbox)
        {
            if (forkPos.y > area.y - hitbox && forkPos.y < area.y + hitbox)
            {
                // Returns a sucessful check if so
                isInArea = true;
            }
        }

        return isInArea;
    }
}
