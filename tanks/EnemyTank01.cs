using Godot;

public class EnemyTank01 : Tank
{

    [Export] public float TurretSpeed = 1;
    [Export] public int DetectRadius;
    
    public Node Parent;
    public PathFollow2D Path;
    public Sprite EnemyTurret;
//    public Timer EnemyGunTimer;
    public KinematicBody2D Target;
    
    public override void _Ready()
    {
//        EnemyGunTimer = (Timer) GetNode("GunTimer");
//        EnemyGunTimer.WaitTime = GunCoolDown;
//        EnemyGunTimer.Start();
        Parent = GetParent();
        EnemyTurret = (Sprite) GetNode("Turret");
        var circle = new CircleShape2D();
        circle.Radius = DetectRadius;
        var detectRadius = (CollisionShape2D) GetNode("DetectRadius/CollisionShape2D");
        detectRadius.Shape = circle;
    }

    public override void _PhysicsProcess(float delta)
    {
        base._PhysicsProcess(delta);
        Control(delta);
        MoveAndSlide(Velocity);
    }

    public override void _Process(float delta)
    {
        base._Process(delta);
//        EnemyGunTimer = (Timer) GetNode("GunTimer");
//        EnemyGunTimer.WaitTime = GunCoolDown;
//        GD.Print(EnemyGunTimer.WaitTime);
        GD.Print("Enemy boom");
//        EnemyGunTimer.Start();
        Shoot();
//        CanShoot = false;
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

//    private void _on_EnemyGunTimer_timeout()
//    {
//        GD.Print("Times up");
//    }
}
