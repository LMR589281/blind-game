using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using Unity.VisualScripting;

public class EchoLocation : MonoBehaviour
{
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
        if (Input.GetKeyDown(KeyCode.R)) //reset player rotation
        {
            RestRotation();
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
        float distanceToOrb = Vector3.Distance(transform.position, GameManager.Instance.GetOrb().transform.position);
        Reaction(distanceToOrb);
    }

    private void RestRotation() 
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward);
    }

    private void Reaction(float scale) 
    {
        if (scale >= 100)
        {
            print("long");
        }
        else if (scale >= 75)
        {
            print("medium (long)");
        }
        else if (scale >= 50)
        {
            print("medium");
        }
        else if (scale >= 25)
        {
            print("medium (short)");
        }
        else 
        {
            print("short");
        }
    }
}
