using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class ForkCode : MonoBehaviour
{
    public Transform handPos;
    public Transform shoulder;
    public Vector3 pastaPos;
    public Vector3 mouthPos;
    public float maxDistance;
    public float hitbox;
    public bool spaghetti = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cursor = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        cursor.z = 0;
        cursor.x = Mathf.Clamp(cursor.x, shoulder.position.x - maxDistance, shoulder.position.x + maxDistance);
        cursor.y = Mathf.Clamp(cursor.y, shoulder.position.y - maxDistance, shoulder.position.y + maxDistance);

        handPos.position = cursor;

        if (checkArea(pastaPos))
        {
            spaghetti = true;
        }
        if (checkArea(mouthPos))
        {
            spaghetti = false;
        }

        if (spaghetti == true)
        {
            transform.localScale = Vector3.one * 1.5f;
        } else
        {
            transform.localScale = Vector3.zero;
        }
    }
    bool checkArea(Vector3 area)
    {
        bool isInArea = false;
        Vector2 forkPos = handPos.position;

        if (forkPos.x > area.x - hitbox && forkPos.x < area.x + hitbox)
        {
            if (forkPos.y > area.y - hitbox && forkPos.y < area.y + hitbox)
            {
                isInArea = true;
            }
        }

        return isInArea;
    }
}
