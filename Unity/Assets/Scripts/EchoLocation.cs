using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class EchoLocation : MonoBehaviour
{
    [SerializeField] private GameObject orb;

    private bool Raycasting;
    private bool Raycasted;
    private float RaycastRechrage = 1;

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
            Distance();
        }
    }

    private void FixedUpdate()
    {
        if (Raycasting && !Raycasted)
        {
            RaycastHit hit;
            float raycast_length = Mathf.Infinity; //10
            Vector3 fwd = transform.TransformDirection(Vector3.forward);
            Vector3 line = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z);

            Debug.DrawRay(line, fwd * raycast_length, Color.black);
            if (Physics.Raycast(transform.position, fwd, out hit, raycast_length))
            {
                Raycasted = true;
                //print("There is something in front of the object!");
                //print("Found an object - distance: " + hit.distance);
                Reaction(hit.distance);
            }
            else
            {
                Raycasted = true;
                //print("nothing");
            }
        }
    }

    private void RayCast(float location, bool xray) 
    {
        int distance;
        //return distance;

        if (!Raycasting) 
        {
            StartCoroutine(StartRaycast());
        }
    }

    private IEnumerator StartRaycast() 
    {
        print("start raycast");
        Raycasting = true;
        Raycasted = false;

        yield return new WaitForSeconds(RaycastRechrage);

        print("raycast over");
        Raycasting = false;
        Raycasted = true;
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

    private void Distance() 
    {
        float distance = 0;

        distance = Vector3.Distance(transform.position, orb.transform.position);

        Reaction(distance);

        //return distance???
    }
}
