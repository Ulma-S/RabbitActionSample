using Ulma.Util;
using UnityEngine;

[RequireComponent(typeof(PlayerActionStateMachine), typeof(Rigidbody2D))]
public abstract class PlayerActionStateBase : StateBase{
    [SerializeField] protected Rigidbody2D m_rb;
    [SerializeField] protected PlayerActionStateMachine m_stateMachine;
    [SerializeField] protected PlayerStatus m_playerStatus;
    public bool EnableGravity { get; set; } = true;
    public bool CanChangeLocalScale { get; set; } = true;
    
    public override void OnUpdate(){
        ComputeGravity();
        UpdateAction();
        ComputeLocalScale();
    }

    /// <summary>
    /// 個別のStateでの更新処理
    /// </summary>
    protected abstract void UpdateAction();

    /// <summary>
    /// 重力計算
    /// </summary>
    private void ComputeGravity(){
        if(!EnableGravity) return;
        var velocity = m_rb.velocity;
        velocity.y -= m_playerStatus.GravityScale * Time.deltaTime;
        m_rb.velocity = velocity;
    }
    
    /// <summary>
    /// 向き更新
    /// </summary>
    private void ComputeLocalScale(){
        if(!CanChangeLocalScale) return;
        var localScale = transform.localScale;
        var horizontalInput = KeyboardInputProvider.Instance.HorizontalInput;
        if (horizontalInput > 0.0f) {
            localScale.x = Mathf.Abs(localScale.x) * 1.0f;
        }
        else if (horizontalInput < 0.0f) {
            localScale.x = Mathf.Abs(localScale.x) * -1.0f;
        }
        transform.localScale = localScale;
    }
    
    protected virtual void Reset(){
        m_rb = GetComponent<Rigidbody2D>();
        m_stateMachine = GetComponent<PlayerActionStateMachine>();
    }
}
