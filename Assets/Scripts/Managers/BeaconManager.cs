using System.Collections.Generic;
using UnityEngine;

public class BeaconManager : MonoBehaviour
{
    public GameObject PickupBeaconTriggerPrefab;
    public GameObject DeliveryBeaconTriggerPrefab;
    public GameObject SpeedUpBeaconTriggerPrefab;
    public GameObject SpeedDownBeaconTriggerPrefab;

    private List<GameObject> beaconSpawners;
    private HashSet<GameObject> activeBeaconSpawners;

    public void Awake()
    {
        this.beaconSpawners = new List<GameObject>(GameObject.FindGameObjectsWithTag("BeaconSpawnPoint"));
        this.activeBeaconSpawners = new HashSet<GameObject>();

        // Spawn a PickupBeacon
        GameObject randomBeaconSpawner = CollectionUtil.GetRandomElement(this.beaconSpawners);
        this.spawnBeacon(this.PickupBeaconTriggerPrefab, this.activeBeaconSpawners, randomBeaconSpawner);

        // Spawn a random speedup/speeddown
        //this.spawnBeacon(this.PickupBeaconTriggerPrefab, this.activeBeaconSpawners, CollectionUtil.GetRandomElement(this.beaconSpawners));
    }

    /*
     * Instantiates a new beacon of type gameObject at the provided position and rotation.
     */
    private void spawnBeacon(GameObject gameObjectTemplate, HashSet<GameObject> activeBeaconSpawners, GameObject beaconSpawner) // TODO: lets call spawns->spanwers
    {
        GameObject instance = Instantiate(gameObjectTemplate, beaconSpawner.transform.position, beaconSpawner.transform.rotation);
        instance.GetComponent<BeaconTrigger>().setParentGameObject(beaconSpawner);
        activeBeaconSpawners.Add(beaconSpawner);
    }

    private void despawnBeacon(HashSet<GameObject> activeBeaconSpawners, Component sender)
    {
        Destroy(sender.gameObject);
        activeBeaconSpawners.Remove(sender.GetComponent<BeaconTrigger>().getParentGameObject());
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

        // Spawn new DeliveryBeacon
        GameObject randomBeaconSpawner = CollectionUtil.GetRandomElementExcluding(this.beaconSpawners, this.activeBeaconSpawners);
        this.spawnBeacon(this.DeliveryBeaconTriggerPrefab, this.activeBeaconSpawners, randomBeaconSpawner);

        // Despawn sender PickupBeacon
        this.despawnBeacon(this.activeBeaconSpawners, sender);
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

        // Spawn new PickupBeacon
        GameObject randomBeaconSpawner = CollectionUtil.GetRandomElementExcluding(this.beaconSpawners, this.activeBeaconSpawners);
        this.spawnBeacon(this.PickupBeaconTriggerPrefab, this.activeBeaconSpawners, randomBeaconSpawner);

        // Despawn sender DeliveryBeacon
        this.despawnBeacon(this.activeBeaconSpawners, sender);
    }

    public void SpeedDown(Component sender, object data)
    {
        Debug.Log(string.Format("BeaconManager.SpeedDown: [sender: {0}] [dataL {1}]", sender, data));
    }

    public void SpeedUp(Component sender, object data)
    {
        Debug.Log(string.Format("BeaconManager.SpeedUp: [sender: {0}] [dataL {1}]", sender, data));
    }
}
