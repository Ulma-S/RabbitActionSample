using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerRunState : PlayerActionStateBase{
    [SerializeField] private PlayerCollisionDetector m_collisionDetector;
    
    protected override void Initialize(){
        m_stateMachine.AddState(EPlayerActionState.Run, this);
    }

    public override void OnEnter(){
    }

    protected override void UpdateAction(){
        var horizontalInput = KeyboardInputProvider.Instance.HorizontalInput;

        //移動処理
        var velocity = m_rb.velocity;
        velocity.x = horizontalInput * m_playerStatus.MoveSpeed;
        m_rb.velocity = velocity;

        //Idleに遷移
        if (Mathf.Abs(horizontalInput) < 0.01f) {
            m_stateMachine.ChangeState(EPlayerActionState.Idle);
        }

        //Jumpに遷移
        if (KeyboardInputProvider.Instance.IsJump && m_collisionDetector.IsHitGround()) {
            m_stateMachine.ChangeState(EPlayerActionState.Jump);
        }

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
