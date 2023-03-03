using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _thrustSpeed = 1.0f;
    [SerializeField] private float _turnSpeed = 1.0f;

    private Rigidbody2D _rigidbody;

    private bool _trusting;
    private float _turnDirection;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _trusting = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            _turnDirection = 1.0f;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            _turnDirection = -1.0f;
        }
        else { _turnDirection = 0.0f; }
    }

    private void FixedUpdate()
    {
        if (_trusting)
        {
            _rigidbody.AddForce(this.transform.up * _thrustSpeed);
        }

        if(_turnDirection != 0)
        {
            _rigidbody.AddTorque(_turnDirection * _turnSpeed);
        }
    }
}
