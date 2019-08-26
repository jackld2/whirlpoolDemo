using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    public float speed = 50;
    public float Xaxis = 0;
    public float Yaxis = 0;
    public float Zaxis = 1;
    public bool isRotating = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isRotating = GetComponent<Rigidbody>().isKinematic;
        //this.transform.localRotation = Quaternion.SlerpUnclamped(Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 360, 0), Time.time);
        if (isRotating)
        {
            transform.Rotate(new Vector3(Time.deltaTime * speed * Xaxis, Time.deltaTime * speed * Yaxis, Time.deltaTime * speed * Zaxis));
        }
        
        
    }
}
