using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoNextLevel : MonoBehaviour
{
    [SerializeField] int sceneIndex;
    [SerializeField] int pointsToNextLevel;
    [SerializeField] GameObject scoreObject;

    PlayerStats playerStats;
    int score;
    int currentScene;
    [SerializeField] bool isTransitioning = false;

    void Start()
    {
        playerStats = PlayerStats.Instance;

        if (playerStats == null)
            Debug.LogError("GotoNextLevel: PlayerStats.Instance not found");
    }

    void Update()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        score = scoreObject.GetComponentInChildren<NumberField>().number;

        if (playerStats.Health <= 0 && sceneIndex > currentScene && pointsToNextLevel == 0)
        {
            SceneManager.LoadScene(sceneIndex);
            return;
        }

        if (score >= pointsToNextLevel && isTransitioning && sceneIndex > currentScene)
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
