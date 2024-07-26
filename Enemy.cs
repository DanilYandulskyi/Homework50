using UnityEngine;

public class Enemy : Entity
{
    [SerializeField] private Bullet _bullet;
    
    [SerializeField] private Bullet _spawnedBullet;

    private void Start()
    {
        Instantiate(_bullet, Vector3.left + transform.position, Quaternion.identity).Initialize(Vector2.left, this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Bird bird))
        {
            GameRestarter gameRestarter = new GameRestarter();

            gameRestarter.Restart();
        }
    }
}
