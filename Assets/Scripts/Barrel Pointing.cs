using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class BarrelPointing : MonoBehaviour
{
    public GameObject prefab;
    public Transform target;
    public TankShell tankShell;
    public List<GameObject> bulletList = new List<GameObject>();

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

        if (Input.GetMouseButtonDown(0))
        {
            GameObject shot = Instantiate(prefab);
            shot.transform.position = transform.position;
            shot.transform.up = pointing;

            tankShell = shot.GetComponent<TankShell>();
            bulletList.Add(shot);
        }

        for (int i = 0; i < bulletList.Count(); i++)
        {
            
        }
    }
}
