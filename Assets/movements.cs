using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movements : MonoBehaviour

    
{
    public Transform startMarker;
    public Transform endMarker;

    private float startTime;
    private float timePassed;
    public float speed = 1.0F;
    public float rotSpeed = 1.0f;
    private float timeCount;
    private float maxDist;
    public bool lerpingOut;
    public bool lerpingIn;
    private Vector3 startingPos;
    private Quaternion startingRot;
    public float totalTime = 1f;
    private bool free;
    private bool disturbed;
    

    public GameObject objcanvas;
    //public GameObject player;
 






    // Start is called before the first frame update
    void Start()
    {
        GetComponent<MeshCollider>().enabled = false;
        free = false;
        objcanvas.GetComponent<Text>().enabled = false;
        GetComponent<Rigidbody>().useGravity = true;
        disturbed = false;



    }

    // Update is called once per frame
    void Update()
    {
        


        if ((OVRInput.GetDown(OVRInput.Button.Four) || Input.GetKey(KeyCode.Q)) && !lerpingOut)
        {
            disturbed = false;
            Debug.Log("Hit4");
            free = false;
            GetComponent<MeshCollider>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            //GetComponent<Rigidbody>().useGravity = false;

            timeCount = 0.0f;
            //GetComponent<MeshCollider>().enabled = false;
            startTime = Time.time;
            startingPos = this.transform.position;
            startingRot = this.transform.rotation;
            maxDist = Vector3.Distance(startingPos, endMarker.position);
            lerpingOut = true;
        }

        if (lerpingOut)
        {
            Debug.Log("Hit3");
            free = false;
            objcanvas.GetComponent<Text>().enabled = false;
            lerpingIn = false;
            float distTrav = (Time.time - startTime) * (maxDist/totalTime);
            float frac = distTrav / maxDist;
            transform.rotation = Quaternion.Slerp(startingRot, endMarker.rotation, timeCount);
            timeCount = timeCount + Time.deltaTime;
            transform.position = Vector3.Lerp(startingPos, endMarker.position, frac);
            
            if ( Vector3.Distance(transform.position, endMarker.position) <= 0.00001 && (Quaternion.Dot(transform.rotation, endMarker.rotation) >= 0.99 || Quaternion.Dot(transform.rotation, endMarker.rotation) <= -0.99)) {
                lerpingOut = false;
                GetComponent<MeshCollider>().enabled = true;
                free = true;
                objcanvas.GetComponent<Text>().enabled = true ;


            }

        }

        if ((OVRInput.GetDown(OVRInput.Button.Three) || Input.GetKey(KeyCode.E)) && !lerpingIn)
        {
            disturbed = false;
            free = false;
            Debug.Log("Hit2");
            timeCount = 0.0f;
            //GetComponent<MeshCollider>().enabled = false;
            lerpingOut = false;
            startTime = Time.time;
            startingPos = this.transform.position;
            startingRot = this.transform.rotation;
            maxDist = Vector3.Distance(startingPos, startMarker.position);
            lerpingIn = true;

        }

        if (lerpingIn)
        {
            Debug.Log("Hit1");
            free = false;
            objcanvas.GetComponent<Text>().enabled = false;
            GetComponent<MeshCollider>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            //GetComponent<Rigidbody>().useGravity = false;

            float distTrav = (Time.time - startTime) * (maxDist / totalTime);
            float frac = distTrav / maxDist;
            transform.rotation = Quaternion.Slerp(startingRot, startMarker.rotation, timeCount);
            timeCount = timeCount + Time.deltaTime;
            transform.position = Vector3.Lerp(startingPos, startMarker.position, frac);
            if (Vector3.Distance(transform.position, startMarker.position) <= 0.00001 && (Quaternion.Dot(transform.rotation, startMarker.rotation) >= 0.99 || Quaternion.Dot(transform.rotation, startMarker.rotation) <= -0.99))
            {
                lerpingOut = false;
            }
        }
        if (free)
        {
            //objcanvas.GetComponent<Text>().text = objname;
            //objcanvas.transform.rotation = Quaternion.LookRotation(drumCanvas.transform.position - player.transform.position);
        }

        if (free && Vector3.Distance(transform.position, endMarker.position) > 0.001)
        {
            Debug.Log("Help");
            //GetComponent<Rigidbody>().isKinematic = false;
            //GetComponent<Rigidbody>().useGravity = true;
            //disturbed = true;
            //Debug.Log("LOOOPER");


        }








    }
}
