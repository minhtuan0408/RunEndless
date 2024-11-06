using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private Animator animator;

    public AnimatorOverrideController[] AnimatorOverrideController;

    int i;

    private void Start()
    {
        animator = GetComponent<Animator>();
        i = 0;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            i++;
            if (i > AnimatorOverrideController.Length - 1 )
            {
                i = 0;
            }
            animator.runtimeAnimatorController = AnimatorOverrideController[i];
            
            
        }
    }
}
