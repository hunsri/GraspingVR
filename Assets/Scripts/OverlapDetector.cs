using System.Collections;
using Manus.Interaction;
using Manus.InteractionScene;
using UnityEngine;

public class OverlapDetector : MonoBehaviour
{
    private bool _isOverlapping;

    private GameObject _overlappingObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Grabbable")
        {
            _isOverlapping = true;
            _overlappingObject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Grabbable")
        {
            ResetObject();
        }
    }

    private void Update()
    {
        if(_isOverlapping && _overlappingObject != null) {
            
            CustomGrabbableObject customGrabbableObject = _overlappingObject.GetComponent<CustomGrabbableObject>();
            if(!customGrabbableObject.IsGrabbed && customGrabbableObject.IsGrabbable)
            {
                customGrabbableObject.IsGrabbable = false;

                FixateAndAnalyseObject();
            }
        }
    }

    private void FixateAndAnalyseObject()
    {
        if(_overlappingObject != null)
        {
            TransformationAnalyser.Analyse(_overlappingObject.transform, this.transform);
        }
    }

    private void ResetObject()
    {
        _isOverlapping = false;

        _overlappingObject.GetComponent<CustomGrabbableObject>().IsGrabbable = true;

        _overlappingObject = null;
    }

}
