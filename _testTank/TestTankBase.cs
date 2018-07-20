using Godot;

public class TestTankBase : KinematicBody2D
{
    [Signal]
    delegate void shoot();

    [Export] private PackedScene Bullet;

    public Timer GunTimer;
    
    public override void _Ready()
    {
        GunTimer = (Timer) GetNode("Timer");
        GunTimer.WaitTime = 3;
        GunTimer.Start();
    }

    public override void _Process(float delta)
    {
           
    }

    public void ShootGun(Position2D muzzle)
    {    
        var dir = new Vector2(1, 0).Rotated(muzzle.GlobalRotation);
        EmitSignal("shoot", Bullet, muzzle.GlobalPosition, dir);
    }
    
    private void _on_TestTank_shoot(PackedScene bullet, Vector2 _position, Vector2 _direction)
    {
        Bullet b = (Bullet) bullet.Instance();
        AddChild(b);
        b.Start(_position, _direction);
    }
    

}