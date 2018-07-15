using Godot;
using System;

public class Tank : KinematicBody2D
{
    [Export] public PackedScene Bullet;
    [Export] public int Speed = 50;
    [Export] public float RotationSpeed = 10;
    [Export] public float GunCoolDown = 10;
    [Export] public int Health = 0;

    public Timer GunTimer;
    public Vector2 Velocity;
    public bool Alive;
    
    public override void _Ready()
    {
        GunTimer = (Timer) GetNode("GunTimer");
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
}