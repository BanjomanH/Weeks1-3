using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class DanglingCode : MonoBehaviour
{
    public AnimationCurve dangle; // The curve for the dangling animation
    [Range(0, 1)]
    public float sec; // A float for the time passed
    public float speed; // How fast the sec variable progresses

    // Update is called once per frame
    void Update()
    {
        // Progresses sec upwards by speed in context of the time between the last frame
        sec += speed * Time.deltaTime;
        // resets sec if it goes too high
        if (sec > 1)
        {
            sec = 0;
        }
        // Sets the rotation to be the same for x and y, but adds some more rotation according to dangle
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 30 * dangle.Evaluate(sec) - 15);
    }
}
