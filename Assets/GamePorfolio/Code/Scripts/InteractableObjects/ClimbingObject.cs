using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbingObject : _AInteractableObject
{
    public override void DisableInteraction()
    {
        
    }

    public override void EnableInteraction()
    {
        
    }

    public override void Interact()
    {
        this.Player.CanClimb = !this.Player.CanClimb;
        this.FaceObject();
    }

    private void FaceObject()
    {
        float _rotationVelocity = 0;
        float _targetRotation = Mathf.Atan2(this.transform.position.x, this.transform.position.z) * Mathf.Rad2Deg;
        float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetRotation, ref _rotationVelocity, 0);

        // rotate to face input direction relative to camera position
        Player.transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
    }
}
