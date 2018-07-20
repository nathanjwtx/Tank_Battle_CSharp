using Godot;

public class EnemyTank : Tank
{

    [Export] public float TurretSpeed = 1;
    [Export] public int DetectRadius;
    
    public Node Parent;
    public PathFollow2D Path;
    public Sprite EnemyTurret;
    public Timer EnemyGunTimer;
    public KinematicBody2D Target;
    
    public override void _Ready()
    {
        EnemyGunTimer = (Timer) GetNode("GunTimer");
        EnemyGunTimer.WaitTime = GunCoolDown;
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
        if (Target != null)
        {
            Vector2 targetDirection = (Target.GlobalPosition - GlobalPosition).Normalized();
            Vector2 currentDirection = new Vector2(1, 0).Rotated(EnemyTurret.GlobalRotation);
            EnemyTurret.GlobalRotation =
                currentDirection.LinearInterpolate(targetDirection, TurretSpeed * delta).Angle();
            if (targetDirection.Dot(currentDirection) > 0.9)
            {
                GD.Print("Enemy boom");
                Shoot();
                CanShoot = false;
                EnemyGunTimer.Start();
            }
        }
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
    
    private void _on_DetectRadius_body_entered(Object body)
    {
        if (body is KinematicBody2D player)
        {
            if (player.Name == "Player")
            {
                Target = player;
            }
        }
    }

    private void _on_DetectRadius_body_exited(Object body)
    {
        if (body == Target)
        {
            Target = null;
        }
    }
    
    private void _on_GunTimer_timeout()
    {
        CanShoot = true;
    }
}
