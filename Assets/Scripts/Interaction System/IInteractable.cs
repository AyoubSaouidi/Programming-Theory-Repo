public interface IInteractable
{
    // Properties
    bool IsInteractable { get; }

    // Methods
    void Interact();
    void OnInteract(); // ABSTRACTION
}
