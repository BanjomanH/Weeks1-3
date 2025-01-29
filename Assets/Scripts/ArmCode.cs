using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ArmCode : MonoBehaviour
{
    public Transform hand;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cursor = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursor.z = 0;
        Vector2 pointing = cursor - transform.position;
        transform.up = pointing;
        Vector3 localScale = transform.localScale;

        localScale.y = Vector3.Distance(transform.position, hand.position) * 2;

        transform.localScale = localScale;    
    }
}
