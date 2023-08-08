using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeaconTrigger : MonoBehaviour
{
    private GameObject parentGameObject;

    // TODO figure out how to autogenerate this
    public void setParentGameObject(GameObject gameObject)
    {
        this.parentGameObject = gameObject;
    }

    // TODO figure out how to autogenerate this
    public GameObject getParentGameObject()
    {
        return this.parentGameObject;
    }
}
