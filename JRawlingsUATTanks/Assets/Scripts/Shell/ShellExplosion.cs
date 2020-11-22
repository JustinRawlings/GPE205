using UnityEngine;

namespace Complete
{
    public class ShellExplosion : MonoBehaviour
    {
        public LayerMask m_TankMask;                        // Filter explosion effects
        public ParticleSystem m_ExplosionParticles;         // Particles on explosion
        public AudioSource m_ExplosionAudio;                // Audio on explosion
        public float m_MaxDamage = 100f;                    // damage done on explosion
        public float m_ExplosionForce = 1000f;              // force added on explosion
        public float m_MaxLifeTime = 2f;                    //shell removed time
        public float m_ExplosionRadius = 5f;                // Max shell distance


        private void Start ()
        {
            // If did not hit, destroy shell.
            Destroy (gameObject, m_MaxLifeTime);
        }


        private void OnTriggerEnter (Collider other)
        {
			// Explosion radius
            Collider[] colliders = Physics.OverlapSphere (transform.position, m_ExplosionRadius, m_TankMask);

            // Look through collider...
            for (int i = 0; i < colliders.Length; i++)
            {
                //  find rigidbody.
                Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody> ();

                // If no rigidbody, go through it.
                if (!targetRigidbody)
                    continue;

                // Add force
                targetRigidbody.AddExplosionForce (m_ExplosionForce, transform.position, m_ExplosionRadius);

                // Tank Health
                TankHealth targetHealth = targetRigidbody.GetComponent<TankHealth> ();

                // If no health, then go to next rigidbody
                if (!targetHealth)
                    continue;

                // Calculate damage
                float damage = CalculateDamage (targetRigidbody.position);

                // Deal damage
                targetHealth.TakeDamage (damage);
            }

            // Unparent damage.
            m_ExplosionParticles.transform.parent = null;

            // Play particles
            m_ExplosionParticles.Play();

            // Play explosion sound.
            m_ExplosionAudio.Play();

            // Destroy shell particles.
            ParticleSystem.MainModule mainModule = m_ExplosionParticles.main;
            Destroy (m_ExplosionParticles.gameObject, mainModule.duration);

            // Destroy shell.
            Destroy (gameObject);
        }


        private float CalculateDamage (Vector3 targetPosition)
        {
            // Create a vector from the shell to the target.
            Vector3 explosionToTarget = targetPosition - transform.position;

            // Calculate the distance from the shell to the target.
            float explosionDistance = explosionToTarget.magnitude;

            // Calculate the proportion of the maximum distance (the explosionRadius) the target is away.
            float relativeDistance = (m_ExplosionRadius - explosionDistance) / m_ExplosionRadius;

            // Calculate damage as this proportion of the maximum possible damage.
            float damage = relativeDistance * m_MaxDamage;

            // Make sure that the minimum damage is always 0.
            damage = Mathf.Max (0f, damage);

            return damage;
        }
    }
}