using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private float yMax;
    private float yMin;
    private float xMax;
    private float xMin;

    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        xMin = 22;
        xMax = 116;
        yMax = 7;
        yMin = 2;

        target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax), Mathf.Clamp(target.position.y, yMin, yMax), transform.position.z);
    }
}
