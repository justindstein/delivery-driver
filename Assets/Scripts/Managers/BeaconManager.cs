using System.Collections.Generic;
using UnityEngine;

public class BeaconManager : MonoBehaviour
{
    public GameObject PickupBeaconPrefab;
    public GameObject DeliveryBeaconPrefab;

    private List<GameObject> beaconSpawns;
    private GameObject activeBeacon;

    public void Awake()
    {
        this.beaconSpawns = new List<GameObject>(GameObject.FindGameObjectsWithTag("BeaconSpawnPoint"));
        GameObject randomBeaconSpawn = CollectionUtil.GetRandomElement(this.beaconSpawns);

        this.activeBeacon = this.spawnBeacon(this.PickupBeaconPrefab, randomBeaconSpawn.transform.position, randomBeaconSpawn.transform.rotation);
    }

    /*
     * Instantiates a beacon of type gameObject.
     */
    private GameObject spawnBeacon(GameObject gameObject, Vector3 position, Quaternion rotation)
    {
        GameObject instance = Instantiate(gameObject, position, transform.rotation);
        return instance;
    }

    public void PackagePickup(Component sender, object data)
    {
        Debug.Log(string.Format("packagePickup: [sender: {0}] [dataL {1}]", sender, data));
        Destroy(this.activeBeacon);
        GameObject randomBeaconSpawn = CollectionUtil.GetRandomElement(this.beaconSpawns);
        this.activeBeacon = this.spawnBeacon(this.DeliveryBeaconPrefab, randomBeaconSpawn.transform.position, randomBeaconSpawn.transform.rotation);
    }

    public void PackageDelivered(Component sender, object data)
    {
        Debug.Log(string.Format("packageDelivered: [sender: {0}] [dataL {1}]", sender, data));
        Destroy(this.activeBeacon);
        GameObject randomBeaconSpawn = CollectionUtil.GetRandomElement(this.beaconSpawns);
        this.activeBeacon = this.spawnBeacon(this.PickupBeaconPrefab, randomBeaconSpawn.transform.position, randomBeaconSpawn.transform.rotation);
    }

    public GameObject GetActiveBeacon()
    {
        return this.activeBeacon;
    }
}
