using UnityEngine;

public class CharacterComponentsContainer : MonoBehaviour
{
   [SerializeField] private Animator animator;
   [SerializeField] private AudioSource audioSource;
   [SerializeField] private AreaDamage areaDamage;
   [SerializeField] private CharacterParticlePlayer characterParticlePlayer;
   
   public Animator Animator => animator;
   public AudioSource AudioSource => audioSource;
   public AreaDamage AreaDamage => areaDamage;
   public CharacterParticlePlayer CharacterParticlePlayer => characterParticlePlayer;
   public Transform CashedTransform { get; private set; }

   private void Awake()
   {
      CashedTransform = transform;
   }
}
