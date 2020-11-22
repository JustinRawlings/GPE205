using UnityEngine;

namespace Complete
{
    public class TankMovement : MonoBehaviour
    {
        public int m_PlayerNumber = 1;              // Player Number
        public float m_Speed = 12f;                 // Tank Speed
        public float m_TurnSpeed = 180f;            // Turn Speed
        public AudioSource m_MovementAudio;         // Audio Source
        public AudioClip m_EngineIdling;            // Not Moving Audio
        public AudioClip m_EngineDriving;           // Tank Moving Audio
		public float m_PitchRange = 0.2f;           // Engine Noise Pitch

        private string m_MovementAxisName;          // Input
        private string m_TurnAxisName;              // Axis input
        private Rigidbody m_Rigidbody;              // Rank Movement Reference
        private float m_MovementInputValue;         // Movement input value
        private float m_TurnInputValue;             // Turn input value
        private float m_OriginalPitch;              // Audio Pitch
        private ParticleSystem[] m_particleSystems; // Particles

        private void Awake ()
        {
            m_Rigidbody = GetComponent<Rigidbody> ();
        }


        private void OnEnable ()
        {
            // Tank is not kinematic
            m_Rigidbody.isKinematic = false;

            // Reset input values.
            m_MovementInputValue = 0f;
            m_TurnInputValue = 0f;

            
            
            m_particleSystems = GetComponentsInChildren<ParticleSystem>();
            for (int i = 0; i < m_particleSystems.Length; ++i)
            {
                m_particleSystems[i].Play();
            }
        }


        private void OnDisable ()
        {
            // When the tank is turned off, set it to kinematic.
            m_Rigidbody.isKinematic = true;

            // Stop all particle system
            for(int i = 0; i < m_particleSystems.Length; ++i)
            {
                m_particleSystems[i].Stop();
            }
        }


        private void Start ()
        {
            // The axes names are based on player number.
            m_MovementAxisName = "Vertical" + m_PlayerNumber;
            m_TurnAxisName = "Horizontal" + m_PlayerNumber;

            // Store the original pitch of the audio source.
            m_OriginalPitch = m_MovementAudio.pitch;
        }


        private void Update ()
        {
            // Store the value of both input axes.
            m_MovementInputValue = Input.GetAxis (m_MovementAxisName);
            m_TurnInputValue = Input.GetAxis (m_TurnAxisName);

            EngineAudio ();
        }


        private void EngineAudio ()
        {
            // No sound when off.
            if (Mathf.Abs (m_MovementInputValue) < 0.1f && Mathf.Abs (m_TurnInputValue) < 0.1f)
            {
                // ... Play audio when moving
                if (m_MovementAudio.clip == m_EngineDriving)
                {
                    // ... idling audio clip.
                    m_MovementAudio.clip = m_EngineIdling;
                    m_MovementAudio.pitch = Random.Range (m_OriginalPitch - m_PitchRange, m_OriginalPitch + m_PitchRange);
                    m_MovementAudio.Play ();
                }
            }
            else
            {
                // CHange audio to driving if moving.
                if (m_MovementAudio.clip == m_EngineIdling)
                {
                    
                    m_MovementAudio.clip = m_EngineDriving;
                    m_MovementAudio.pitch = Random.Range(m_OriginalPitch - m_PitchRange, m_OriginalPitch + m_PitchRange);
                    m_MovementAudio.Play();
                }
            }
        }


        private void FixedUpdate ()
        {
            // Change rigidbodies position
            Move ();
            Turn ();
        }


        private void Move ()
        {
            // Vector in the direction the tank is facing.
            Vector3 movement = transform.forward * m_MovementInputValue * m_Speed * Time.deltaTime;

            // Apply movement to rigidbody's position.
            m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
        }


        private void Turn ()
        {
            // Tunring direction and speed.
            float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;

            // Rotation in Y axis.
            Quaternion turnRotation = Quaternion.Euler (0f, turn, 0f);

            // Apply rotation to the rigidbody
            m_Rigidbody.MoveRotation (m_Rigidbody.rotation * turnRotation);
        }
    }
}