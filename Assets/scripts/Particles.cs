using UnityEngine;

public class Particles : MonoBehaviour 
{
    [SerializeField] private ParticleSystem particleSystem;

    private void Update()
    { 
        particleSystem.Play();
    }
}
