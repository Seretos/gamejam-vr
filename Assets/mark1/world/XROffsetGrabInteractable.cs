using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace mark1.world
{
    public class XROffsetGrabInteractable : XRGrabInteractable
    {
        private Vector3 _initialAttachLocalPos;
        private Quaternion _initialAttachLocalRot;
        private void Start()
        {
            if (!attachTransform)
            {
                GameObject grab = new GameObject("Grab Pivot");
                grab.transform.SetParent(transform, false);
                attachTransform = grab.transform;
            }

            _initialAttachLocalPos = attachTransform.localPosition;
            _initialAttachLocalRot = attachTransform.localRotation;
        }

        protected override void OnSelectEntered(XRBaseInteractor interactor)
        {
            if (interactor is XRDirectInteractor)
            {
                attachTransform.position = interactor.transform.position;
                attachTransform.rotation = interactor.transform.rotation;
            }
            else
            {
                attachTransform.localPosition = _initialAttachLocalPos;
                attachTransform.localRotation = _initialAttachLocalRot;
            }
            base.OnSelectEntered(interactor);
        }
    }
}