using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputSystem : MonoBehaviour
{

    [Header("Input values")]
    [SerializeField] public Vector2 move;
    [SerializeField] public float climb;
    [SerializeField] public bool jump;
    [SerializeField] public bool sprint;
    [SerializeField] public bool interact;


    public void OnMove(InputValue value)
    {
        MoveInput(value.Get<Vector2>());
    }

    public void OnClimb(InputValue value)
    {
        ClimbInput(value.Get<Vector2>().y);
    }

    public void OnJump(InputValue value)
    {
        JumpInput(value.isPressed);
    }

    public void OnSprint(InputValue value)
    {
        SprintInput(value.isPressed);
    }

    public void OnInteract(InputValue value)
    {
        InteractInput(value.isPressed);
    }

    private void MoveInput(Vector2 newMoveDirection)
    {
        if (newMoveDirection == Vector2.zero)
            move = Vector2.zero;
        else if (Mathf.Abs(newMoveDirection.x) > Mathf.Abs(newMoveDirection.y))
            move = new Vector2(Mathf.Sign(newMoveDirection.x), 0f);
        else
            move = new Vector2(0f, Mathf.Sign(newMoveDirection.y));
    }

    private void ClimbInput(float newClimbDirection)
    {
        if (newClimbDirection == 0) climb = 0;
        else climb = newClimbDirection;
    }

    private void JumpInput(bool newJumpState)
    {
        jump = newJumpState;
    }

    private void SprintInput(bool newSprintState)
    {
        sprint = newSprintState;
    }

    private void InteractInput(bool newInteractState)
    {
        interact = newInteractState;
    }
}