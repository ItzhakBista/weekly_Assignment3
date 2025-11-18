using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoNextLevel : MonoBehaviour
{
    [SerializeField] int sceneIndex;
    [SerializeField] int pointsToNextLevel;
    [SerializeField] GameObject scoreObject;

    int score;
    int currentScene;
    [SerializeField] bool isTransitioning = false;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (PlayerStats.Instance.Health <= 0 && !isTransitioning)
        {
            SceneManager.LoadScene(sceneIndex);
            return;
        }
    }

    void Update()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        score = scoreObject.GetComponentInChildren<NumberField>().number;

        if (score >= pointsToNextLevel && isTransitioning && sceneIndex > currentScene)
        {
            Debug.LogWarning("Going to Level: "+ sceneIndex);
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
