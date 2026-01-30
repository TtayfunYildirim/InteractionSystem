using UnityEngine;

namespace InteractionSystem.Runtime.Player
{
    /// Very basic Player movement. The purpose is to create a smooth 3D player movement for the setup. 
    /// Side Note: Not enough testing so could cause problems with the interactable objects or collisions that are required for the job.
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        #region Fields

        [Header("Movement Settings")]
        [SerializeField] private float m_MoveSpeed = 5f;
        [SerializeField] private float m_Gravity = -9.81f;

        [Header("Look Settings")]
        [SerializeField] private float m_LookSensitivity = 2f;
        [SerializeField] private float m_MaxLookAngle = 85f;
        [SerializeField] private Transform m_CameraTransform;

        
        private CharacterController m_CharacterController;
        private Vector3 m_Velocity;
        private float m_VerticalRotation;

        #endregion

        #region Unity Methods

        private void Awake()
        {
            // Error throw if there is a reference missing.
            m_CharacterController = GetComponent<CharacterController>();
            if (m_CharacterController == null)
            {
                Debug.LogError("PlayerController: CharacterController component missing!");
            }

            if (m_CameraTransform == null)
            {
                Debug.LogError("PlayerController: Camera Transform is not assigned in Inspector!");
            }
        }

        private void Start()
        {
            // Mouse locking mechanic. Needed for testing otherwise it gets annoying to check if sensitivity is correct or not.
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            if (m_CharacterController == null) return;

            HandleMovement();
            HandleLook();
        }

        #endregion

        #region Methods


        /// Very basic movement.
        private void HandleMovement()
        {
            // Movement Input system. I don't know if this is the best way to do it but this method proves to be usefull.
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            Vector3 move = transform.right * moveX + transform.forward * moveZ;

            // This is for creating smooth movement as if the character transitions from A position to B position like sliding.
            m_CharacterController.Move(move * m_MoveSpeed * Time.deltaTime);

            // Standart gravity calculation.
            if (m_CharacterController.isGrounded && m_Velocity.y < 0)
            {
                m_Velocity.y = -2f;
            }

            m_Velocity.y += m_Gravity * Time.deltaTime;
            m_CharacterController.Move(m_Velocity * Time.deltaTime);
        }

        /// Mouse movement.
        private void HandleLook()
        {
            if (m_CameraTransform == null) return;

            float mouseX = Input.GetAxis("Mouse X") * m_LookSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * m_LookSensitivity;

            // Mouse moevement again but for vertical this time.
            m_VerticalRotation -= mouseY;
            m_VerticalRotation = Mathf.Clamp(m_VerticalRotation, -m_MaxLookAngle, m_MaxLookAngle);

            m_CameraTransform.localRotation = Quaternion.Euler(m_VerticalRotation, 0f, 0f);

            // This is for rotating the players body while looking left and right. It doesnt show much on a capsule model.
            transform.Rotate(Vector3.up * mouseX);
        }

        #endregion
    }
}