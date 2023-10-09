using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;
    [SerializeField] Player player;
    private const string IS_CROUCHING = "isCrouching";

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetBool(IS_CROUCHING, player.IsCrouching());
    }
}
