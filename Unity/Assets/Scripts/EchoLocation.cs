using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using Unity.VisualScripting;

public class EchoLocation : MonoBehaviour
{
    [SerializeField] private GameObject orb;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) //left click, raycast on environment
        {
            EcholocateForward();
        }

        if (Input.GetKeyDown(KeyCode.Mouse1)) //right click, raycast to end, ignore environment
        {
            EcholocateOrb();
        }
    }

    private void EcholocateForward()
    {
        RaycastHit hit;
        float raycast_length = 1000; //Mathf.Infinity
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        Vector3 line = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z);

        Debug.DrawRay(line, fwd * raycast_length, Color.black, 3);
        if (Physics.Raycast(transform.position, fwd, out hit, raycast_length))
        {
            //print("There is something in front of the object!");
            //print("Found an object - distance: " + hit.distance);
            Reaction(hit.distance);
        }
        else
        {
            //print("nothing");
        }
    }

    private void EcholocateOrb()
    {
        float distanceToOrb = Vector3.Distance(transform.position, orb.transform.position);
        Reaction(distanceToOrb);
    }

    private void Reaction(float scale) 
    {
        if (scale >= 50)
        {
            print("far");
        }
        else if (scale >= 25)
        {
            print("medium");
        }
        else 
        {
            print("near");
        }
    }
}
