using UnityEngine;
using InteractionSystem.Runtime.Core;

namespace InteractionSystem.Runtime.Interactables
{
    public class Chest : MonoBehaviour, IInteractable
    {
        #region Fields

        [Header("Interaction Settings")]
        [SerializeField] private float m_UnlockTime = 2.0f;

        [Header("Animation Settings")]
        [SerializeField] private Transform m_LidMesh; 
        [SerializeField] private float m_OpenAngle = -90f; 
        [SerializeField] private float m_AnimationSpeed = 2f; 

        // Interface Properties
        public string InteractionPrompt => m_IsOpen ? "The chest is already opened!" : "Hold E to Open Chest";
        public InteractionType Type => InteractionType.Hold;
        public float HoldDuration => m_UnlockTime;

        // Private State
        private bool m_IsOpen = false;
        private Quaternion m_ClosedRotation;
        private Quaternion m_TargetRotation;

        #endregion

        #region Unity Methods

        private void Start()
        {
            // Save the starting rotation.
            if (m_LidMesh != null)
            {
                m_ClosedRotation = m_LidMesh.localRotation;
                m_TargetRotation = Quaternion.Euler(m_OpenAngle, 0, 0) * m_ClosedRotation;
            }
            else
            {
                Debug.LogError("Chest: Lid Mesh is not assigned in Inspector!");
            }
        }

        private void Update()
        {
            if (m_IsOpen && m_LidMesh != null)
            {
                m_LidMesh.localRotation = Quaternion.Slerp(
                    m_LidMesh.localRotation,
                    m_TargetRotation,
                    Time.deltaTime * m_AnimationSpeed
                );
            }
        }

        #endregion

        #region Methods

        public bool Interact(GameObject interactor)
        {
            if (m_IsOpen) return false;

            m_IsOpen = true;
            Debug.Log("Chest Opened! Loot given.");

            // Can add a sound effect

            return true;
        }

        #endregion
    }
}