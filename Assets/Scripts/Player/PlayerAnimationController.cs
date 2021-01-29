using UnityEngine;

[RequireComponent(typeof(PlayerActionStateMachine), typeof(Animator))]
public class PlayerAnimationController : MonoBehaviour{
    [SerializeField] private PlayerActionStateMachine m_stateMachine;
    [SerializeField] private Animator m_animator;
    
    private static readonly int IsIdle = Animator.StringToHash("IsIdle");
    private static readonly int IsRun = Animator.StringToHash("IsRun");
    private static readonly int IsJump = Animator.StringToHash("IsJump");
    private static readonly int IsWallStay = Animator.StringToHash("IsWallStay");
    private static readonly int IsWallJump = Animator.StringToHash("IsWallJump");
    private static readonly int IsRushAttack = Animator.StringToHash("IsRushAttack");

    private void Start(){
        m_stateMachine.OnEnterState += () => {
            switch (m_stateMachine.CurrentStateType) {
                case EPlayerActionState.Idle:
                    m_animator.SetBool(IsIdle, true);
                    m_animator.SetBool(IsRun, false);
                    m_animator.SetBool(IsJump, false);
                    m_animator.SetBool(IsWallStay, false);
                    m_animator.SetBool(IsWallJump, false);
                    m_animator.SetBool(IsRushAttack, false);
                    break;
                
                case EPlayerActionState.Run:
                    m_animator.SetBool(IsIdle, false);
                    m_animator.SetBool(IsRun, true);
                    m_animator.SetBool(IsJump, false);
                    m_animator.SetBool(IsWallStay, false);
                    m_animator.SetBool(IsWallJump, false);
                    m_animator.SetBool(IsRushAttack, false);
                    break;
                
                case EPlayerActionState.Jump:
                    m_animator.SetBool(IsIdle, false);
                    m_animator.SetBool(IsRun, false);
                    m_animator.SetBool(IsJump, true);
                    m_animator.SetBool(IsWallStay, false);
                    m_animator.SetBool(IsWallJump, false);
                    m_animator.SetBool(IsRushAttack, false);
                    break;
                
                case EPlayerActionState.WallStay:
                    m_animator.SetBool(IsIdle, false);
                    m_animator.SetBool(IsRun, false);
                    m_animator.SetBool(IsJump, false);
                    m_animator.SetBool(IsWallStay, true);
                    m_animator.SetBool(IsWallJump, false);
                    m_animator.SetBool(IsRushAttack, false);
                    break;
                
                case EPlayerActionState.WallJump:
                    m_animator.SetBool(IsIdle, false);
                    m_animator.SetBool(IsRun, false);
                    m_animator.SetBool(IsJump, false);
                    m_animator.SetBool(IsWallStay, false);
                    m_animator.SetBool(IsWallJump, true);
                    m_animator.SetBool(IsRushAttack, false);
                    break;
                
                case EPlayerActionState.RushAttack:
                    m_animator.SetBool(IsIdle, false);
                    m_animator.SetBool(IsRun, false);
                    m_animator.SetBool(IsJump, false);
                    m_animator.SetBool(IsWallStay, false);
                    m_animator.SetBool(IsWallJump, false);
                    m_animator.SetBool(IsRushAttack, true);
                    break;
            }
        };
    }

    private void Reset(){
        m_stateMachine = GetComponent<PlayerActionStateMachine>();
        m_animator = GetComponent<Animator>();
    }
}
