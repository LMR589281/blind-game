using UnityEngine;
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
        float raycast_length = 10f;

        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        Vector3 line = new Vector3 (transform.position.x, transform.position.y + 1.5f, transform.position.z);

        Debug.DrawRay(line, fwd * raycast_length, Color.black);

        if (Physics.Raycast(transform.position, fwd, raycast_length))
        {
            print("There is something in front of the object!");
        }
        else
        {
            print("nothing");
        }
    }

    private void RayCast(float location, bool xray) 
    {

    }
}
