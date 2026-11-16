using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float moveSpeed = 2f;

    private Transform player;
    private Rigidbody2D body;
    private EXPsystem expSystem;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player")?.transform;
        expSystem = FindAnyObjectByType<EXPsystem>();
    }

    private void FixedUpdate()
    {
        if (player == null)
            return;

        Vector2 nextPosition = Vector2.MoveTowards(
            body.position, player.position, moveSpeed * Time.fixedDeltaTime);

        body.MovePosition(nextPosition);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Object.FindFirstObjectByType<GameManager>().TriggerGameOVer();
            Debug.Log("Player died!");
            Destroy(collision.gameObject);
        }
    }
    public void TakeDamage(float damage)

    {
        health -= damage;

        if (health <= 0f)
        {
            expSystem.AddEXP(10);
            Destroy(gameObject);
            Debug.Log("Enemy Died!");
        }
    }
}
