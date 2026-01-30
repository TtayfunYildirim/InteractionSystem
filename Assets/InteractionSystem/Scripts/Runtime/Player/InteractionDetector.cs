using UnityEngine;
using InteractionSystem.Runtime.Core;
using InteractionSystem.Runtime.UI;

namespace InteractionSystem.Runtime.Player
{
    /// This part uses raycasts to detect the interactable objects.
    public class InteractionDetector : MonoBehaviour
    {
        #region Fields

        [Header("Detection Settings")]
        [SerializeField] private float m_InteractionRange = 3f;
        [SerializeField] private LayerMask m_InteractableLayer;

        [Header("UI References")]
        [SerializeField] private InteractionPromptUI m_PromptUI;

        private Camera m_Camera;
        private IInteractable m_CurrentInteractable;
        private float m_HoldTimer;
        private bool m_IsHolding;

        #endregion

        #region Unity Methods

        private void Awake()
        {
            m_Camera = GetComponent<Camera>();
            if (m_Camera == null) Debug.LogError("No camera component!");
        }

        private void Update()
        {
            DetectInteractable();
            HandleInput();
        }

        #endregion

        #region Methods

        private void DetectInteractable()
        {
            Ray ray = new Ray(m_Camera.transform.position, m_Camera.transform.forward);

            if (Physics.Raycast(ray, out RaycastHit hit, m_InteractionRange, m_InteractableLayer))
            {
                // Checks if the script "IInteractable" is inside the object in order to not create problems with other types of collisions
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();

                if (interactable != null)
                {
                    // Checks and runs if this is a new interactable object so that we can only show the text once.
                    if (m_CurrentInteractable != interactable)
                    {
                        m_CurrentInteractable = interactable;
                        m_PromptUI?.Show(m_CurrentInteractable.InteractionPrompt);
                    }
                    return;
                }
            }

            // Dont show the text if there is nothing to see or if the player is far away from the object.
            if (m_CurrentInteractable != null)
            {
                m_CurrentInteractable = null;
                m_PromptUI?.Hide();
                ResetHold();
            }
        }

        private void HandleInput()
        {
            if (m_CurrentInteractable == null) return;

            // This part only for the instant and toggle types because we dont have to worry about progress bar here.
            if (m_CurrentInteractable.Type != InteractionType.Hold)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    m_CurrentInteractable.Interact(gameObject); 
                }
            }
            // And this is for the Hold type.
            else
            {
                if (Input.GetKey(KeyCode.E))
                {
                    m_IsHolding = true;
                    m_HoldTimer += Time.deltaTime;

                    // Updating the progress bar for visual feedback to the player.
                    float progress = m_HoldTimer / m_CurrentInteractable.HoldDuration;
                    m_PromptUI?.UpdateProgress(progress);

                    // Checks if the progress done so that interaction can be completed.
                    if (m_HoldTimer >= m_CurrentInteractable.HoldDuration)
                    {
                        m_CurrentInteractable.Interact(gameObject);
                        ResetHold();
                    }
                }
                else if (Input.GetKeyUp(KeyCode.E))
                {
                    ResetHold();
                }
            }
        }

        private void ResetHold()
        {
            m_IsHolding = false;
            m_HoldTimer = 0f;
            m_PromptUI?.UpdateProgress(0f);
        }

        #endregion
    }
}