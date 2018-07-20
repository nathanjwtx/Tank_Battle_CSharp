using System;
using Godot;

public class TestTank : TestTankBase
{

    public Node Parent;
    public PathFollow2D Path;

    public override void _Ready()
    {
        Parent = GetParent();
        GunTimer = (Timer) GetNode("Timer");
        GunTimer.Start();
    }

    public override void _PhysicsProcess(float delta)
    {
        base._PhysicsProcess(delta);
        Control(delta);
        MoveAndSlide(Velocity);
    }

    public new void Control(float delta)
    {
        if (Parent.Name == "PathFollow2D")
        {
            Path = (PathFollow2D) GetParent();
            Path.SetOffset(Path.GetOffset() + Speed * delta);
            Position = new Vector2();
        }
    }
    
    private void _on_Timer_timeout()
    {
        GD.Print("fire");
        Position2D muzzle = (Position2D) GetNode("Body/Muzzle");
        ShootGun(muzzle);
        GunTimer.Start();
    }
}
