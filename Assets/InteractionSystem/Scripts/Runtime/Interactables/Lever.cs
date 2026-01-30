using UnityEngine;
using InteractionSystem.Runtime.Core;
using InteractionSystem.Runtime.Interactables;

namespace InteractionSystem.Runtime.Interactables
{
    public class Lever : MonoBehaviour, IInteractable
    {
        #region Fields

        [Header("Target")]
        [SerializeField] private Door m_TargetDoor; 

        [Header("Visuals")]
        [SerializeField] private Transform m_HandleMesh; 
        [SerializeField] private float m_PullAngle = 45f;
        [SerializeField] private float m_Speed = 3f;


        public string InteractionPrompt => m_IsPulled ? "Already Used" : "Pull Lever";
        public InteractionType Type => InteractionType.Instant; 
        public float HoldDuration => 0f;

        private bool m_IsPulled = false;
        private Quaternion m_PulledRotation;

        #endregion

        #region Unity Methods

        private void Update()
        {
            if (m_IsPulled)
            {
                m_HandleMesh.localRotation = Quaternion.Slerp(m_HandleMesh.localRotation, m_PulledRotation, Time.deltaTime * m_Speed);
            }
        }

        #endregion

        #region Methods

        public bool Interact(GameObject interactor)
        {
           
            if (m_IsPulled) return false;

            


            if (m_HandleMesh != null)
            {

                m_PulledRotation = Quaternion.Euler(m_PullAngle, 0, 0);

                m_IsPulled = true;
            }


            if (m_TargetDoor != null)
            {
                Debug.Log("Lever pulled! Opening door remotely...");
                m_TargetDoor.Open(); 
            }
            else
            {
                Debug.LogError("Lever: Target Door is missing!");
            }


            GetComponent<Collider>().enabled = false;

            return true;
        }

        #endregion
    }
}