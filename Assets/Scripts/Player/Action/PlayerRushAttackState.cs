using UnityEngine;

public class PlayerRushAttackState : PlayerActionStateBase{
    [SerializeField] private PlayerCollisionDetector m_collisionDetector;
    private float m_elapsedTime = 0.0f;
    
    protected override void Initialize(){
        m_stateMachine.AddState(EPlayerActionState.RushAttack, this);
    }

    public override void OnEnter(){
        m_elapsedTime = 0.0f;
        
        var velocity = m_rb.velocity;

        var horizontalInput = KeyboardInputProvider.Instance.HorizontalInput;
        if (Mathf.Abs(horizontalInput) > 0.0f) {
            velocity.x = KeyboardInputProvider.Instance.HorizontalInput;
        }
        else {
            velocity.x = transform.localScale.x;
        }
        
        velocity.y = KeyboardInputProvider.Instance.VerticalInput;
        m_rb.velocity = velocity.normalized * m_playerStatus.RushAttackForce;
    }
    
    protected override void UpdateAction(){
        //一定時間経過でIdleに遷移
        if (m_elapsedTime > m_playerStatus.MaxRushAttackTime) {
            m_stateMachine.ChangeState(EPlayerActionState.Idle);
        }
        //壁に当たると張り付き
        if (m_collisionDetector.IsHitWall()) {
            m_stateMachine.ChangeState(EPlayerActionState.WallStay);
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
