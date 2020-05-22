using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeesHelp : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy");
            collision.gameObject.GetComponent<Animator>().SetBool("Stop", true);
            StartCoroutine(StopCounter(collision));
        }
    }


    IEnumerator StopCounter(Collider2D collision)
    {
        yield return new WaitForSeconds(5f);
        collision.gameObject.GetComponent<Animator>().SetBool("Stop", false);
    }
}
