﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] private float speedOfSpin = 360f;

    private void Update()
    {
        transform.Rotate(0, 0, speedOfSpin * Time.deltaTime);
    }
}