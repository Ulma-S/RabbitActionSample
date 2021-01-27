using System;
using System.Collections.Generic;
using UnityEngine;

namespace Ulma.Util {
    public abstract class StateMachineBase<TStateType, TState> : MonoBehaviour where TStateType : Enum where TState : StateBase {
        private readonly Dictionary<TStateType, TState> m_states = new Dictionary<TStateType, TState>();
        private TStateType m_currentStateType;
        private TState m_currentState;

        public TStateType CurrentStateType => m_currentStateType;
        public TState CurrentState => m_currentState;

        public Action OnEnterState = null;
        public Action OnExitState = null;

        private void Update() {
            UpdateState();
        }

        
        /// <summary>
        /// 現在のStateの更新
        /// </summary>
        private void UpdateState() {
            if(m_currentState != null) m_currentState.OnUpdate();
        }
        

        /// <summary>
        /// State遷移
        /// </summary>
        /// <param name="type"></param>
        public void ChangeState(TStateType type) {
            //終了処理
            if (m_currentState != null) {
                m_currentState.OnExit();
                OnExitState?.Invoke();
            }
            
            m_currentStateType = type;
            m_currentState = m_states[type];
            
            //開始処理
            m_currentState.OnEnter();
            OnEnterState?.Invoke();
        }

        
        /// <summary>
        /// State追加
        /// </summary>
        /// <param name="type"></param>
        /// <param name="state"></param>
        public void AddState(TStateType type, TState state) {
            m_states.Add(type, state);
        }

        
        /// <summary>
        /// State削除
        /// </summary>
        /// <param name="type"></param>
        public void RemoveState(TStateType type) {
            m_states.Remove(type);
        }
    }
}