using UnityEngine;

public class BeaconTriggerController : MonoBehaviour
{
    [Header("Events")]
    public GameEvent BeaconTrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.BeaconTrigger.Raise(this, null);
    }
}
