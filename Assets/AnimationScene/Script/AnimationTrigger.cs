using UnityEngine;

public class StartPrayingAnimation : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            
            animator.SetTrigger("StartPrayingAnimation");
        }

     if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetTrigger("SpinTrigger");
        }

     if (Input.GetKeyDown(KeyCode.K))
        {
            animator.SetTrigger("KickTrigger");
        }
        
        
        
    }
}

