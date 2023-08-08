using UnityEngine;

public class SpeedUpBeaconTrigger : BeaconTrigger
{
    // TODO: Should I extend BeaconTrigger?

    [Header("Events")]
    public GameEvent OnSpeedUp;

    void Start()
    {
        InvokeRepeating("LaunchProjectile", 2.0f, 0.3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.OnSpeedUp.Raise(this, null);
    }

    void LaunchProjectile()
    {
        Debug.Log("LaunchProjectile");
    }
}

