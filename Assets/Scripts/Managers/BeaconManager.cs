using System.Collections.Generic;
using UnityEngine;

public class BeaconManager : MonoBehaviour
{
    public GameObject PickupBeaconPrefab;
    public GameObject DeliveryBeaconPrefab;

    private List<GameObject> beaconSpawns;
    private GameObject activeBeaconSpawn;
    private GameObject instantiatedBeacon;

    public void Awake()
    {
        this.beaconSpawns = new List<GameObject>(GameObject.FindGameObjectsWithTag("BeaconSpawnPoint"));
        this.activeBeaconSpawn = CollectionUtil.GetRandomElement(this.beaconSpawns);

        this.instantiatedBeacon = this.spawnBeacon(this.PickupBeaconPrefab, this.activeBeaconSpawn.transform.position, this.activeBeaconSpawn.transform.rotation);
    }

    /*
     * Instantiates a new beacon of type gameObject at the provided position and rotation.
     */
    private GameObject spawnBeacon(GameObject gameObject, Vector3 position, Quaternion rotation)
    {
        GameObject instance = Instantiate(gameObject, position, transform.rotation);
        return instance;
    }

    /// <summary>
    /// Destroys existing instantiatedBeacon, randomly chooses a beacon from the set of beaconSpawns excluding the location of instantedBeacon,
    /// and instantiates a new DeliveryBeaconPrefab.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="data"></param>
    public void PackagePickup(Component sender, object data)
    {
        Debug.Log(string.Format("BeaconManager.PackagePickup: [sender: {0}] [dataL {1}]", sender, data));
        Destroy(this.instantiatedBeacon);

        this.activeBeaconSpawn = CollectionUtil.GetRandomElementExcluding(this.beaconSpawns, new List<GameObject>() { this.activeBeaconSpawn });
        this.instantiatedBeacon = this.spawnBeacon(this.DeliveryBeaconPrefab, this.activeBeaconSpawn.transform.position, this.activeBeaconSpawn.transform.rotation);
    }

    /// <summary>
    /// Destroys existing instantiatedBeacon, randomly chooses a beacon from the set of beaconSpawns excluding the location of instantedBeacon,
    /// and instantiates a new PickupBeaconPrefab.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="data"></param>
    public void PackageDelivered(Component sender, object data)
    {
        Debug.Log(string.Format("BeaconManager.PackageDelivered: [sender: {0}] [dataL {1}]", sender, data));
        Destroy(this.instantiatedBeacon);

        this.activeBeaconSpawn = CollectionUtil.GetRandomElementExcluding(this.beaconSpawns, new List<GameObject>() { this.activeBeaconSpawn });
        this.instantiatedBeacon = this.spawnBeacon(this.PickupBeaconPrefab, this.activeBeaconSpawn.transform.position, this.activeBeaconSpawn.transform.rotation);
    }
}
