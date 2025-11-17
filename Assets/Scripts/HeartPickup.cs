using UnityEngine;

public class HeartPickup : MonoBehaviour
{
    [SerializeField] float healAmount = 1f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStats.Instance.Heal(healAmount);
            DestroyOnTrigger2D trigger = other.GetComponent<DestroyOnTrigger2D>();
            trigger.Health++;
            Debug.Log("Lives amount: " + trigger.Health);
            Destroy(gameObject);
        }
    }
}
