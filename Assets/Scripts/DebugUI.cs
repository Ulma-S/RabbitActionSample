using UnityEngine;

public class DebugUI : MonoBehaviour{
    private PlayerActionStateMachine m_stateMachine;

    private void Start(){
        m_stateMachine = FindObjectOfType<PlayerActionStateMachine>();
    }

    private void OnGUI(){
        GUILayout.Label(m_stateMachine.CurrentStateType.ToString());
    }
}
