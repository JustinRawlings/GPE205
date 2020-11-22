using UnityEngine;
using UnityEngine.UI;

namespace Complete
{
    public class TankHealth : MonoBehaviour
    {
        public float m_StartingHealth = 100f;               // Starting Health
        public Slider m_Slider;                             // Slider shows how much health is left.
        public Image m_FillImage;                           // Slider Image
        public Color m_FullHealthColor = Color.green;       // Full Health
        public Color m_ZeroHealthColor = Color.red;         // No Health
        public GameObject m_ExplosionPrefab;                // Tank Death
        
        
        private AudioSource m_ExplosionAudio;               // Tank explosion audio.
        private ParticleSystem m_ExplosionParticles;        // Tank destroyed particles.
        private float m_CurrentHealth;                      // Current tank health.
        private bool m_Dead;                                // Dead.


        private void Awake ()
        {
            // Instantiate the explosion prefab.
            m_ExplosionParticles = Instantiate (m_ExplosionPrefab).GetComponent<ParticleSystem> ();

            // Reference of explosion
            m_ExplosionAudio = m_ExplosionParticles.GetComponent<AudioSource> ();

            // Disable the prefab for use when activated.
            m_ExplosionParticles.gameObject.SetActive (false);
        }


        private void OnEnable()
        {
            // Finds out if the tank is alive or dead.
            m_CurrentHealth = m_StartingHealth;
            m_Dead = false;

            // Update the health slider
            SetHealthUI();
        }


        public void TakeDamage (float amount)
        {
            // Reduce health
            m_CurrentHealth -= amount;

            // Show health on UI
            SetHealthUI ();

            // If dead, show death scene.
            if (m_CurrentHealth <= 0f && !m_Dead)
            {
                OnDeath ();
            }
        }


        private void SetHealthUI ()
        {
            // Health slider for current health.
            m_Slider.value = m_CurrentHealth;

            // Show how much health is left on the bar.
            m_FillImage.color = Color.Lerp (m_ZeroHealthColor, m_FullHealthColor, m_CurrentHealth / m_StartingHealth);
        }


        private void OnDeath ()
        {
            // Set to only show once.
            m_Dead = true;

            // Move the tank position to active on death.
            m_ExplosionParticles.transform.position = transform.position;
            m_ExplosionParticles.gameObject.SetActive (true);

            // Play particle on explosion.
            m_ExplosionParticles.Play ();

            // Play tank explosion sound.
            m_ExplosionAudio.Play();

            // Turn off tank.
            gameObject.SetActive (false);
        }
    }
}