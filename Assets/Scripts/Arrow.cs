using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [Tooltip("元座標")]
    public Vector3 fromPosition = Vector3.zero;
    [Tooltip("目的座標")]
    public Vector3 toPosition = Vector3.up;

    [Header("アセットデータ")]
    [Tooltip("矢印頭"), SerializeField]
    Transform arrowHead = null;
    [Tooltip("棒用のキューブ"), SerializeField]
    Transform cubeBar = null;

    /// <summary>
    /// 矢印トップに棒が付き出ないように調整するための値。
    /// </summary>
    const float bodyOffset = 0.1f;

    private void OnValidate()
    {
        UpdateArrow();
    }

    public void UpdateArrow()
    {
        // 中心点
        var center = (fromPosition + toPosition) * 0.5f;
        transform.position = center;
        // 角度
        transform.up = toPosition - fromPosition;
        // ヘッダの設定
        var length = Vector3.Distance(toPosition, fromPosition);
        arrowHead.transform.localPosition = Vector3.up * length * 0.5f;
        // ボディの設定
        var sc = cubeBar.transform.localScale;
        sc.y = length - bodyOffset;
        cubeBar.transform.localScale = sc;
        var pos = Vector3.down* bodyOffset *0.5f;
        pos.z = cubeBar.transform.localPosition.z;
        cubeBar.transform.localPosition = pos;
    }
}
