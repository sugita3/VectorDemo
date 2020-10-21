using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 指定の矢印の単位ベクトルとして機能します。
/// </summary>
public class NormalizedArrow : MonoBehaviour
{
    [Tooltip("ターゲットの矢印"), SerializeField]
    Arrow targetArrow = null;

    Arrow currentArrow = null;

    private void Awake()
    {
        currentArrow = GetComponent<Arrow>();
    }

    void LateUpdate()
    {
        if (targetArrow == null) return;

        var dir = targetArrow.toPosition - targetArrow.fromPosition;
        var normDir = dir.normalized;
        currentArrow.fromPosition = targetArrow.fromPosition;
        currentArrow.toPosition = targetArrow.fromPosition + normDir;
        currentArrow.UpdateArrow();
    }
}
