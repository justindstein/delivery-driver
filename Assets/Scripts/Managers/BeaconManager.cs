using System.Collections.Generic;
using UnityEngine;

public class BeaconManager : MonoBehaviour
{
    // TODO: can this be changed to prefab?
    public GameObject PickupBeaconTrigger;
    // TODO: can this be changed to prefab?
    public GameObject DeliveryBeaconTrigger;

    private List<GameObject> beaconSpawns;
    private GameObject activeBeaconSpawn; // TODO: change to better name: randomBeaconSpawn
    private GameObject instantiatedBeacon;

    public void Awake()
    {
        this.beaconSpawns = new List<GameObject>(GameObject.FindGameObjectsWithTag("BeaconSpawnPoint"));
        this.activeBeaconSpawn = CollectionUtil.GetRandomElement(this.beaconSpawns);

        this.instantiatedBeacon = this.spawnBeacon(this.PickupBeaconTrigger, this.activeBeaconSpawn);
    }

    /*
     * Instantiates a new beacon of type gameObject at the provided position and rotation.
     */
    private GameObject spawnBeacon(GameObject gameObject, GameObject activeBeaconSpawn) // TODO: activeBeaconSpawn -> beaconSpawn and gameObject -> prefabTemplate
    {
        GameObject instance = Instantiate(gameObject, activeBeaconSpawn.transform.position, activeBeaconSpawn.transform.rotation);
        instance.GetComponent<BeaconTrigger>().setParentGameObject(activeBeaconSpawn);
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

        ///
        Debug.Log(string.Format("PackagePickup getParentGameObject [parentGameObject {0}]", sender.GetComponent<BeaconTrigger>().getParentGameObject()));
        ///


        Destroy(this.instantiatedBeacon);

        this.activeBeaconSpawn = CollectionUtil.GetRandomElementExcluding(this.beaconSpawns, new List<GameObject>() { this.activeBeaconSpawn });
        this.instantiatedBeacon = this.spawnBeacon(this.DeliveryBeaconTrigger, this.activeBeaconSpawn);
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

        ///
        Debug.Log(string.Format("PackagePickup getParentGameObject [parentGameObject {0}]", sender.GetComponent<BeaconTrigger>().getParentGameObject()));
        ///


        Destroy(this.instantiatedBeacon);

        this.activeBeaconSpawn = CollectionUtil.GetRandomElementExcluding(this.beaconSpawns, new List<GameObject>() { this.activeBeaconSpawn });
        this.instantiatedBeacon = this.spawnBeacon(this.PickupBeaconTrigger, this.activeBeaconSpawn);
    }
}
