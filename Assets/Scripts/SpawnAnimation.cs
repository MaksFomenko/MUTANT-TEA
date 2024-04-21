using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAnimation : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SpawnAnim()
    {
        animator.SetBool("isChange", false);
        animator.SetBool("isKill", false);
        animator.SetBool("isSpawn", true);
    }
    public void KillAnim()
    {
        animator.SetBool("isChange", false);
        animator.SetBool("isSpawn", false);
        animator.SetBool("isKill", true);
    }
    void OnAnimationEnd()
    {
        animator.SetBool("isSpawn", false);
    }
}
