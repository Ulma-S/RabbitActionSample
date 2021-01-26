using UnityEngine;

public class PlayerWallStayState : PlayerActionStateBase{
    private float m_elapsedTime = 0.0f;
    public float CurrentElapsedTime => m_elapsedTime;

    protected override void Initialize(){
        m_stateMachine.AddState(EPlayerActionState.WallStay, this);
    }

    public override void OnEnter(){
        m_elapsedTime = 0.0f;

        //y方向の速度を0にする
        var velocity = m_rb.velocity;
        velocity.x = 0.0f;
        velocity.y = 0.0f;
        m_rb.velocity = velocity;

        EnableGravity = false;
        CanChangeLocalScale = false;
        KeyboardInputProvider.Instance.EnableInput = true;
    }

    protected override void UpdateAction(){
        if (KeyboardInputProvider.Instance.IsJump) {
            m_stateMachine.ChangeState(EPlayerActionState.WallJump);
        }
        
        //壁張り付き限界時間を超えたらIdleに遷移
        if (m_elapsedTime > m_playerStatus.MaxWallStayTime) {
            EnableGravity = true;
            CanChangeLocalScale = true;
            m_stateMachine.ChangeState(EPlayerActionState.Idle);
        }
        else {
            EnableGravity = false;
            CanChangeLocalScale = false;
        }

        //RushAttackに遷移
        if (KeyboardInputProvider.Instance.IsRushAttack) {
            m_stateMachine.ChangeState(EPlayerActionState.RushAttack);
        }
        m_elapsedTime += Time.deltaTime;
    }

    public override void OnExit(){
        EnableGravity = true;
        m_elapsedTime = 0.0f;
    }
}
