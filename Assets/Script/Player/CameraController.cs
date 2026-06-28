using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    CinemachineCamera cinemachineCamera;
    [SerializeField] float minFOV = 20f, maxFOV = 120f , zoomDuration = 1f ,zoomModifier =5f;
    [SerializeField] ParticleSystem speedup;

    private void Start()
    {
        cinemachineCamera = GetComponent<CinemachineCamera>();
    }
    public void ChangeCameraFOV(float speedAmount)
    {
        StopAllCoroutines();
        StartCoroutine(ChangingFOV(speedAmount));
        if (speedAmount > 0)
        {
            speedup.Play();
        }


    }

    IEnumerator ChangingFOV( float speedAmount)
    {
        float StartFOV = cinemachineCamera.Lens.FieldOfView;
        float TargetFOV = Mathf.Clamp(   StartFOV + speedAmount * zoomModifier , minFOV, maxFOV);

        float elapsetime = 0f;
        while (elapsetime < zoomDuration)
        {
            float t = elapsetime / zoomDuration;
            elapsetime += Time.deltaTime;


            cinemachineCamera.Lens.FieldOfView = Mathf.Lerp(StartFOV, TargetFOV, t);

            yield return null;
            
        }

        cinemachineCamera.Lens.FieldOfView = TargetFOV;
    }
}
