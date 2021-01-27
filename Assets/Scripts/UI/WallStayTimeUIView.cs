using UnityEngine;
using UnityEngine.UI;

public class WallStayTimeUIView : MonoBehaviour{
    [SerializeField] private Image m_image;
    [SerializeField] private GameObject m_player;
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

        //Playerの向きの影響を受けないよう補正
        if (m_player.transform.localScale.x < 0.0f) {
            var ts = transform;
            var localScale = ts.localScale; 
            localScale.x = Mathf.Abs(localScale.x) * -1.0f; 
            ts.localScale = localScale; 
        }else if (m_player.transform.localScale.x > 0.0f) {
            var ts = transform;
            var localScale = ts.localScale;
            localScale.x = Mathf.Abs(localScale.x);
            ts.localScale = localScale;
        }
    }

    public void SetAmount(float _value){
        m_image.fillAmount = _value;
    }
}
