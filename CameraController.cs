using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    CinemachineVirtualCamera vCam;
    CinemachineBasicMultiChannelPerlin noise;

    private void Start()
    {
        vCam = GetComponent<CinemachineVirtualCamera>();
        noise = vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void ApplyNoise(float amplitude = 3, float frequency = 20, float duration = 0.2f)
    {
        StopAllCoroutines();
        StartCoroutine(NoiseRoutine(amplitude, frequency, duration));
    }

    IEnumerator NoiseRoutine(float amplitude, float frequency, float duration)
    {
        noise.m_AmplitudeGain = amplitude;
        noise.m_FrequencyGain = frequency;
        yield return new WaitForSeconds(duration);
        noise.m_AmplitudeGain = 0;
        noise.m_FrequencyGain = 0;
    }
}
