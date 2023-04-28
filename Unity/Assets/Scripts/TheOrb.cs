using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheOrb : MonoBehaviour
{
    private void Awake()
    {
        GameManager.Instance.SetOrb(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        print("you have met with the victory orb");
    }
}
