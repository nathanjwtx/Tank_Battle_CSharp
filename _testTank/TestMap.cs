using Godot;
using System;

public class TestMap : Node2D
{
    public TileMap Ground;
    public Camera2D Camera2D;

    public override void _Ready()
    {

    }

//	public void _on_TestTank_shoot(PackedScene bullet, Vector2 _position, Vector2 _direction)
//	{
//	    GD.Print("boom boom");
//		Bullet b = (Bullet) bullet.Instance();
//		AddChild(b);
//		b.Start(_position, _direction);
//	}
}
