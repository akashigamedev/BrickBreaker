using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D rb;
    Vector2 initialPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPosition = new Vector2(transform.position.x, transform.position.y);
    }

    void FixedUpdate()
    {

        rb.velocity = rb.velocity.normalized * speed;
    }

    public void StartGame(int seconds)
    {
        StartCoroutine(LaunchBallAfterSeconds(seconds));
    }

    IEnumerator LaunchBallAfterSeconds(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        rb.velocity = -transform.up * speed;
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        // get initial point to ball distance and direction vector
        Vector2 initialToBallDist = new Vector2(transform.position.x - initialPosition.x, transform.position.y - initialPosition.y);
        Vector2 ballDir = initialToBallDist.normalized;

        // Hack for a bug where ball gets stuck in space because its dir is (0, 0)
        if (ballDir == Vector2.zero)
        {
            rb.velocity = new Vector2(1f, 1f);
            return;
        }
        // Hack end

        Vector2 reflectedVector = Vector2.Reflect(ballDir, collision.contacts[0].normal);
        float angle = Vector2.Angle(ballDir, reflectedVector.normalized);

        if (angle >= 145)
        {
            // ball is almost stuck in horizontal/vertical loop so we apply offset
            Vector2 offsetVector = new Vector2(Random.Range(0.2f, 0.6f), Random.Range(0.2f, 0.6f));
            if (ballDir.y > 0)
                rb.velocity = reflectedVector.normalized + offsetVector;
            else if (ballDir.y < 0)
                rb.velocity = reflectedVector.normalized - offsetVector;
            else
                rb.velocity = new Vector2(1f, 1f);
        }
        else
        {
            // ball normal bounce
            rb.velocity = reflectedVector.normalized;
        }

        initialPosition = new Vector2(transform.position.x, transform.position.y);
    }
}
