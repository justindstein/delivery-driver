using UnityEngine;

public class SpeedUpBeaconTrigger : BeaconTrigger
{
    // TODO: Should I extend BeaconTrigger?

    [Header("Events")]
    public GameEvent OnSpeedUp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.OnSpeedUp.Raise(this, null);
    }
}

