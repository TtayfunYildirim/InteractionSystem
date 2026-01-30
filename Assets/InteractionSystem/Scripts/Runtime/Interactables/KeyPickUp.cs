using UnityEngine;
using InteractionSystem.Runtime.Core;
using InteractionSystem.Runtime.Player;

namespace InteractionSystem.Runtime.Interactables
{
    public class KeyPickup : MonoBehaviour, IInteractable
    {
        [SerializeField] private KeyData m_KeyData;

        public string InteractionPrompt => $"Pick up {m_KeyData.KeyName}";
        public InteractionType Type => InteractionType.Instant;
        public float HoldDuration => 0f;

        public bool Interact(GameObject interactor)
        {
            var inventory = interactor.GetComponentInParent<PlayerInventory>();
            if (inventory != null)
            {
                inventory.AddKey(m_KeyData);
                Destroy(gameObject); 
                return true;
            }
            return false;
        }
    }
}