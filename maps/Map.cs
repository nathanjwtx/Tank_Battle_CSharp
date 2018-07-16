using Godot;
using System;

public class Map : Node2D
{
    public TileMap Ground;
    public Camera2D Camera2D;

    public override void _Ready()
    {
        SetCameraLimits();

    }

    public void SetCameraLimits()
    {
        var grnd = (TileMap) GetNode("Ground");
        var camera = (Camera2D) GetNode("Player/Camera2D");
        var mapLimits = grnd.GetUsedRect();
        var mapCellsize = grnd.CellSize;
        camera.LimitLeft = Convert.ToInt32(mapLimits.Position.x * mapCellsize.x);
        camera.LimitRight = Convert.ToInt32(mapLimits.End.x * mapCellsize.x);
        camera.LimitTop = Convert.ToInt32(mapLimits.Position.y * mapCellsize.y);
        camera.LimitBottom = Convert.ToInt32(mapLimits.End.y * mapCellsize.y);
    }

	public void _on_Tank_shoot(PackedScene bullet, Vector2 _position, Vector2 _direction)
	{
	    GD.Print("boom boom");
		Bullet b = (Bullet) bullet.Instance();
		AddChild(b);
		b.Start(_position, _direction);
	}
}



