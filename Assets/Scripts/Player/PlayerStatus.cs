using UnityEngine;

[CreateAssetMenu(menuName = "MyAssets/Player")]
public class PlayerStatus : ScriptableObject{
    public float MoveSpeed = 10.0f;
    public float JumpSpeed = 8.0f;
    public float MaxJumpTime = 1.0f;

    public float WallJumpSpeed = 10.0f;
    public Vector2 WallJumpDir = new Vector2(1.0f, 1.5f);

    public float GravityScale = 0.1f;
    
    /// <summary>
    /// Max:1.0f, Min:0.0f
    /// </summary>
    public float AirResistanceScale = 0.5f;

    public float MaxWallStayTime = 2.0f;
    
    //-------Attack-------
    public float RushAttackForce = 20.0f;
    public float MaxRushAttackTime = 2.0f;
}
