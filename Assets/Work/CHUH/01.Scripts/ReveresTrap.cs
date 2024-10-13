using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ReveresTrap : MonoBehaviour
{
    [SerializeField] private float waitTime = 1f;
    private bool isFilp = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Reveres());
        }
    }

    private IEnumerator Reveres()
    {
        yield return new WaitForSeconds(waitTime);
        ReveresGround(isFilp);
    }

    private void ReveresGround(bool filp)
    {
        isFilp = !filp;
        if(isFilp == true)
        {
            
        }
        else
        {

        }
    }
    
}
