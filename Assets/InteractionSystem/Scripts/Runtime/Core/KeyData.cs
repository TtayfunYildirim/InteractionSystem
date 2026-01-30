using UnityEngine;

namespace InteractionSystem.Runtime.Core
{
    /// This is for identifying the different types of keys. This is done in order to make it ready for different types of doors or keys that could exist.
    [CreateAssetMenu(fileName = "NewKeyData", menuName = "InteractionSystem/Key Data")]
    public class KeyData : ScriptableObject
    {
        public string KeyName;
        public string KeyId; // Unique ID (Ex: "RedKey") 
    }
}