using UnityEngine;

namespace InteractionSystem.Runtime.Core
{
    /// An Interface script for the interactable objects.
    public interface IInteractable
    {
        /// This is for the text interface.
        string InteractionPrompt { get; }

        /// Interaction type. (Hold, Instant or Toggle)
        InteractionType Type { get; }

        /// The amount of time required for the Hold type interaction.
        float HoldDuration { get; }

        /// This will be called when the interaction happened.
        bool Interact(GameObject interactor);
    }
}