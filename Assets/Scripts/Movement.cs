using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class Movement : MonoBehaviour
{
    [SerializeField] private ContactFilter2D _filter;
    [SerializeField] private float _speed = 200;
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

    private bool CheckAbilityMove()
    {
        var collisionCoont = _rigidbody2D.Cast(transform.up, _filter, _resulst, -1.3f);

        if (collisionCoont == 1)
        {
            return true;
        }
        return false;
    }

    private void Move(int direction)
    {

        if (CheckAbilityMove())
        {
            transform.Translate(transform.right * _speed * direction * Time.deltaTime);
        }
    }

    private void Update()
    {
        transform.Translate(Vector2.down * 0.15f * Time.deltaTime, Space.World);

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
