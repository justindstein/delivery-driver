using UnityEngine;

public class SpeedDownBeaconTrigger : BeaconTrigger
{
    // TODO: Should I extend BeaconTrigger?

    [Header("Events")]
    public GameEvent OnSpeedDown;

    void Start()
    {
        InvokeRepeating("LaunchProjectile", 2.0f, 0.3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.OnSpeedDown.Raise(this, null);
    }

    void LaunchProjectile()
    {
        Debug.Log("LaunchProjectile");
    }
}
