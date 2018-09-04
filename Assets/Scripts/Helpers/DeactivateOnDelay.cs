using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateOnDelay : MonoBehaviour
{
    public float delay = 1f;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(Deactivate());
    }

    IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }
}
