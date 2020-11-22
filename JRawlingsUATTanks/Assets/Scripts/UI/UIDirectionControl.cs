using UnityEngine;

namespace Complete
{
    public class UIDirectionControl : MonoBehaviour
    {
        // Makes world space UI elements
       

        public bool m_UseRelativeRotation = true;       // Use rotation relative to the tank.


        private Quaternion m_RelativeRotation;          // Rotation and begininning of scene.


        private void Start ()
        {
            m_RelativeRotation = transform.parent.localRotation;
        }


        private void Update ()
        {
            if (m_UseRelativeRotation)
                transform.rotation = m_RelativeRotation;
        }
    }
}