using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private ParticleSystem enemyParticleSystem;
    [SerializeField] private ParticleSystem enemy2ParticleSystem;
    [SerializeField] private ParticleSystem playerParticleSystem;
    [SerializeField] private ParticleSystem player2ParticleSystem;

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
            playerParticleSystem.transform.position = this.transform.position;
            player2ParticleSystem.transform.position = this.transform.position;
            playerParticleSystem.transform.parent = null;
            player2ParticleSystem.transform.parent = null;
            playerParticleSystem.Play();
            player2ParticleSystem.Play();
            Object.FindFirstObjectByType<GameManager>().TriggerGameOVer();
            Debug.Log("Player died!");
            Destroy(collision.gameObject);
        }
    }
    public void AddSpawnHealth(float bonus)
    {
        health += bonus;
    }
    public void TakeDamage(float damage)

    {
        health -= damage;

        if (health <= 0f)
        {
            expSystem.AddEXP(10);
            enemyParticleSystem.transform.position = this.transform.position;
            enemy2ParticleSystem.transform.position = this.transform.position;
            enemyParticleSystem.transform.parent = null;
            enemy2ParticleSystem.transform.parent = null;
            enemyParticleSystem.Play();
            enemy2ParticleSystem.Play();
            Destroy(gameObject);
            Debug.Log("Enemy Died!");
        }
    }
}
