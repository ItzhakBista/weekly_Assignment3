using UnityEngine;

public class MovingBackGround : MonoBehaviour
{
    public float speed = 1f;
    public float resetY = -20f;
    public float startY = 20f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < resetY)
        {
            transform.position = new Vector3(transform.position.x, startY, transform.position.z);
        }
    }
}
