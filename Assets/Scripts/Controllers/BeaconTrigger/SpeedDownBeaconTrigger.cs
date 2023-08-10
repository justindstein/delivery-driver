using UnityEngine;

public class SpeedDownBeaconTrigger : BeaconTrigger
{
    [SerializeField] private float BeaconExpiry;

    [Header("Events")]
    public GameEvent OnSpeedDown;
    public GameEvent BeaconExpire;

    void Start()
    {
        Invoke("OnBeaconExpire", this.BeaconExpiry);
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
