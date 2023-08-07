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

        Debug.Log("Type: " + PickupBeaconPrefab.GetType().ToString());
        Debug.Log("Type: " + DeliveryBeaconPrefab.GetType().ToString());

        this.instantiatedBeacon = this.spawnBeacon(this.PickupBeaconPrefab, this.activeBeaconSpawn);
    }

    /*
     * Instantiates a new beacon of type gameObject at the provided position and rotation.
     */
    private GameObject spawnBeacon(GameObject gameObject, GameObject activeBeaconSpawn)
    {
        GameObject instance = Instantiate(gameObject, activeBeaconSpawn.transform.position, activeBeaconSpawn.transform.rotation);
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
        this.instantiatedBeacon = this.spawnBeacon(this.DeliveryBeaconPrefab, this.activeBeaconSpawn);
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
        this.instantiatedBeacon = this.spawnBeacon(this.PickupBeaconPrefab, this.activeBeaconSpawn);
    }
}
