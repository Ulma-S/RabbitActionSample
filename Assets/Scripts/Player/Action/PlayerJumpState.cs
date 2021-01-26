using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(PlayerCollisionDetector))]
public class PlayerJumpState : PlayerActionStateBase{
    [SerializeField] private PlayerCollisionDetector m_collisionDetector;
    protected float m_elapsedTime = 0.0f;
    
    protected override void Initialize(){
        m_stateMachine.AddState(EPlayerActionState.Jump, this);
    }

    public override void OnEnter(){
        m_elapsedTime = 0.0f;

        //空気抵抗反映
        var velocity = m_rb.velocity;
        velocity.x *= m_playerStatus.AirResistanceScale;
        m_rb.velocity = velocity;
    }

    protected override void UpdateAction(){
        var horizontalInput = KeyboardInputProvider.Instance.HorizontalInput;
        
        //空中移動
        if (Mathf.Abs(horizontalInput) > 0.0f) {
            var velocity = m_rb.velocity;
            velocity.x = horizontalInput * m_playerStatus.MoveSpeed * m_playerStatus.AirResistanceScale;
            m_rb.velocity = velocity;
        }

        //長押しでジャンプ力変更
        if (m_elapsedTime < m_playerStatus.MaxJumpTime && KeyboardInputProvider.Instance.IsJumpHolding) {
            var velocity = m_rb.velocity;
            velocity.y = m_playerStatus.JumpSpeed;
            m_rb.velocity = velocity;
        }

        if (m_collisionDetector.IsHitWall()) {
            m_stateMachine.ChangeState(EPlayerActionState.WallStay);
        }

        //接地判定
        if (m_collisionDetector.IsHitGround()) {
            if (m_rb.velocity.y < 0.0f) {
                m_stateMachine.ChangeState(EPlayerActionState.Idle);
            }
        }

        if (KeyboardInputProvider.Instance.IsRushAttack) {
            m_stateMachine.ChangeState(EPlayerActionState.RushAttack);
        }

        m_elapsedTime += Time.deltaTime;
    }

    public override void OnExit(){
    }

    protected override void Reset(){
        base.Reset();
        m_collisionDetector = GetComponent<PlayerCollisionDetector>();
    }
}
