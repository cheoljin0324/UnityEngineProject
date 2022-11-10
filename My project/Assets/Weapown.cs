using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Weapown : MonoBehaviour
{
    [SerializeField]
    private Transform choNet;
    [SerializeField]
    private Transform Net;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Attack2());
        }
    }

    IEnumerator Attack()
    {
        Vector3 ori = transform.position;

        transform.DOMove(choNet.position,0.5f);
        yield return new WaitForSeconds(0.5f);
        transform.DOMove(ori, 0.5f);
    }

    IEnumerator Attack2()
    {
       Quaternion ori = transform.rotation;
        Vector3 oriPos = transform.position;

        transform.DOMove(Net.position, 0.3f);
        transform.DORotate(Net.rotation.eulerAngles, 0.3f);
        yield return new WaitForSeconds(0.3f);
        transform.DOMove(oriPos, 0.3f);
        transform.DORotate(ori.eulerAngles, 0.3f);
    }


}
