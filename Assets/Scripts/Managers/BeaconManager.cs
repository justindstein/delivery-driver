using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeaconManager : MonoBehaviour
{
    private List<GameObject> packageBeacons;
    private List<GameObject> deliveryBeacons;
    private GameObject lastActiveBeacon;

    private System.Random random;

    public void Awake()
    {
        this.packageBeacons = new List<GameObject>(GameObject.FindGameObjectsWithTag("PackageBeacon"));
        this.deliveryBeacons = new List<GameObject>(GameObject.FindGameObjectsWithTag("DeliveryBeacon"));

        this.deactivateAll(packageBeacons);
        this.deactivateAll(deliveryBeacons);
        this.activateRandom(packageBeacons);
    }

    private void deactivateAll(List<GameObject> gameObjects)
    {
        foreach (GameObject gameObject in gameObjects)
        {
            Debug.Log("Deactivating " + gameObject.name);
            gameObject.SetActive(false);
        }
    }

    private void activateRandom(List<GameObject> gameObjects)
    {
        Debug.Log("Let's activate randomly: " + gameObjects[this.random.Next(0, 2)].name);
    }

    public void packagePickup()
    {
        Debug.Log("Package picked up!");
    }

    public void packageDelivered()
    {
        Debug.Log("Package delivered!");
    }
}
