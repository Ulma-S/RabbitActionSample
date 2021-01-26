using UnityEngine;

public class PlayerEffectManager : MonoBehaviour{
    [SerializeField] private PlayerActionStateMachine m_stateMachine;

    private void Start(){
        m_stateMachine.OnExitState += () => {
            var ts = transform;
            var pos = ts.position;
            
            switch (m_stateMachine.CurrentStateType) {
                case EPlayerActionState.Jump:
                    pos.y -= ts.localScale.y / 2.0f;
                    EffectManager.Instance.PlayEffect(EffectManager.EffectID.SmokePuff, pos);
                    break;
                
                case EPlayerActionState.WallJump:
                    pos.y -= ts.localScale.y / 2.0f;
                    EffectManager.Instance.PlayEffect(EffectManager.EffectID.SmokePuff, pos);
                    break;
                
                default: 
                    break;
            }
        };
    }

    private void Reset(){
        m_stateMachine = GetComponent<PlayerActionStateMachine>();
    }
}
