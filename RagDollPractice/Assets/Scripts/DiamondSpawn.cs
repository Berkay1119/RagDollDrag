using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DiamondSpawn : MonoBehaviour
{
    [Header("Object That is Spawning")]
    [SerializeField] private GameObject diamond;
    
    [Header("Tuning")]
    [SerializeField] private Vector3 targetPosition;
    [SerializeField] private float scaleRatio;
    [SerializeField] private float duration;
    [SerializeField] private Transform parent;
    [SerializeField] private Vector3 targetRotate;
    Sequence mySequence;
    
    
    [Header("Choose Ease Type to Affect the Move")]
    [SerializeField] private Ease easeType;


    private void Start()
    {
        mySequence = DOTween.Sequence();
    }

    public void SpawnDiamond()
    {
        GameObject currentDiamond = Instantiate(diamond, this.transform.position, Quaternion.identity, parent);
        mySequence.Append(currentDiamond.transform.DOScale(scaleRatio, duration / 10));
        mySequence.Append(currentDiamond.transform.DOMove(targetPosition, duration, false).SetEase(easeType));
        mySequence.Insert(1, currentDiamond.transform.DORotate(targetRotate, duration, RotateMode.FastBeyond360));
        mySequence.Append(currentDiamond.transform.DOScale(new Vector3(1f, 1f, 1f), duration / 5).SetDelay(duration / 5));
        Destroy(currentDiamond, duration + 0.1f);
    }
}
