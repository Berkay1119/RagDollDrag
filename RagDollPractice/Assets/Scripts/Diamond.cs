using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Diamond : MonoBehaviour
{
    [SerializeField] GameObject diamond;
    public Vector3 targetPosition;
    public float duration;
    public Transform parent;
    public Vector3 targetRotate;
    Sequence mySequence;

    private void Start()
    {
        mySequence = DOTween.Sequence();
    }

    public void SpawnDiamond()
    {
        GameObject currentDiamond = Instantiate(diamond, this.transform.position, Quaternion.identity, parent);
        mySequence.Append(currentDiamond.transform.DOMove(targetPosition, duration, false));
        mySequence.Insert(0, currentDiamond.transform.DORotate(targetRotate, 2f, RotateMode.FastBeyond360));
        mySequence.Insert(0, currentDiamond.transform.DOShakeScale(duration, 1f, 2, 30f, true));
        Destroy(currentDiamond, duration + 0.1f);
}

}
