using UnityEngine;

public class PackagePickupController : MonoBehaviour
{
    [Header("Events")]
    public GameEvent packagePickup;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.packagePickup.Raise(this, null);
    }
}
