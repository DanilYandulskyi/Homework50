using UnityEngine;

public class Ground : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Bird bird))
        {
            GameRestarter gameRestarter = new GameRestarter();

            gameRestarter.Restart();
        }
    }
}
