using UnityEngine;

public class PickupBeaconTrigger : MonoBehaviour
{
    [Header("Events")]
    public GameEvent OnPackagePickup;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("PickupBeaconTrigger");
        this.OnPackagePickup.Raise(this, null);
    }
}
