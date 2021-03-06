using Godot;
using System;

public class Bullet : Area2D
{
    [Export] public int Speed;
    [Export] public int Damage;
    [Export] public float Lifetime;

    public Vector2 Velocity;
    public Timer _timer;

    public override void _Ready()
    {
        _timer = (Timer) GetNode("Lifetime");
        GD.Print(Speed);
    }

    public void Start(Vector2 _position, Vector2 _direction)
    {
        Position = _position;
        Rotation = _direction.Angle();
        _timer.WaitTime = Lifetime;
        GD.Print(_timer.WaitTime);
        _timer.Start();
        Velocity = _direction * Speed;
        GD.Print(Velocity);
    }

    public override void _Process(float delta)
    {
        Position += Velocity * delta;
    }

    public void Explode()
    {
        QueueFree();
    }
    
    private void _on_Bullet_body_entered(Godot.Object body)
    {
        var target = body as Node2D; 
        Explode();
        if (target != null && target.HasMethod("take_damage"))
        {
//            target.take_damage(Damage);
        }
    }

    private void _on_Lifetime_timeout()
    {
        GD.Print("Bang");
        Explode();
    }
}
