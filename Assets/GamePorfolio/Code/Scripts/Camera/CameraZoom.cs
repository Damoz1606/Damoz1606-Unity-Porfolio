using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [Space(10)]
    [Header("Zoom Values")]
    [Space(5)]
    [Range(0, 40)]
    public float TargetFOV = 20;
    public float ZoomSpeed = 1;


    private CinemachineVirtualCamera _camera;

    // Camera values
    private float _targetFieldOfView;
    private float _maxFieldOfView = 0;
    private float _minFieldOfView = 0;
    private float _zoomSpeed = 0;
    private float _originalZoom = 0;
    private bool _cameraFOVOnTarget = true;
    private bool _increase = false;

    private void Start()
    {
        this._targetFieldOfView = this.TargetFOV;
        this._zoomSpeed = this.ZoomSpeed;

        this._camera = FindObjectOfType<CinemachineVirtualCamera>();
        if (_camera == null) throw new System.Exception("This needs a CinemachineVirutalCamera");

        this._originalZoom = this._camera.m_Lens.FieldOfView;
        if (this._camera.m_Lens.FieldOfView < this._targetFieldOfView)
        {
            this._minFieldOfView = this._camera.m_Lens.FieldOfView;
            this._maxFieldOfView = this._targetFieldOfView;
        }
        else
        {
            this._maxFieldOfView = this._camera.m_Lens.FieldOfView;
            this._minFieldOfView = this._targetFieldOfView;
        }
    }

    private void FixedUpdate()
    {
        if (!this._cameraFOVOnTarget)
            this.HandleCameraZoom();
    }

    public void Zoom()
    {
        this._cameraFOVOnTarget = false;
        this._increase = true;
    }

    public void Orginal()
    {
        this._cameraFOVOnTarget = false;
        this._increase = false;
    }

    public void HandleCameraZoom()
    {
        float target = 0;
        float endTarget = 0;
        if (this._increase)
        {
            target = this._targetFieldOfView;
            endTarget = this._targetFieldOfView;
        }
        else
        {
            target = this._originalZoom;
            endTarget = this._originalZoom;
        }

        target = Mathf.Clamp(target, this._minFieldOfView, this._maxFieldOfView);
        this._camera.m_Lens.FieldOfView = Mathf.Lerp(this._camera.m_Lens.FieldOfView, target, Time.deltaTime * this._zoomSpeed);
        this._cameraFOVOnTarget = this._camera.m_Lens.FieldOfView == endTarget;
    }
}
