using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpInteraction : MonoBehaviour
{
    [Header("Config")]
    public float lerpTime;
    public bool isRotation;
    public bool action = false;

    private float lerpTimer = 0.0f;
    private float lerpPercent;
    public bool isOpenned = false;
    
    [Header("Axis")]
    public bool x;
    public bool y;
    public bool z;

    [Header("Positions")]
    private Vector3 startPosition;
    public Vector3 endPosition;

    private void Start()
    {
        if (isRotation)
        {
            startPosition = transform.localEulerAngles;

            if (!x)
            {
                endPosition.x = transform.localEulerAngles.x;
            }

            if (!y)
            {
                endPosition.y = transform.localEulerAngles.y;
            }

            if (!z)
            {
                endPosition.z = transform.localEulerAngles.z;
            }
        }

        if (!isRotation)
        {
            startPosition = transform.localPosition;

            if (!x)
            {
                endPosition.x = transform.localPosition.x;
            }

            if (!y)
            {
                endPosition.y = transform.localPosition.y;
            }

            if (!z)
            {
                endPosition.z = transform.localPosition.z;
            }
        }
    }

    private void Update()
    {
        if (action)
        {
            Lerp();
        }
    }

    public void Lerp()
    {
        if (!isRotation)
        {
            if (lerpTimer <= lerpTime)
            {
                if (!isOpenned)
                {
                    lerpTimer += Time.deltaTime;
                    lerpPercent = lerpTimer / lerpTime;

                    transform.localPosition = Vector3.Lerp(startPosition, endPosition, lerpPercent);
                }

                if (isOpenned)
                {
                    lerpTimer += Time.deltaTime;
                    lerpPercent = lerpTimer / lerpTime;

                    transform.localPosition = Vector3.Lerp(endPosition, startPosition, lerpPercent);
                }
            }
        }

        if (isRotation)
        {
            if (lerpTimer <= lerpTime)
            {
                if (!isOpenned)
                {
                    lerpTimer += Time.deltaTime;
                    lerpPercent = lerpTimer / lerpTime;

                    transform.localEulerAngles = Vector3.Lerp(startPosition, endPosition, lerpPercent);
                }

                if (isOpenned)
                {
                    lerpTimer += Time.deltaTime;
                    lerpPercent = lerpTimer / lerpTime;

                    transform.localEulerAngles = Vector3.Lerp(endPosition, startPosition, lerpPercent);
                }
            }
        }

        if (lerpTimer >= lerpTime)
        {
            if (isOpenned)
            {
                isOpenned = false;
                action = false;
                lerpTimer = 0.0f;
            }

            else if (!isOpenned)
            {
                isOpenned = true;
                action = false;
                lerpTimer = 0.0f;
            }
        }
    }
}
