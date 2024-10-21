using System;
using Cinemachine.Utility;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
   [SerializeField] private InputReaderSO _inputReader;
   [SerializeField] private Transform _interactionTrm;
   [SerializeField] private float _interactionRadius;
   [SerializeField] private LayerMask _interactionLayer;
   [SerializeField] private GameObject _interactMark;

   public bool canInteract { get; private set; } = false;

   private IInteractable _interactableObject = null;

   private void OnEnable()
   {
      _inputReader.InteractionEvent += HandleInteractEvent;
   }

   private void OnDisable()
   {
      _inputReader.InteractionEvent -= HandleInteractEvent;
   }

   private void HandleInteractEvent()
   {
      if (canInteract && _interactableObject != null)
      {
         _interactableObject.Interact();
      }
   }


   private void Update()
   {
      CheckInteractableObject();
   }

   private void CheckInteractableObject()
   {
      Collider2D collider = Physics2D.OverlapCircle(_interactionTrm.position
         , _interactionRadius, _interactionLayer);
      if (collider != null)
      {
         _interactMark.SetActive(true);
         _interactableObject = collider.GetComponent<IInteractable>();
         _interactableObject.ShowInteractText();
         canInteract = true;
      }
      else
      {
         _interactMark.SetActive(false);
         _interactableObject = null;
         canInteract = false;
      }
   }

#if UNITY_EDITOR
   private void OnDrawGizmos()
   {
      Gizmos.color = Color.green;
      Gizmos.DrawWireSphere(_interactionTrm.position, _interactionRadius);
      Gizmos.color = Color.white;
   }

#endif
}
