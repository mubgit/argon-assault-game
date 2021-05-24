using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float controlSpeed = 30f;
    [SerializeField] float xRange = 5f;
    [SerializeField] float yRange = 3.5f;
    [SerializeField] GameObject[] lasersArray;

    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float positionYawFactor = -2.5f;
    [SerializeField] float controlRollFactor = 5f;

    float xThrow, yThrow;
    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFirng();
    }

    void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;


        float pitch = pitchDueToPosition + pitchDueToControlThrow;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow + controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float newxPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(newxPos, -xRange, xRange);

        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float newYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(newYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    void ProcessFirng()
    {
        if (Input.GetButton("Fire1"))
        {
            SetLasersActive(true);

        }
        else
        {
            SetLasersActive(false);

        }
    }


    private void SetLasersActive(bool isActive)
    {
        foreach (GameObject laser in lasersArray)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }
}
