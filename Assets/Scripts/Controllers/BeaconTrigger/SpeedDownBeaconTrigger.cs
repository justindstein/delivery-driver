using UnityEngine;

public class SpeedDownBeaconTrigger : BeaconTrigger
{
    // TODO: Should I extend BeaconTrigger?

    [Header("Events")]
    public GameEvent OnSpeedDown;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.OnSpeedDown.Raise(this, null);
    }
}
