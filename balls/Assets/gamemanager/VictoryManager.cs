using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryManager : MonoBehaviour
{
    public GameObject victoryUI;             // Panel de victoria
    public GameObject bossPrefab;            // Prefab del jefe
    public Transform bossSpawnPoint;         // Punto de spawn del jefe

    private bool bossSpawned = false;
    private GameObject bossInstance;

    void Update()
    {
        if (!bossSpawned)
        {
            if (AllEnemiesDefeated())
            {
                SpawnBoss();
            }
        }
        else
        {
            if (bossInstance == null) // El jefe fue destruido
            {
                WinGame();
            }
        }
    }

    bool AllEnemiesDefeated()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");

        foreach (GameObject enemy in enemies)
        {
            if (enemy.GetComponent<BossMarker>() == null)
            {
                // Hay al menos un enemigo común aún vivo
                return false;
            }
        }

        // Solo queda el jefe (o nada)
        return true;
    }

    void SpawnBoss()
    {
        bossInstance = Instantiate(bossPrefab, bossSpawnPoint.position, Quaternion.identity);
        bossSpawned = true;
    }

    void WinGame()
    {
        if (victoryUI != null)
            victoryUI.SetActive(true);

        Invoke(nameof(RestartLevel), 3f);
    }

    void RestartLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}