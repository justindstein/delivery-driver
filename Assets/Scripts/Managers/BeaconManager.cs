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

        // Spawn a SpeedUpBeacon/SpeedDownBeacon
        spawnRandomBeacon(new List<GameObject>() { SpeedUpBeaconTriggerPrefab, SpeedDownBeaconTriggerPrefab }, this.beaconSpawners, this.activeBeaconSpawners);
    }

    /// <summary>
    /// Spawns a new DeliveryBeacon and destroys sender of event.
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
    /// Spawns a new PickupBeacon and destroys sender of event.
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

    /// <summary>
    /// Spawns a new SpeedUpBeacon/SpeedDownBeacon and destroys sender of event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="data"></param>
    public void SpeedDown(Component sender, object data)
    {
        Debug.Log(string.Format("BeaconManager.SpeedDown: [sender: {0}] [dataL {1}]", sender, data));

        // Spawn a SpeedUpBeacon/SpeedDownBeacon
        spawnRandomBeacon(new List<GameObject>() { SpeedUpBeaconTriggerPrefab, SpeedDownBeaconTriggerPrefab }, this.beaconSpawners, this.activeBeaconSpawners);

        // Despawn sender SpeedDownBeacon
        this.despawnBeacon(this.activeBeaconSpawners, sender);
    }

    /// <summary>
    /// Spawns a new SpeedUpBeacon/SpeedDownBeacon and destroys sender of event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="data"></param>
    public void SpeedUp(Component sender, object data)
    {
        Debug.Log(string.Format("BeaconManager.SpeedUp: [sender: {0}] [dataL {1}]", sender, data));

        // Spawn a SpeedUpBeacon/SpeedDownBeacon
        spawnRandomBeacon(new List<GameObject>() { SpeedUpBeaconTriggerPrefab, SpeedDownBeaconTriggerPrefab }, this.beaconSpawners, this.activeBeaconSpawners);

        // Despawn sender SpeedUpBeacon
        this.despawnBeacon(this.activeBeaconSpawners, sender);
    }

    /// <summary>
    /// Spawns a new SpeedUpBeacon/SpeedDownBeacon and destroys sender of event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="data"></param>
    public void BeaconExpired(Component sender, object data)
    {
        Debug.Log(string.Format("BeaconManager.OnBeaconExpire: [sender: {0}] [dataL {1}]", sender, data));

        // Spawn a SpeedUpBeacon/SpeedDownBeacon
        spawnRandomBeacon(new List<GameObject>() { SpeedUpBeaconTriggerPrefab, SpeedDownBeaconTriggerPrefab }, this.beaconSpawners, this.activeBeaconSpawners);

        // Despawn sender SpeedUpBeacon/SpeedDownBeacon
        this.despawnBeacon(this.activeBeaconSpawners, sender);
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
        instance.GetComponent<BeaconTrigger>().ParentGameObject = randomBeaconSpawner;
    }

    private void despawnBeacon(HashSet<GameObject> activeBeaconSpawners, Component sender)
    {
        Destroy(sender.gameObject);
        activeBeaconSpawners.Remove(sender.GetComponent<BeaconTrigger>().ParentGameObject);

    }

    private void spawnRandomBeacon(List<GameObject> gameObjectTemplates, List<GameObject> beaconSpawners, HashSet<GameObject> activeBeaconSpawners)
    {
        GameObject randomGameObjectTemplate = CollectionUtil.GetRandomElement(gameObjectTemplates);
        this.spawnBeacon(randomGameObjectTemplate, beaconSpawners, activeBeaconSpawners);
    }
}
