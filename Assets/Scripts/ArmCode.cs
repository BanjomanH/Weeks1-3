using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ArmCode : MonoBehaviour
{
    public Transform hand;
    public Transform shoulder;
    public float maxDistance;

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

        Vector2 pointing = cursor - transform.position;
        transform.up = pointing;

        Vector2 localScale = transform.localScale;

        localScale.y = Vector2.Distance(transform.position, hand.position) * 2;

        Vector2 localPos = Vector2.Lerp(shoulder.position, hand.position, 0.5f);
        transform.position = localPos;
        transform.localScale = localScale;
    }
}
