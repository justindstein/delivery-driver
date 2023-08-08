using UnityEngine;

public class SpeedUpBeaconTrigger : BeaconTrigger
{
    [Header("Events")]
    public GameEvent OnSpeedUp;
    public GameEvent BeaconExpire;

    void Start()
    {
        InvokeRepeating("OnBeaconExpire", 0.0f, 15.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.OnSpeedUp.Raise(this, null);
    }

    private void OnBeaconExpire()
    {
        this.BeaconExpire.Raise(this, null);
    }
}

