using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public UIManager uIManager;
    public ZombieSpawner zombieSpawner;
    public ItemSpawner itemSpawner;

    private int score = 0;

    public bool IsGameOver {get; private set;}

    private void Start()
    {
        uIManager.SetScore(score);
    }
    public void AddScore(int add)
    {
        if (IsGameOver)
        {
            return;
        }
        score += add;
        uIManager.SetScore(score);
    }
    public void Endgame()
    {
        IsGameOver = true;
        uIManager.SetActiveGameOverUI(true);

        itemSpawner.enabled = false;
        zombieSpawner.OnEndGame();
        itemSpawner.enabled = false;

    }
    public void Restart()
    {   
        SceneManager.LoadScene("Game Scene");
    }
}

