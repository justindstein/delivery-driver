using System.Collections.Generic;
using UnityEngine;

public class BeaconManager : MonoBehaviour
{
    public GameObject PickupBeaconPrefab;
    public GameObject DeliveryBeaconPrefab;

    private List<GameObject> beaconSpawns;
    private GameObject currentBeacon;

    public void Awake()
    {
        this.beaconSpawns = new List<GameObject>(GameObject.FindGameObjectsWithTag("BeaconSpawnPoint"));
        GameObject randomBeaconSpawn = GameObjectUtil.GetRandomElement(this.beaconSpawns);

        this.currentBeacon = this.spawnBeacon(this.PickupBeaconPrefab, randomBeaconSpawn.transform.position, randomBeaconSpawn.transform.rotation);
    }

    /*
     * Instantiates a beacon of type gameObject.
     */
    private GameObject spawnBeacon(GameObject gameObject, Vector3 position, Quaternion rotation)
    {
        GameObject instance = Instantiate(gameObject, position, transform.rotation);
        return instance;
    }

    public void packagePickup(Component sender, object data)
    {
        Debug.Log("packagePickup!");
        Destroy(this.currentBeacon);
        GameObject randomBeaconSpawn = GameObjectUtil.GetRandomElement(this.beaconSpawns);
        this.currentBeacon = this.spawnBeacon(this.DeliveryBeaconPrefab, randomBeaconSpawn.transform.position, randomBeaconSpawn.transform.rotation);
    }

    public void packageDelivered(Component sender, object data)
    {
        Debug.Log("packageDelivered!");
        Destroy(this.currentBeacon);
        GameObject randomBeaconSpawn = GameObjectUtil.GetRandomElement(this.beaconSpawns);
        this.currentBeacon = this.spawnBeacon(this.PickupBeaconPrefab, randomBeaconSpawn.transform.position, randomBeaconSpawn.transform.rotation);
    }
}
