using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void SetMovementAnim(float input, bool isSprinting)
    {
        float paramVal = 0f;
        if (input > 0f)
        {
            paramVal = isSprinting ? 1f : 0.5f;
        }
        _animator.SetFloat("MovementSpeed", paramVal);
    }

    public void PlayJumpAnim()
    {
        _animator.SetTrigger("Jump");
    }
}
