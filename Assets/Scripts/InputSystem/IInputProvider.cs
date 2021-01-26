public interface IInputProvider{
    float HorizontalInput { get; } 
    float VerticalInput { get; }
    bool IsJump { get; }
    bool IsJumpHolding { get; }
    bool IsRushAttack { get; }
    bool EnableInput { get; set; }
}