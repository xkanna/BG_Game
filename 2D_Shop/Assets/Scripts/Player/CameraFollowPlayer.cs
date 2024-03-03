using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float followSpeed = 5f;
    [SerializeField] private float delay = 0.5f;

    private void Start()
    {
        StartCoroutine(FollowCoroutine());
    }

    private IEnumerator FollowCoroutine()
    {
        while (true)
        {
            var targetPosition = target.transform.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
            yield return new WaitForSeconds(delay);
        }
    }
}
