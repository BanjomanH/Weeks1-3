using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FaucetCode : MonoBehaviour
{
    public Vector3 faucetPos; // The position of where the faucet is
    public bool stream; // Whether the sauce is currently coming out of the faucet
    public float hitbox; // The size of the hitbox on the faucet

    // Update is called once per frame
    void Update()
    {
        // Tests to see if the player is hovering and clicking down on the faucet
        if (checkArea(faucetPos) && Input.GetMouseButtonDown(0))
        {
            // Alternates the stream if so
            if (stream)
            {
                stream = false;
            } else
            {
                stream = true;
            }
        }
        
        // Changes the size to hide the flow if stream is false
        if (stream == true)
        {
            transform.localScale = Vector3.one;
        }
        else
        {
            transform.localScale = Vector3.zero;
        }
    }

    // This code is used to see if the mouse occupies the relevant area
    bool checkArea(Vector3 area)
    {
        // Creates 2 temporary variables to reduce on line length
        bool isInArea = false;
        Vector3 cursor = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Tests to see if the mouse falls within the x and y of the area (plus the hitbox for some tolerance)
        if (cursor.x > area.x - hitbox && cursor.x < area.x + hitbox)
        {
            if (cursor.y > area.y - hitbox && cursor.y < area.y + hitbox)
            {
                // Returns a sucessful check if so
                isInArea = true;
            }
        }

        return isInArea;
    }
}
