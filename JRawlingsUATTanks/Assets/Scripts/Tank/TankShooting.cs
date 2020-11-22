using UnityEngine;
using UnityEngine.UI;

namespace Complete
{
    public class TankShooting : MonoBehaviour
    {
        public int m_PlayerNumber = 1;              // Indentify player
        public Rigidbody m_Shell;                   // Prefab of the shell.
        public Transform m_FireTransform;           // Where the shell spawns.
        public Slider m_AimSlider;                  // Current launch force.
        public AudioSource m_ShootingAudio;         // Reference to firing audio.
        public AudioClip m_ChargingClip;            // Charging audio.
        public AudioClip m_FireClip;                // Audio for shot.
        public float m_MinLaunchForce = 15f;        // Force given to shell minimum.
        public float m_MaxLaunchForce = 30f;        // Maximum force to shell.
        public float m_MaxChargeTime = 0.75f;       // Time for max shell firing.


        private string m_FireButton;                // Firing button.
        private float m_CurrentLaunchForce;         // Current force for how long you push the firing button.
        private float m_ChargeSpeed;                // Max charge time.
        private bool m_Fired;                       // Button press trigger.


        private void OnEnable()
        {
            // Reset launch force.
            m_CurrentLaunchForce = m_MinLaunchForce;
            m_AimSlider.value = m_MinLaunchForce;
        }


        private void Start ()
        {
            // Fire axis from character.
            m_FireButton = "Fire" + m_PlayerNumber;

            // rate of speed algorythm.
            m_ChargeSpeed = (m_MaxLaunchForce - m_MinLaunchForce) / m_MaxChargeTime;
        }


        private void Update ()
        {
            // Slider. May add later.
            m_AimSlider.value = m_MinLaunchForce;

            // Max force
            if (m_CurrentLaunchForce >= m_MaxLaunchForce && !m_Fired)
            {
                // firing.
                m_CurrentLaunchForce = m_MaxLaunchForce;
                Fire ();
            }
            // Starting fire.
            else if (Input.GetButtonDown (m_FireButton))
            {
                // reset force.
                m_Fired = false;
                m_CurrentLaunchForce = m_MinLaunchForce;

                // Clip charging.
                m_ShootingAudio.clip = m_ChargingClip;
                m_ShootingAudio.Play ();
            }
            
            else if (Input.GetButton (m_FireButton) && !m_Fired)
            {
                
                m_CurrentLaunchForce += m_ChargeSpeed * Time.deltaTime;

                m_AimSlider.value = m_CurrentLaunchForce;
            }
            // If the fire button is released and the shell hasn't been launched yet...
            else if (Input.GetButtonUp (m_FireButton) && !m_Fired)
            {
                // ... launch the shell.
                Fire ();
            }
        }


        private void Fire ()
        {
            // Limit flag for firing.
            m_Fired = true;

            // Create shell and give it a rigidbody.
            Rigidbody shellInstance =
                Instantiate (m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;

            // Set Shell velocity.
            shellInstance.velocity = m_CurrentLaunchForce * m_FireTransform.forward; 

            // Change the clip to the firing clip and play it.
            m_ShootingAudio.clip = m_FireClip;
            m_ShootingAudio.Play ();

            // Reset the launch force.
            m_CurrentLaunchForce = m_MinLaunchForce;
        }
    }
}