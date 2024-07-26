using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _tapForce;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;

    private Rigidbody2D _rigidbody;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
    }

    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    public void Jump()
    {
        _rigidbody.velocity = new Vector2(_speed, _tapForce);
        transform.rotation = _maxRotation;
    }

    public void Move(Vector2 direction)
    {
        transform.Translate(direction * _speed * Time.deltaTime);
    }
}
