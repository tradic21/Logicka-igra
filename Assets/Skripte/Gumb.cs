using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gumb : MonoBehaviour
{
    public GameObject laser;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Igrac"))
        {
            laser.SetActive(false);
            animator.SetBool("jePritisnut", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        laser.SetActive(true);
        animator.SetBool("jePritisnut", false);
    }
}
