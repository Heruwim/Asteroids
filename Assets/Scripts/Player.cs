using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _thrustSpeed = 1.0f;
    [SerializeField] private float _turnSpeed = 1.0f;

    [SerializeField] private Bullet _buletPrefab;

    private Rigidbody2D _rigidbody;

    private bool _trusting;
    private float _turnDirection;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        
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

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        if (_trusting)
        {
            _rigidbody.AddForce(this.transform.up * this._thrustSpeed);
        }

        if(_turnDirection != 0)
        {
            _rigidbody.AddTorque(_turnDirection * this._turnSpeed);
        }
    }

    private void Shoot()
    {
        Bullet bullet = Instantiate(this._buletPrefab, this.transform.position, this.transform.rotation);
        bullet.Project(this.transform.up);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.rotation = 0f;
            gameObject.SetActive(false);

            FindObjectOfType<GameManager>().PlayerDied();
        }
    }
}
