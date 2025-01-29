using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class DanglingCode : MonoBehaviour
{
    public AnimationCurve dangle;
    [Range(0, 1)]
    public float sec;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sec += speed * Time.deltaTime;
        if (sec > 1)
        {
            sec = 0;
        }
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 30 * dangle.Evaluate(sec) - 15);
    }
}
