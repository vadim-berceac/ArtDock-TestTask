[System.Serializable]
public abstract class AbilityComponent
{
    public abstract void StartExecute(CharacterComponentsContainer container);
    public abstract void FinishExecute(CharacterComponentsContainer container);
}
