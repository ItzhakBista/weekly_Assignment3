using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/**
 * This component destroys its object whenever it triggers a 2D collider with the given tag.
 */
public class DestroyOnTrigger2D : MonoBehaviour {
    [Tooltip("Every object tagged with this tag will trigger the destruction of both objects")]
    [SerializeField] string triggeringTag;
    [SerializeField] public int Health = 0;
    public event System.Action onHit;  // "public event" means that other objects can just subscribe or unsubscribe, but not do other stuff with this public variable.

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == triggeringTag && enabled) {
            if (Health <= 0){
                Destroy(this.gameObject);
            }
            else
            {
                Health--;
            }
            Destroy(other.gameObject);
            onHit?.Invoke();
        }
    }


    private void Update() {
        /* Just to show the enabled checkbox in Editor */
    }
}
