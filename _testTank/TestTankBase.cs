using Godot;

public class TestTankBase : KinematicBody2D
{
    [Signal]
    delegate void shoot();

    [Export] private PackedScene Bullet;
    [Export] public int Speed;

    public Timer GunTimer;
    public Vector2 Velocity;
    
    
    public override void _Ready()
    {
//        GunTimer = (Timer) GetNode("Timer");
//        GunTimer.WaitTime = 3;
//        GD.Print("Start");
//        GunTimer.Start();
    }

    public override void _Process(float delta)
    {
           
    }

    public void Control(float delta)
    {
    }

    public override void _PhysicsProcess(float delta)
    {
        Control(delta);
        MoveAndSlide(Velocity);
    }

    public void ShootGun(Position2D muzzle)
    {    
        GD.Print("Fired");
        var dir = new Vector2(1, 0).Rotated(muzzle.GlobalRotation);
        EmitSignal("shoot", Bullet, muzzle.GlobalPosition, dir);
    }
    
//    private void _on_TestTank_shoot(PackedScene bullet, Vector2 _position, Vector2 _direction)
//    {
//        Bullet b = (Bullet) bullet.Instance();
//        AddChild(b);
//        b.Start(_position, _direction);
//    }
    

}