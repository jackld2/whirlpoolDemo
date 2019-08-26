using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactions : MonoBehaviour
{
    public GameObject controller;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            controller.transform.position += new Vector3(0, 0, 0.005f);

        }
        if (Input.GetKey(KeyCode.A))
        {
            controller.transform.position += new Vector3(0, 0, -0.005f);
        }

    }
}
