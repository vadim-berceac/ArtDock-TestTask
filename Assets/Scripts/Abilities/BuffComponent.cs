using UnityEngine;

public class BuffComponent : AbilityComponent
{
    private int _increaseStrength;
    private int _increaseAgility;
    private int _increaseDefence;

    public BuffComponent(int increaseStrength, int increaseAgility, int increaseDefence)
    {
        _increaseStrength = increaseStrength;
        _increaseAgility = increaseAgility;
        _increaseDefence = increaseDefence;
    }

    public override void StartExecute(CharacterComponentsContainer container)
    {
        
    }

    public override void FinishExecute(CharacterComponentsContainer container)
    {
        
    }
}
