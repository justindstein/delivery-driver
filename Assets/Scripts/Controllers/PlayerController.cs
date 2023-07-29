using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float SteerSpeed;
    [SerializeField] private float MoveSpeed;

    private SpriteRenderer spriteRenderer;
    private Color defaultColor;

    private readonly Color COLOR_GREEN = Color.green;
    private const string HORIZONTAL_AXIS = "Horizontal";
    private const string VERTICAL_AXIS = "Vertical";
    private const float STEER_SPEED_DIRECTION = -1f;

    private float movementInput;
    private float steerInput;

    private void Start()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        this.defaultColor = this.spriteRenderer.color;
    }

    void Update()
    {
        this.movementInput = Input.GetAxis(VERTICAL_AXIS);
        this.steerInput = Input.GetAxis(HORIZONTAL_AXIS);
    }

    private void FixedUpdate()
    {
        if (this.movementInput != 0)
        {
            transform.Translate(0, movementInput * MoveSpeed * Time.fixedDeltaTime, 0);
        }

        if (this.steerInput != 0)
        {
            transform.Rotate(0, 0, steerInput * SteerSpeed * STEER_SPEED_DIRECTION * Time.fixedDeltaTime);
        }
    }

    public void PackagePickup(Component sender, object data)
    {
        Debug.Log(string.Format("PlayerController.PackagePickup: [sender: {0}] [dataL {1}]", sender, data));
        this.spriteRenderer.color = this.COLOR_GREEN;
    }

    public void PackageDelivered(Component sender, object data)
    {
        Debug.Log(string.Format("PlayerController.PackageDelivered: [sender: {0}] [dataL {1}]", sender, data));
        this.spriteRenderer.color = this.defaultColor;
    }
}
