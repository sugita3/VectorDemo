using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowKeyMove : MonoBehaviour
{
    [Tooltip("回転速度"), SerializeField]
    float angularSpeed = 90;
    [Tooltip("長さ速度"), SerializeField]
    float lengthSpeed = 4;

    const float MinLength = 0.5f;

    Arrow currentArrow = null;

    private void Awake()
    {
        currentArrow = GetComponent<Arrow>();
    }

    void FixedUpdate()
    {
        var dir = currentArrow.toPosition - currentArrow.fromPosition;

        var v = Input.GetAxisRaw("Vertical");
        if (!Mathf.Approximately(v, 0))
        {
            var length = Mathf.Max(dir.magnitude + lengthSpeed * v * Time.fixedDeltaTime, MinLength);
            currentArrow.toPosition = currentArrow.fromPosition + dir.normalized * length;
        }

        var h = Input.GetAxisRaw("Horizontal");
        if (!Mathf.Approximately(h, 0))
        {
            var rot = Quaternion.Euler(0, 0, angularSpeed * h * Time.fixedDeltaTime);
            var rotated = rot * dir;
            currentArrow.toPosition = currentArrow.fromPosition + rotated;
        }

        currentArrow.UpdateArrow();
    }
}
