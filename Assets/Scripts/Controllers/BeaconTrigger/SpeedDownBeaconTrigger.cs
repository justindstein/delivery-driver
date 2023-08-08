using UnityEngine;

public class SpeedDownBeaconTrigger : BeaconTrigger
{
    [Header("Events")]
    public GameEvent OnSpeedDown; // TODO: remove 'on' and rename these to 'SpeedDownEvent'.
    public GameEvent BeaconExpire;

    void Start()
    {
        InvokeRepeating("OnBeaconExpire", 0.0f, 15.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.OnSpeedDown.Raise(this, null);
    }

    private void OnBeaconExpire()
    {
        this.BeaconExpire.Raise(this, null);
    }
}
