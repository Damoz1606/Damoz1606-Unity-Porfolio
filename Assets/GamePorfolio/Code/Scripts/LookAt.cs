using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField] private Transform _target;

    public Transform Target { get => _target; set => _target = value; }

    private void Update()
    {
        this.LookAtTarget();
    }

    private void LookAtTarget()
    {
        this.transform.LookAt(this._target);
    }
}
