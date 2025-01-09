using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FollowCursor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;

        pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = pos;
    }
}
