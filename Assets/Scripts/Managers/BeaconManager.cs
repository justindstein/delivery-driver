using System.Collections.Generic;
using UnityEngine;

public class BeaconManager : MonoBehaviour
{
    public GameObject PickupBeaconTriggerPrefab;
    public GameObject DeliveryBeaconTriggerPrefab;

    private List<GameObject> beaconSpawners;

    public void Awake()
    {
        this.beaconSpawners = new List<GameObject>(GameObject.FindGameObjectsWithTag("BeaconSpawnPoint"));
        GameObject randomBeaconSpawner = CollectionUtil.GetRandomElement(this.beaconSpawners);

        this.spawnBeacon(this.PickupBeaconTriggerPrefab, randomBeaconSpawner);
    }

    /*
     * Instantiates a new beacon of type gameObject at the provided position and rotation.
     */
    private GameObject spawnBeacon(GameObject gameObjectTemplate, GameObject activeBeaconSpawn)
    {
        GameObject instance = Instantiate(gameObjectTemplate, activeBeaconSpawn.transform.position, activeBeaconSpawn.transform.rotation);
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

        Destroy(sender.gameObject);
        GameObject randomBeaconSpawner = CollectionUtil.GetRandomElementExcluding(this.beaconSpawners, new List<GameObject>() { sender.GetComponent<BeaconTrigger>().getParentGameObject() });
        this.spawnBeacon(this.DeliveryBeaconTriggerPrefab, randomBeaconSpawner);
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

        Destroy(sender.gameObject);
        GameObject randomBeaconSpawner = CollectionUtil.GetRandomElementExcluding(this.beaconSpawners, new List<GameObject>() { sender.GetComponent<BeaconTrigger>().getParentGameObject() });
        this.spawnBeacon(this.PickupBeaconTriggerPrefab, randomBeaconSpawner);
    }
}
