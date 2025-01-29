using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FaucetCode : MonoBehaviour
{
    public Vector3 faucetPos;
    public bool stream;
    public float hitbox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (checkArea(faucetPos) && Input.GetMouseButtonDown(0))
        {
            if (stream)
            {
                stream = false;
            } else
            {
                stream = true;
            }
        }

        if (stream == true)
        {
            transform.localScale = Vector3.one;
        }
        else
        {
            transform.localScale = Vector3.zero;
        }
    }

    bool checkArea(Vector3 area)
    {
        bool isInArea = false;
        Vector3 cursor = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (cursor.x > area.x - hitbox && cursor.x < area.x + hitbox)
        {
            if (cursor.y > area.y - hitbox && cursor.y < area.y + hitbox)
            {
                isInArea = true;
            }
        }

        return isInArea;
    }
}
