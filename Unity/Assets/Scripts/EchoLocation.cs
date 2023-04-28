using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class EchoLocation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) //left click, raycast on environment
        {
            RayCast(0, false);
        }

        if (Input.GetKeyDown(KeyCode.Mouse1)) //right click, raycast to end, ignore environment
        {
            //print("1");
        }
    }

    private void FixedUpdate()
    {
        RaycastHit hit;

        float raycast_length = Mathf.Infinity; //10

        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        Vector3 line = new Vector3 (transform.position.x, transform.position.y + 1.5f, transform.position.z);

        Debug.DrawRay(line, fwd * raycast_length, Color.black);

        if (Physics.Raycast(transform.position, fwd, out hit, raycast_length))
        {
            print("There is something in front of the object!");
            print("Found an object - distance: " + hit.distance);
            Reaction(hit.distance);
        }
        else
        {
            print("nothing");
        }
    }

    private void RayCast(float location, bool xray) 
    {
        int distance;
        //return distance;
    }

    IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
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
