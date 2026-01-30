namespace InteractionSystem.Runtime.Core
{
    /// This is for the creation of different types of interactions.
    public enum InteractionType
    {
        Instant, // Instant feedback (Ex: Like collecting keys from the ground)
        Hold,    // This is for asking the player for a confirmation by holding the interaction key (Ex: Opening a chest)
        Toggle   // And this is for the on/off types of interactions (Ex: doors or lights)
    }
}