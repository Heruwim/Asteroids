using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 500f;
    [SerializeField] private float _maxLifeTime = 10f;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Project(Vector2 derection)
    {
        _rigidbody.AddForce(derection * this._speed);
        Destroy(this.gameObject, this._maxLifeTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
