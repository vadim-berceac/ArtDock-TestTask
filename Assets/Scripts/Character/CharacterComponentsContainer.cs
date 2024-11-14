using UnityEngine;

public class CharacterComponentsContainer : MonoBehaviour
{
   [SerializeField] private Animator animator;
   [SerializeField] private AudioSource audioSource;
   
   public Animator Animator => animator;
   public AudioSource AudioSource => audioSource;
   public Transform CashedTransform { get; private set; }

   private void Awake()
   {
      CashedTransform = transform;
   }
}
