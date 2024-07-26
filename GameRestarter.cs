using UnityEngine.SceneManagement;

public class GameRestarter
{
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
