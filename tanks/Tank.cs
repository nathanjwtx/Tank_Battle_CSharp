using Godot;
using System;

public class Tank : KinematicBody2D
{
    [Signal]
    delegate void HealthChanged();

    [Signal]
    delegate void dead();

    [Signal]
    delegate void shoot();
    
    [Export] public PackedScene Bullet;
    [Export] public int Speed = 50;
    [Export] public float RotationSpeed = 10;
    [Export] public float GunCoolDown = 1;
    [Export] public int Health = 0;

    public Timer GunTimer;
    public Vector2 Velocity;
    public bool Alive;
    public bool CanShoot = true;
    
    public override void _Ready()
    {
        GunTimer = (Timer) GetNode("EnemyTank/GunTimer");
        GunTimer.WaitTime = GunCoolDown;
    }

    public override void _PhysicsProcess(float delta)
    {
        Control(delta);
        MoveAndSlide(Velocity);
    }

    public void Control(float delta)
    {
        
    }

    public void Shoot()
    {
        if (CanShoot)
        {
            GD.Print("boom");
            CanShoot = false;
//            GunTimer = (Timer) GetNode("GunTimer");
            GD.Print("Shooting");
            GunTimer.Start();
            GD.Print(GunTimer.WaitTime);
            Sprite turret = (Sprite) GetNode("Turret");
            Position2D muzzle = (Position2D) turret.GetNode("Muzzle");
            Vector2 dir = new Vector2(1, 0).Rotated(turret.GlobalRotation);
            EmitSignal("shoot", Bullet, muzzle.GlobalPosition, dir);
        }
    }
    
    private void _on_EnemyGunTimer_timeout()
    {
        GD.Print("doogan");
        CanShoot = true;
    }
}

