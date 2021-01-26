using System.Collections;
using UnityEngine;

public class PlayerWallJumpState : PlayerActionStateBase{
    [SerializeField] private PlayerCollisionDetector m_collisionDetector;
    private float m_elapsedTime = 0.0f;
    
    protected override void Initialize(){
        m_stateMachine.AddState(EPlayerActionState.WallJump, this);
    }

    public override void OnEnter(){
        m_elapsedTime = 0.0f;
        
        EnableGravity = true;
        CanChangeLocalScale = false;
        
        //x方向を反転させる
        var ts = transform;
        var localScale = ts.localScale;
        localScale.x *= -1.0f;
        ts.localScale = localScale;

        var velocity = m_rb.velocity;
        velocity.x = localScale.x;
        velocity.y = 1.0f;
        m_rb.velocity = velocity.normalized * m_playerStatus.WallJumpDir * m_playerStatus.WallJumpSpeed;
        CanChangeLocalScale = false;
    }
    
    protected override void UpdateAction(){
        var horizontalInput = KeyboardInputProvider.Instance.HorizontalInput;
        
        //空中移動
        if (Mathf.Abs(horizontalInput) > 0.0f && CanChangeLocalScale) {
            var velocity = m_rb.velocity;
            velocity.x = horizontalInput * m_playerStatus.MoveSpeed * m_playerStatus.AirResistanceScale;
            m_rb.velocity = velocity;
        }

        if (m_collisionDetector.IsHitWall()) {
            m_stateMachine.ChangeState(EPlayerActionState.WallStay);
        }
        
        if (m_collisionDetector.IsHitGround()) {
            m_stateMachine.ChangeState(EPlayerActionState.Idle);
        }
        
        //RushAttackに遷移
        if (KeyboardInputProvider.Instance.IsRushAttack) {
            m_stateMachine.ChangeState(EPlayerActionState.RushAttack);
        }

        if (m_elapsedTime > 1.0f) {
            CanChangeLocalScale = true;
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
