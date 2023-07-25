using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeaconManager : MonoBehaviour
{
    public void packageDelivered()
    {
        Debug.Log("Package delivered!");
    }

    public void packagePickup()
    {
        Debug.Log("Package picked up!");
    }
}
