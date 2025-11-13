using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public float travelDistance;
    private Vector3 startPoint, endPoint;
    private bool movingRight = true;

    private void Start()
    {
        startPoint = transform.position;
        endPoint = new Vector3(transform.position.x + travelDistance, transform.position.y, transform.position.z);
    }

    void Update()
    {

        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (transform.position.x >= endPoint.x) movingRight = false;
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            if (transform.position.x <= startPoint.x) movingRight = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();

            // Check if the player is falling down when colliding
            if (playerRb.linearVelocity.y < 0)
            {
                // Bounce the player up a little
                //playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x, 8f);

                // Destroy this enemy
                //Destroy(gameObject);
            }
            else
            {
                // Player hit from the side or bottom — take damage instead
                collision.gameObject.GetComponent<Health>().TakeDamage(1);
            }
        }
    }

}
