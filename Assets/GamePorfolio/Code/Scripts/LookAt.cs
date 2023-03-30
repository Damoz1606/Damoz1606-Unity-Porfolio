using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform Target;

    private Transform _target;

    public Transform _Target { get => _target; set => _target = value; }

    private void Start()
    {
        this._Target = Target;
    }

    private void Update()
    {
        this.LookAtTarget();
    }

    private void LookAtTarget()
    {
        this.transform.LookAt(this._Target);
    }
}
