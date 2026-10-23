using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerMovement : MonoBehaviour
{
    public static readonly int HashMove = Animator.StringToHash("Move");        //Hash함수에 대해 다시 찾아보기
    public float moveSpeed = 5f;
    public float rotateSpeed = 180f;        // 1초에 180도 회전하는 속도

    private Animator playerAnimator;
    private PlayerInput playerInput;
    private Rigidbody playerRigidbody;

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
        playerRigidbody = GetComponent<Rigidbody>();
    }
    private void Update()   // 입력키는 여기
    {
        playerAnimator.SetFloat(HashMove, playerInput.Move);
    }

    private void FixedUpdate()      // 물리 관련일을 매 프레임마다 할일 있을때는 이걸로
    {
        float angle = playerInput.Rotate * rotateSpeed * Time.deltaTime;
        playerRigidbody.MoveRotation(playerRigidbody.rotation * Quaternion.Euler(0f, angle, 0f));  //(오일러)
            // y축으로 angle만큼의 회전

        Vector3 delta = playerInput.Move * transform.forward * moveSpeed * Time.deltaTime;   
        playerRigidbody.MovePosition(playerRigidbody.position + delta);
    }
}
