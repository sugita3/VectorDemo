using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotArrow : MonoBehaviour
{
    [Tooltip("対象の矢印"), SerializeField]
    Arrow targetArrow = null;

    const int HitMax = 8;
    RaycastHit[] hits = new RaycastHit[HitMax];

    Arrow currentArrow = null;
    Camera mainCamera = null;
    int planeLayer;

    private void Awake()
    {
        currentArrow = GetComponent<Arrow>();
        mainCamera = Camera.main;
        planeLayer = LayerMask.GetMask("Plane");
    }

    void Update()
    {
        if (currentArrow == null) return;

        var mpos = Input.mousePosition;
        var ray = mainCamera.ScreenPointToRay(mpos);
        var count = Physics.RaycastNonAlloc(ray, hits, float.PositiveInfinity, planeLayer);
        if (count > 0)
        {
            var target = targetArrow.toPosition - targetArrow.fromPosition;
            var current = hits[0].point - targetArrow.fromPosition;
            var dot = Vector3.Dot(target, current);

            var dotVector = target.normalized * dot;

            currentArrow.fromPosition = targetArrow.fromPosition;
            currentArrow.toPosition = targetArrow.fromPosition + dotVector;
            currentArrow.UpdateArrow();
        }
    }
}
