using TMPro;
using UnityEngine;

public class HealthManager : MonoBehaviour 
{
    [SerializeField] public float health;
    [SerializeField] private ParticleSystem playerParticleSystem;
    [SerializeField] private ParticleSystem player2ParticleSystem;
    [SerializeField] TextMeshProUGUI hpText;

    
    public void TakeDMG(int value)
    {
        health -= value;
        hpText.text = "HP: " + health;
        if (health <= 0)
        {
            playerParticleSystem.transform.position = this.transform.position;
            player2ParticleSystem.transform.position = this.transform.position;
            playerParticleSystem.transform.parent = null;
            player2ParticleSystem.transform.parent = null;
            playerParticleSystem.Play();
            player2ParticleSystem.Play();
            Destroy(this.gameObject);
            Object.FindFirstObjectByType<GameManager>().TriggerGameOVer();
            Debug.Log("Player died!");
        }
    }
}
