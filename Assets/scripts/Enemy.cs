using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float moveSpeed = 2f;

    private Transform player;
    private Rigidbody2D body;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player")?.transform;
    }

    private void FixedUpdate()
    {
        if (player == null)
            return;

        Vector2 nextPosition = Vector2.MoveTowards(
            body.position, player.position, moveSpeed * Time.fixedDeltaTime);

        body.MovePosition(nextPosition);
    }
    public void TakeDamage(float damage)

    {
        health -= damage;

        if (health <= 0f)
        {
            Destroy(gameObject);
            Debug.Log("Enemy Died!");

        }
    }
}
