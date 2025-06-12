using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryManager : MonoBehaviour
{
    public GameObject victoryUI; // Texto o panel de victoria en el Canvas
    public float delayBeforeRestart = 2f;

    private bool levelWon = false;

    void Update()
    {
        if (!levelWon && AllEnemiesDefeated())
        {
            WinLevel();
        }
    }

    bool AllEnemiesDefeated()
    {
        // Asegúrate de que tus enemigos tienen la etiqueta "Enemy"
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        return enemies.Length == 0;
    }

    void WinLevel()
    {
        levelWon = true;

        if (victoryUI != null)
            victoryUI.SetActive(true);

        Invoke("RestartLevel", 2f);
    }

    void RestartLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}