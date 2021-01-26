using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerIdleState : PlayerActionStateBase{
    [SerializeField] private PlayerCollisionDetector m_collisionDetector;
    
    protected override void Initialize(){
        m_stateMachine.AddState(EPlayerActionState.Idle, this);
        m_stateMachine.ChangeState(EPlayerActionState.Idle);
    }

    public override void OnEnter(){
        //x方向の速度を0にする
        var velocity = m_rb.velocity;
        velocity.x = 0.0f;
        m_rb.velocity = velocity;
    }

    protected override void UpdateAction() {
        //Jumpに遷移
        if (KeyboardInputProvider.Instance.IsJump) {
            if (m_collisionDetector.IsHitWall()) {
                m_stateMachine.ChangeState(EPlayerActionState.WallJump);
            }
            else if (m_collisionDetector.IsHitGround()) {
                m_stateMachine.ChangeState(EPlayerActionState.Jump);
            }
        }

        //Runに遷移
        var horizontalInput = KeyboardInputProvider.Instance.HorizontalInput;
        if (Mathf.Abs(horizontalInput) > 0.0f) {
            m_stateMachine.ChangeState(EPlayerActionState.Run);
        }

        //RushAttackに遷移
        if (KeyboardInputProvider.Instance.IsRushAttack) {
            m_stateMachine.ChangeState(EPlayerActionState.RushAttack);
        }
    }

    public override void OnExit(){
    }

    protected override void Reset(){
        base.Reset();
        m_collisionDetector = GetComponent<PlayerCollisionDetector>();
    }
}
