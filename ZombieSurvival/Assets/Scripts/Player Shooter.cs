using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public static readonly int IdReload = Animator.StringToHash("Reload");

    public Gun gun;
    public Transform gunPivot;
    public Transform leftHandMouht;
    public Transform rightHandMouht;
    private Animator PlayerAnimator;
    private PlayerInput playerInput;

    private void Awake()
    {
        PlayerAnimator = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();

        gun.gunAnimator = PlayerAnimator;
    }

    private void Update()
    {
        if (playerInput.Fire)
        {
            gun.Fire();
        }
        else if (playerInput.Reload && gun.Reload())
        {
            PlayerAnimator.SetTrigger(IdReload);
        }
    }
    
    private void OnAnimatorIK(int layerIndex)
    {
        gunPivot.position = PlayerAnimator.GetIKHintPosition(AvatarIKHint.RightElbow);

        PlayerAnimator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1f);
        PlayerAnimator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1f);
        PlayerAnimator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandMouht.position);
        PlayerAnimator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandMouht.rotation);

        PlayerAnimator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);
        PlayerAnimator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1f);
        PlayerAnimator.SetIKPosition(AvatarIKGoal.RightHand, rightHandMouht.position);
        PlayerAnimator.SetIKRotation(AvatarIKGoal.RightHand, rightHandMouht.rotation);
    }
}
