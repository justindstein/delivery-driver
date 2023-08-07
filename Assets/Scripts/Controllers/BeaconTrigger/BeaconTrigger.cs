using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeaconTrigger : MonoBehaviour
{
    private GameObject parentGameObject;

    // TODO figure out how to autogenerate this
    public void setParentGameObject(GameObject gameObject)
    {
        Debug.Log("BeaconTrigger.setParentGameObject");
        this.parentGameObject = gameObject;
    }

    // TODO figure out how to autogenerate this
    public GameObject getParentGameObject()
    {
        Debug.Log("BeaconTrigger.getParentGameObject");
        return this.parentGameObject;
    }
}
