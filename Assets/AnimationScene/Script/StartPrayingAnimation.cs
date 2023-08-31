using UnityEngine;


/// <summary>
/// This class handles starting various animations using different keyboard inputs
/// </summary>
public class StartPrayingAnimation : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// Checks for input and triggers playing different animations depending on what key is pressed
    /// </summary>
    void Update()
    {
        /// triggers praying animation when P is pressed
        if (Input.GetKeyDown(KeyCode.P))
        {
            
            animator.SetTrigger("StartPrayingAnimation");
        }
         /// triggers spin animation when S is pressed
     if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetTrigger("SpinTrigger");
        }
         /// triggers kick animation when K is pressed
     if (Input.GetKeyDown(KeyCode.K))
        {
            animator.SetTrigger("KickTrigger");
        }
        
        
        
    }
}

