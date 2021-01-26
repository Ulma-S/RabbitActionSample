using System.Collections.Generic;
using Ulma.Util;
using Unity.Mathematics;
using UnityEngine;

public class EffectManager : SingletonMonoBehaviour<EffectManager> {
    public enum EffectID{
        Explosion,
        Hit,
        SmokePuff,
    }

    [System.Serializable]
    private class EffectData{
        public EffectID ID = EffectID.Explosion;
        public GameObject EffectObj = null;
    }

    [SerializeField] private List<EffectData> m_effectDatas = new List<EffectData>();

    /// <summary>
    /// Effect再生
    /// </summary>
    /// <param name="_id">Effect ID</param>
    /// <param name="_pos">再生場所</param>
    public void PlayEffect(EffectID _id, Vector3 _pos){
        var data = m_effectDatas.Find(dt => dt.ID == _id);
        if (data == null) {
            Debug.LogError(_id + " object isn't registered.");
        }
        Instantiate(data.EffectObj, _pos, quaternion.identity);
    }
}
