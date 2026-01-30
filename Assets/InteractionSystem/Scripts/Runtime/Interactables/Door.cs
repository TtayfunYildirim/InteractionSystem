using UnityEngine;
using InteractionSystem.Runtime.Core;
using InteractionSystem.Runtime.Player;

namespace InteractionSystem.Runtime.Interactables
{
    public class Door : MonoBehaviour, IInteractable
    {
        #region Fields

        [Header("Settings")]
        [SerializeField] private bool m_IsLocked = false;
        [SerializeField] private KeyData m_RequiredKey;

        [Header("Animation")]
        [SerializeField] private Transform m_DoorMesh; // This is the part that is gonna rotate when door is opened.
        [SerializeField] private float m_OpenAngle = 90f;
        [SerializeField] private float m_Speed = 2f;

        // IInteractable Implementation
        public string InteractionPrompt => m_IsLocked ? "Locked (Requires Key)" : (m_IsOpen ? "Close Door" : "Open Door");
        public InteractionType Type => InteractionType.Toggle;
        public float HoldDuration => 0f;

        private bool m_IsOpen = false;
        private Quaternion m_ClosedRotation;
        private Quaternion m_OpenRotation;

        #endregion

        #region Unity Methods

        private void Start()
        {
            if (m_DoorMesh != null)
            {
                m_ClosedRotation = m_DoorMesh.localRotation;
                m_OpenRotation = Quaternion.Euler(0, m_OpenAngle, 0); // Only turn at the Y axis.
            }
        }

        private void Update()
        {
            // Basic animation using lerp.
            if (m_DoorMesh != null)
            {
                Quaternion targetRot = m_IsOpen ? m_OpenRotation : m_ClosedRotation;
                m_DoorMesh.localRotation = Quaternion.Slerp(m_DoorMesh.localRotation, targetRot, Time.deltaTime * m_Speed);
            }
        }

        #endregion

        #region Methods

        public bool Interact(GameObject interactor)
        {
            if (m_IsLocked)
            {
                // Find the player inventory so that game can check if there is a key.
                var inventory = interactor.GetComponentInParent<PlayerInventory>();

                if (inventory != null && m_RequiredKey != null && inventory.HasKey(m_RequiredKey))
                {
                    m_IsLocked = false;
                    Debug.Log("Door unlocked!");
                    // When opened stay opened.
                    m_IsOpen = true;
                    return true;
                }
                else
                {
                    Debug.Log("Door is locked and you don't have the key.");
                    return false;
                }
            }

            m_IsOpen = !m_IsOpen;
            return true;
        }

        #endregion
    }
}