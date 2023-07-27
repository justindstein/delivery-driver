using UnityEngine;

public class DeliveryBeaconTrigger : MonoBehaviour
{
    [Header("Events")]
    public GameEvent OnPackageDelivery;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.OnPackageDelivery.Raise(this, null);
    }
}
