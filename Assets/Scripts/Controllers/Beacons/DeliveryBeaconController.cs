using UnityEngine;

public class PackageDeliveryController : MonoBehaviour
{
    [Header("Events")]
    public GameEvent packageDelivery;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.packageDelivery.Raise(this, null);
    }
}
