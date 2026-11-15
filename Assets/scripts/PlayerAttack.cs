using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private float meleeSpeed;
    [SerializeField] private float damage;

    float timeUntilMelee;
    private void Update()
    {
        bool isAttacking = anim.GetCurrentAnimatorStateInfo(0)
    .IsName("Base Layer.PlayerAttack");

        if (!isAttacking)
        {
            Vector3 cursor = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            Vector2 direction = (Vector2)(cursor - anim.transform.position);
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            anim.transform.rotation = Quaternion.Euler(0f, 0f, angle - 45);
        }
        if (timeUntilMelee <=0f)
        {
            if(Mouse.current?.leftButton.wasPressedThisFrame == true)
            {
                anim.SetTrigger("Attack");
                timeUntilMelee = meleeSpeed;
            }
        }
        else
        {
            timeUntilMelee -= Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
            Debug.Log("Enemy Hit");
        }
    }
}
