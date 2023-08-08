using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
        this.spawnBeacon(this.PickupBeaconTriggerPrefab, this.beaconSpawners, this.activeBeaconSpawners);

        // TODO: randomly choose between speedup/speeddown
        // Spawn a SpeedUp/SpeedDown
        this.spawnBeacon(this.SpeedUpBeaconTriggerPrefab, this.beaconSpawners, this.activeBeaconSpawners);
    }

    /*
     * Instantiates a new beacon of type gameObject at the provided position and rotation.
     */
    [MethodImpl(MethodImplOptions.Synchronized)]
    private void spawnBeacon(GameObject gameObjectTemplate, List<GameObject> beaconSpawners, HashSet<GameObject> activeBeaconSpawners)
    {
        GameObject randomBeaconSpawner = CollectionUtil.GetRandomElementExcluding(beaconSpawners, activeBeaconSpawners);
        activeBeaconSpawners.Add(randomBeaconSpawner);

        GameObject instance = Instantiate(gameObjectTemplate, randomBeaconSpawner.transform.position, randomBeaconSpawner.transform.rotation);
        instance.GetComponent<BeaconTrigger>().setParentGameObject(randomBeaconSpawner);
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
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
        this.spawnBeacon(this.DeliveryBeaconTriggerPrefab, this.beaconSpawners, this.activeBeaconSpawners);

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
        this.spawnBeacon(this.PickupBeaconTriggerPrefab, this.beaconSpawners, this.activeBeaconSpawners);

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
