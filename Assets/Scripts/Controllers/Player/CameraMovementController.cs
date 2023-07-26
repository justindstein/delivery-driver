using UnityEngine;

public class CameraMovementController : MonoBehaviour
{
    [SerializeField] private GameObject followGameObject;

    void LateUpdate()
    {
        transform.position = new Vector3(followGameObject.transform.position.x, followGameObject.transform.position.y, transform.position.z);
    }
}
