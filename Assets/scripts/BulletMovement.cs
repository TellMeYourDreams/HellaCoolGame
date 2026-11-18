
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    private Vector2 direction;
    private HealthManager healthManager;

    public float speed;
    [SerializeField] int life = 3;  
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        direction = (player.transform.position - transform.position).normalized;
        rb.linearVelocity = direction * speed;
        healthManager = FindAnyObjectByType<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || life <= 0)
        {
            healthManager.TakeDMG(20);
            Destroy(gameObject);
        }
        else
        {
            life--;
            var firstContact = collision.contacts[0];
            direction = Vector2.Reflect(direction, firstContact.normal).normalized;

            rb.linearVelocity = direction * speed;
        }
    }
}
