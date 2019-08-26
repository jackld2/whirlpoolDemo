using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class text : MonoBehaviour
{
    public GameObject drumCanvas;
    public GameObject player;
    
    

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {



    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.tag);
        

        if (other.tag == "drum")
        {
            drumCanvas.GetComponent<Text>().text = "DRYER\nDRUM ";
            drumCanvas.transform.rotation = Quaternion.LookRotation(drumCanvas.transform.position - player.transform.position );
            
            
        }
    }
}
