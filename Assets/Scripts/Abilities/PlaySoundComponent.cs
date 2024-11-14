using UnityEngine;

[System.Serializable]
public class PlaySoundComponent : AbilityComponent
{
    private AudioClip _soundClip;

    public PlaySoundComponent(AudioClip soundClip)
    {
        _soundClip = soundClip;
    }

    public override void Execute(CharacterComponentsContainer container)
    {
        if (container.AudioSource == null)
        {
            return;
        }
        
        container.AudioSource.PlayOneShot(_soundClip);
    }
}
