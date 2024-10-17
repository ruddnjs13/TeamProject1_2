using System;
using Cinemachine.Utility;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
   [SerializeField] private Transform _interactionTrm;
   [SerializeField] private float _interactionRadius;
   [SerializeField] private LayerMask _interactionLayer;

   private IInteractable _interactableObject = null;

   private void Update()
   {
      CheckInteractableObject();
   }

   private void CheckInteractableObject()
   {
      Collider2D collider = Physics2D.OverlapCircle(_interactionTrm.position
         , _interactionRadius, _interactionLayer);
      if (collider != null && _interactableObject == null)
      {
         _interactableObject = collider.GetComponent<IInteractable>();
         _interactableObject.ShowInteratText();
      }
      else
      {
         _interactableObject = null;
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
