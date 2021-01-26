using Ulma.Util;
using UnityEngine;

public class KeyboardInputProvider : SingletonMonoBehaviour<KeyboardInputProvider>, IInputProvider {
    public float HorizontalInput { get; private set; }
    public float VerticalInput { get; private set; }
    public bool IsJump { get; private set; }
    public bool IsJumpHolding { get; private set; }
    public bool IsRushAttack { get; private set; }
    public bool EnableInput { get; set; } = true;

    private void Update(){
        if (EnableInput) {
            HorizontalInput = Input.GetAxisRaw("Horizontal");
            VerticalInput = Input.GetAxisRaw("Vertical");
            IsJump = Input.GetButtonDown("Jump");
            IsJumpHolding = Input.GetButton("Jump");
            
            IsRushAttack = Input.GetButtonDown("Fire1");
        }
        else {
            HorizontalInput = 0.0f;
            VerticalInput = 0.0f;
            IsJump = false;
            IsJumpHolding = false;
            
            IsRushAttack = false;
        }
    }
}
