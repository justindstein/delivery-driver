using UnityEngine;

public class SpeedUpBeaconTrigger : BeaconTrigger
{
    [SerializeField] private float BeaconExpiry;

    [Header("Events")]
    public GameEvent OnSpeedUp;
    public GameEvent BeaconExpire;

    void Start()
    {
        Invoke("OnBeaconExpire", this.BeaconExpiry);
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

