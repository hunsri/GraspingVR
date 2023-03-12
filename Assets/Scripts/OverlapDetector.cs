using System.Collections;
using System.Collections.Generic;
using Manus.Interaction;
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
            
            CustomGrabbableObject script = _overlappingObject.GetComponent<CustomGrabbableObject>();
            if(!script.IsGrabbed)
            {

                StartCoroutine(TeleportDelayCoroutine());
            }
        }
    }

    IEnumerator TeleportDelayCoroutine()
    {
        yield return new WaitForSecondsRealtime(0.1f);

        if(_overlappingObject != null)
        {
            _overlappingObject.transform.position = _overlappingObject.transform.parent.position;
            _overlappingObject.transform.rotation = _overlappingObject.transform.parent.rotation;
            
            ResetObject();
        }
    }

    private void ResetObject()
    {
        _isOverlapping = false;
        _overlappingObject = null;
    }

}
