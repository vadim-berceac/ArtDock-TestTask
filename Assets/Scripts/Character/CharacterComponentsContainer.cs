using UnityEngine;

public class CharacterComponentsContainer : MonoBehaviour
{
   [SerializeField] private Animator animator;
   [SerializeField] private AudioSource audioSource;
   [SerializeField] private DamageMaker damageMaker;
   [SerializeField] private AbilityPlayer abilityPlayer;
   
   public Animator Animator => animator;
   public AudioSource AudioSource => audioSource;
   public DamageMaker DamageMaker => damageMaker;
   public AbilityPlayer AbilityPlayer => abilityPlayer;
   public Transform CashedTransform { get; private set; }

   private void Awake()
   {
      CashedTransform = transform;
   }
}
