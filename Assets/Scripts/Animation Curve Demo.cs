using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCurveDemo : MonoBehaviour
{
    public AnimationCurve curve;

    [Range(0, 1)]
    public float t;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t += speed * Time.deltaTime;
        transform.localScale = Vector2.one * curve.Evaluate(t);
    }
}
