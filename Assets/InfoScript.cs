using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoScript : MonoBehaviour
{

    //Textures
    public Texture drumpic;
    public Texture exhaustpic;
    public Texture heatpic;
    public Texture lintpic;
    public Texture fanpic;
    public Texture motorpic;
    public Texture idlerpic;
    public Texture cablepic;
    public Texture defaultpic;

    public RawImage wall;


    // Start is called before the first frame update
    void Start()
    {
        wall.texture = defaultpic;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "drum")
        {
            
            wall.texture = drumpic;
        }
        else if (other.tag == "fanblock")
        {
            wall.texture = exhaustpic;
        }
        else if (other.tag == "heatshell")
        {
            wall.texture = heatpic;
        }
        else if (other.tag == "linttrap")
        {
            wall.texture = lintpic;
        }
        else if (other.tag == "turbine")
        {
            wall.texture = fanpic;
        }
        else if (other.tag == "motor")
        {
            wall.texture = motorpic;
        }
        else if (other.tag == "idler")
        {
            wall.texture = idlerpic;
        }
        else if (other.tag == "cable")
        {
            wall.texture = cablepic;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        wall.texture = defaultpic;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
