using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAnim : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("SpacePressed", true);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("SpacePressed", false);
        }
    }
}