using System.Linq;
using UnityEngine;

public class PlayerCollisionDetector : MonoBehaviour{
    [SerializeField] private float m_downRayLength = 1.0f;
    [SerializeField] private float m_sideRayLength = 1.0f;
    [SerializeField] private LayerMask m_layerMask;
    [SerializeField] private string[] m_groundTags = {"Ground"};
    [SerializeField] private string[] m_wallTags = {"Ground"};

    /// <summary>
    /// 地面との接触判定
    /// </summary>
    /// <returns></returns>
    public bool IsHitGround(){
        var rays = new Ray2D[3];
        var ts = transform;
        var pos = ts.position;
        for (int i = 0; i < 3; i++) {
            var originpos = new Vector2(pos.x + (i-1) * ts.localScale.x / 2.0f, pos.y);
            rays[i] = new Ray2D(originpos, Vector2.down);
            Debug.DrawRay(rays[i].origin, rays[i].direction * m_downRayLength, Color.red, 0.4f);
            var hit = Physics2D.Raycast(rays[i].origin, rays[i].direction, m_downRayLength, m_layerMask);

            if (hit.collider != null) {
                if (m_groundTags.Any(tag => hit.collider.gameObject.CompareTag(tag))) {
                    return true;
                }
            }
        }
        return false;
    }
    
    /// <summary>
    /// 壁との接触判定
    /// </summary>
    /// <returns></returns>
    public bool IsHitWall(){
        var rays = new Ray2D[3];
        var ts = transform;
        var pos = ts.position;
        var localScale = ts.localScale;
        for (int i = 1; i < 2; i++) {
            var originpos = new Vector2(pos.x, pos.y + (i-1) * localScale.y / 2.0f);
            var forwardVec = (ts.right * localScale.x).normalized;
            rays[i] = new Ray2D(originpos, forwardVec);
            Debug.DrawRay(rays[i].origin, rays[i].direction * m_downRayLength, Color.blue, 0.4f);
            var hit = Physics2D.Raycast(rays[i].origin, rays[i].direction, m_sideRayLength, m_layerMask);

            if (hit.collider != null) {
                if (m_wallTags.Any(tag => hit.collider.gameObject.CompareTag(tag))) {
                    return true;
                }
            }
        }
        return false;
    }
}
