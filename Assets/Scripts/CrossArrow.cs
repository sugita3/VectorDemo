using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossArrow : MonoBehaviour
{
    Arrow currentArrow = null;

    void Awake()
    {
        currentArrow = GetComponent<Arrow>();
    }

    void Update()
    {
        
    }
}
