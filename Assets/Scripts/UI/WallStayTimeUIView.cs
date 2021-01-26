using UnityEngine;
using UnityEngine.UI;

public class WallStayTimeUIView : MonoBehaviour{
    [SerializeField] private Image m_image;
    private PlayerActionStateMachine m_stateMachine;

    private void Start(){
        m_stateMachine = FindObjectOfType<PlayerActionStateMachine>();
    }

    private void Update(){
        if (m_stateMachine.CurrentStateType != EPlayerActionState.WallStay) {
            m_image.enabled = false;
        }
        else {
            m_image.enabled = true;
        }
    }

    public void SetAmount(float _value){
        m_image.fillAmount = _value;
    }
}
