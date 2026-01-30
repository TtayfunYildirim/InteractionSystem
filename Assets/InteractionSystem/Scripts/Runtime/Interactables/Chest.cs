using UnityEngine;
using InteractionSystem.Runtime.Core;

namespace InteractionSystem.Runtime.Interactables
{
    public class Chest : MonoBehaviour, IInteractable
    {
        [SerializeField] private float m_UnlockTime = 2.0f;

        public string InteractionPrompt => m_IsOpen ? "Empty" : "Hold E to Open Chest";
        public InteractionType Type => InteractionType.Hold;
        public float HoldDuration => m_UnlockTime;

        private bool m_IsOpen = false;

        public bool Interact(GameObject interactor)
        {
            if (m_IsOpen) return false;

            m_IsOpen = true;
            Debug.Log("Chest Opened! Loot given.");
            // Can add a chest opening animation here.
            return true;
        }
    }
}