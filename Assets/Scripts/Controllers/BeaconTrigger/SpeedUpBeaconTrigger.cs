using UnityEngine;

public class SpeedUpBeaconTrigger : BeaconTrigger
{
    [Header("Events")]
    public GameEvent OnSpeedUp;
    public GameEvent BeaconExpire;

    void Start()
    {
        // Note: parameters 'time' and 'repeatRate' not working as expected. 'time' influences
        //frequency, and 'repeatRate' influences initial delay.
        InvokeRepeating("OnBeaconExpire", 10.0f, 0.0f);
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

