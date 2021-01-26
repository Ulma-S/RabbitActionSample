using System;
using UnityEngine;

public class WallStayTimeUIModel : MonoBehaviour{
    private PlayerWallStayState m_wallStayState;
    [SerializeField] private PlayerStatus m_playerStatus;
    private float m_currentWallStayTimePercentage;
    
    public Action<float> OnUpdate = null;

    private void Start(){
        m_wallStayState = FindObjectOfType<PlayerWallStayState>();
    }

    private void Update(){
        m_currentWallStayTimePercentage = 1.0f -  m_wallStayState.CurrentElapsedTime / m_playerStatus.MaxWallStayTime;
        OnUpdate?.Invoke(m_currentWallStayTimePercentage);
    }
}
