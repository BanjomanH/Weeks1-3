using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstScript : MonoBehaviour
{
    public float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;

        if (pos.x > 8.85f || pos.x < -8.85f)
        {
            speed = -speed;
        }

        pos.x += speed * Time.deltaTime;

        transform.position = pos;
    }
}
