using Unity.Cinemachine;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] float ShakeModifier = 10f;
   CinemachineImpulseSource impulseSource;
   [SerializeField] ParticleSystem rockParticle;
   [SerializeField] AudioSource rockAudio;
   [SerializeField] float ShakeCooldown = 1f;
   float CollisionTimer;

    void Awake()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }

       void Update()
    {
        CollisionTimer += Time.deltaTime;
    }
    void OnCollisionEnter(Collision collision)
    {
        if(CollisionTimer < ShakeCooldown) return;
        FireImpulse();
        CollisionFX(collision);
        CollisionTimer = 0f;
    }

    private void FireImpulse()
    {
        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        float ShakeIntensity = Mathf.Min(1 / distance, 1f) * ShakeModifier;
        impulseSource.GenerateImpulse(ShakeIntensity);
    }

    void CollisionFX( Collision other)
    {
        ContactPoint contactPoint = other.contacts[0];
        rockParticle.transform.position = contactPoint.point;
        rockParticle.Play();
        rockAudio.Play();
        
    }
}
