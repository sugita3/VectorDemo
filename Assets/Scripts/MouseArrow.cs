using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseArrow : MonoBehaviour
{
    Arrow currentArrow;

    private void Awake()
    {
        currentArrow = GetComponent<Arrow>();
    }

    void Update()
    {
        
    }
}
