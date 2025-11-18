using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

/**
 * This component spawns the given laser-prefab whenever the player clicks a given key.
 * It also updates the "scoreText" field of the new laser.
 */
public class LaserShooter : ClickSpawner
{
    [SerializeField]
    [Tooltip("How many points to add to the shooter, if the laser hits its target")]
    int pointsToAdd = 1;
    [SerializeField] bool autoShoot = false;
    [SerializeField] float secondsBetweenShots = 2f;
    // A reference to the field that holds the score that has to be updated when the laser hits its target.
    private NumberField scoreField;
    float shootTimer = 0f;

    void Awake()
    {
        if (scoreField == null)
        {
            scoreField = FindFirstObjectByType<NumberField>();
        }
    }

    void Update()
    {
        if (autoShoot)
        {
            shootTimer += Time.deltaTime;

            if (shootTimer >= secondsBetweenShots)
            {
                shootTimer = 0f;
                spawnObject();
            }
            return;
        }

        if (spawnAction.WasPressedThisFrame())
        {
            spawnObject();
        }
    }

    private void Start()
    {

    }

    private void AddScore()
    {
        scoreField.AddNumber(pointsToAdd);
    }

    protected override GameObject spawnObject()
    {
        GameObject newObject = base.spawnObject();  // base = super
        DestroyOnTrigger2D newObjectDestroyer = newObject.GetComponent<DestroyOnTrigger2D>();
        if (newObjectDestroyer)
            newObjectDestroyer.onHit += AddScore;
        return newObject;
    }
}