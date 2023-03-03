using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _maxLifeTime = 30f;
    
    public float size = 1f;
    public float minSize = 0.5f;
    public float maxSize = 1.5f;

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        _spriteRenderer.sprite = _sprites[Random.Range(0, _sprites.Length)];

        transform.eulerAngles = new Vector3(0, 0, Random.value * 360f);
        transform.localScale = Vector3.one * size;
        _rigidbody.mass = size;
    }
    public void SetTrajectory(Vector2 derection)
    {
        _rigidbody.AddForce(derection * _speed);

        Destroy(gameObject, _maxLifeTime);
    }
}
