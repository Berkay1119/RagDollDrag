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
        mySequence.Append(currentDiamond.transform.DOScale(new Vector3(3f, 3f, 3f), duration/10));
        mySequence.Append(currentDiamond.transform.DOMove(targetPosition, duration, false).SetEase(Ease.InQuad));
        mySequence.Insert(1, currentDiamond.transform.DORotate(targetRotate, duration, RotateMode.FastBeyond360));
        mySequence.Append(currentDiamond.transform.DOScale(new Vector3(1f, 1f, 1f), duration/5).SetDelay(duration/5));
        //mySequence.Insert(1, currentDiamond.transform.DOShakeScale(duration, 1f, 2, 30f, true));
        Destroy(currentDiamond, duration + 0.1f);
}

}
