using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject gameOverUI; // Arrastrar un panel de Game Over desde el Canvas

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject); // Singleton pattern
    }

    public void PlayerDied()
    {
        if (gameOverUI != null)
            gameOverUI.SetActive(true);

        // Esperar unos segundos y reiniciar el nivel
        Invoke("RestartLevel", 2f); // 2 segundos de espera
    }

    void RestartLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}