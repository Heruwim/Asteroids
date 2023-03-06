using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _lives = 3;
    [SerializeField] private float _respawnTime = 3f;
    [SerializeField] private float _respawnInvulnerabilityTime = 3f;
    [SerializeField] private ParticleSystem _explosion;
    [SerializeField] private int _score = 0;

    public Player player;

    public void AsteroidDestroyed(Asteroid asteroid)
    {
        _explosion.transform.position = asteroid.transform.position;
        _explosion.Play();

        //to do score
    }

    public void PlayerDied()
    {
        _explosion.transform.position = player.transform.position;
        _explosion.Play();
        _lives--;

        if (_lives <= 0)
            GameOver();
        else
            Invoke(nameof(Respawn), _respawnTime);
    }

    private void Respawn()
    {
        player.transform.position = Vector3.zero;
        player.gameObject.layer = LayerMask.NameToLayer("IgnoreCollisions");
        player.gameObject.SetActive(true);

        Invoke(nameof(TurnOnCollisions), _respawnInvulnerabilityTime);
    }

    private void TurnOnCollisions()
    {
        player.gameObject.layer = LayerMask.NameToLayer("Player");
    }

    private void GameOver()
    {
        
    }
}
