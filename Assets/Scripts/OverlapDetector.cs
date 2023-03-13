using System.Collections;
using Manus.Interaction;
using Manus.InteractionScene;
using UnityEngine;

public class OverlapDetector : MonoBehaviour
{
    private bool _isOverlapping;

    private GameObject _overlappingObject;

    private bool _hasFixatedObject;

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
            
            ResetDetector();
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
            _hasFixatedObject = true;
        }
    }

    private void ResetObject()
    {
        _isOverlapping = false;

        _overlappingObject.GetComponent<CustomGrabbableObject>().IsGrabbable = true;

        _overlappingObject = null;
    }

    private void ResetDetector()
    {
        if(_hasFixatedObject)
        {
            //rotating the destination for the next placement
            if(this.GetComponent<DestinationRotator>().Rotate())
            {
                _hasFixatedObject = false;
            }
            else
            {   
                //disabling the detector once all rotations have taken place
                transform.parent.parent.gameObject.SetActive(false);
            }
        }
    }

}
