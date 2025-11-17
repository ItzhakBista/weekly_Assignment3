using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoNextLevel : MonoBehaviour {
    [SerializeField] string triggeringTag;
    [SerializeField] [Tooltip("Name of scene to move to when triggering the given tag")] string sceneName;
    //[SerializeField] NumberField scoreField;

    private void OnTriggerEnter2D(Collider2D other) {
        DestroyOnTrigger2D trigger = GetComponent<DestroyOnTrigger2D>();
        if (other.tag == triggeringTag && trigger.Health <= 0) {
            Debug.Log("Moving " + this + " to zero");
            this.transform.position = Vector3.zero;
            SceneManager.LoadScene(sceneName);    // Input can either be a serial number or a name; here we use name.
        }
    }
}
