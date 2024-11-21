using UnityEngine;

[System.Serializable]
public class PlaySoundComponent : AbilityComponent
{
    private AudioClip _soundClip;

    public PlaySoundComponent(AudioClip soundClip)
    {
        _soundClip = soundClip;
    }

    public override void StartExecute(CharacterComponentsContainer container)
    {
        if (container.AudioSource == null)
        {
            return;
        }
        
        container.AudioSource.PlayOneShot(_soundClip);
    }
    
    public override void FinishExecute(CharacterComponentsContainer container)
    {
        container.AudioSource.Stop();
    }
}
