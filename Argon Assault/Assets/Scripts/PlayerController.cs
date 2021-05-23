using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float controlSpeed = 30f;
    [SerializeField] float xRange = 5f;
    [SerializeField] float yRange = 3.5f;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      float xThrow =  Input.GetAxis("Horizontal");
      float yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float newxPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(newxPos,-xRange,xRange);

        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float newYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(newYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}
