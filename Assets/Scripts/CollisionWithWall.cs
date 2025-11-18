using UnityEngine;

public class CollisionWithWall : MonoBehaviour
{
    private float UpperBoundary = 3.8f;
    private float bottomBoundary = -3.9f;
    private float rightBoundary = 9f;
    private float leftBoundary = -9f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("UpperWall"))
        {
            Debug.Log("Collision with wall");
            transform.position = new Vector3(transform.position.x, UpperBoundary, 0);
        }
        else if (other.gameObject.CompareTag("BottomWall"))
        {
            Debug.Log("Collision with wall");
            transform.position = new Vector3(transform.position.x, bottomBoundary, 0);
        }
        else if (other.gameObject.CompareTag("LeftWall"))
        {
            Debug.Log("Collision with wall");
            transform.position = new Vector3(rightBoundary - 1.5f, transform.position.y, 0);
        }
        else if (other.gameObject.CompareTag("RightWall"))
        {
            Debug.Log("Collision with wall");
            transform.position = new Vector3(leftBoundary + 1.5f, transform.position.y, 0);
        }
    }



}
