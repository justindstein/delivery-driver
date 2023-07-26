using System.Collections.Generic;
using UnityEngine;

public class BeaconManager : MonoBehaviour
{
    private List<GameObject> packageBeacons;
    private List<GameObject> deliveryBeacons;
    //private GameObject lastActiveBeacon;

    public void Awake()
    {
        this.packageBeacons = new List<GameObject>(GameObject.FindGameObjectsWithTag("PackageBeacon"));
        this.deliveryBeacons = new List<GameObject>(GameObject.FindGameObjectsWithTag("DeliveryBeacon"));

        GameObjectUtil.DeactivateAll(this.packageBeacons);
        GameObjectUtil.DeactivateAll(this.deliveryBeacons);
        GameObjectUtil.ActivateRandom(this.packageBeacons);

        //List<GameObject> newListShallowCopy = new List<GameObject>(this.packageBeacons); // points to same contents, but a different list
    }

    public void packagePickup(Component sender, object data)
    {
        Debug.Log("Package picked up!: " + sender.gameObject.name + " " + data + "contains?: " + this.packageBeacons.Contains(sender.gameObject));
        //this.lastActiveBeacon = sender.gameObject;
        sender.gameObject.SetActive(false);
        GameObjectUtil.ActivateRandom(this.deliveryBeacons);
    }

    public void packageDelivered(Component sender, object data)
    {
        Debug.Log("Package delivered!: " + sender.gameObject.name + " " + data);
        //this.lastActiveBeacon = sender.gameObject;
        sender.gameObject.SetActive(false);
        GameObjectUtil.ActivateRandom(this.packageBeacons);
    }
}
