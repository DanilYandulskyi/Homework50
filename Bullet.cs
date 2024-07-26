using UnityEngine;

[RequireComponent(typeof(Mover))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _destroyDelay;

    private ScoreCounter _scoreCounter;
    private Mover _mover;
    private Entity _owner;
    private Vector2 _direction;

    private void Start()
    {
        _scoreCounter = FindObjectOfType<ScoreCounter>();
    }

    private void Awake()
    {
        _mover = GetComponent<Mover>();

        Destroy(gameObject, _destroyDelay);
    }

    private void Update()
    {
        if (_direction != Vector2.zero)
        {
            _mover.Move(_direction);
        }
    }

    public void Initialize(Vector2 direction, Entity owner)
    {
        _direction = direction.normalized;
        _owner = owner;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Entity entity))
        {
            if (entity.gameObject.TryGetComponent(out Bird bird))
            {
                if (_owner != entity)
                {
                    GameRestarter gameRestarter = new GameRestarter();

                    gameRestarter.Restart();
                }
            }

            if ((_owner is Enemy) == false)
            {
                if (_owner.gameObject != collision.gameObject)
                {
                    Destroy(collision.gameObject);
                    _scoreCounter.Add();
                }
            }
        }

        Destroy(gameObject);
    }
}