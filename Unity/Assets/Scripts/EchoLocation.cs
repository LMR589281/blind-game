using UnityEngine;
using UnityEngine.InputSystem;

public class EchoLocation : MonoBehaviour
{
    private Controls controls;

    private void Awake()
    {
        controls = new Controls();
    }

    private void OnEnable()
    {
        controls.Player.EchoLocal.performed += Local_Cast;
        controls.Player.EchoFar.performed += End_Cast;
    }

    private void OnDisable()
    {
        controls.Player.EchoLocal.performed -= Local_Cast;
        controls.Player.EchoFar.performed -= End_Cast;
    }

    private void Local_Cast(InputAction.CallbackContext ctx) 
    {
        print("local");
    }

    private void End_Cast(InputAction.CallbackContext ctx)
    {
        print("end");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
