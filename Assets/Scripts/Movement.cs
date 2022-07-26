using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Movement : MonoBehaviour
{
    [SerializeField] private ContactFilter2D _filter;
    [SerializeField] private float _speed = 100;

    private float _speedDown = 0.2f;
    private float beamLength = -1.2f;
    private Rigidbody2D _rigidbody2D;

    private readonly RaycastHit2D[] _resulst = new RaycastHit2D[2];

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        SwipeCheck.SwipeMade += Move;
    }

    private void OnDisable()
    {
        SwipeCheck.SwipeMade -= Move;
    }

    private void Move(float direction)
    {
        var collisionCoont = _rigidbody2D.Cast(transform.up, _filter, _resulst, beamLength);

        if (collisionCoont == 1)
        {
            transform.Translate(transform.right * _speed * direction * Time.deltaTime);
        }
    }

    private void Update()
    {
        transform.Translate(Vector2.down * _speedDown * Time.deltaTime, Space.World);

        if (Input.GetKeyDown(KeyCode.A))
        {
            Move(-1);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Move(1);
        }
    }
}
