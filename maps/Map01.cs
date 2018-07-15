using Godot;
using System;

public class Map01 : Node2D
{
    public TileMap Ground;
    public Camera2D PlayerCamera2D;

    public override void _Ready()
    {
        SetCameraLimits();
    }

    public void SetCameraLimits()
    {
        Ground = (TileMap) GetNode("Map01/Ground");
        PlayerCamera2D = (Camera2D) GetNode("Player/Turret/Camera2D");
        var mapLimits = Ground.GetUsedRect();
        var cellSize = Ground.CellSize;
        PlayerCamera2D.LimitLeft = Convert.ToInt32(mapLimits.Position.x * cellSize.x);
        PlayerCamera2D.LimitLeft = Convert.ToInt32(mapLimits.Position.x * cellSize.x);
        PlayerCamera2D.LimitLeft = Convert.ToInt32(mapLimits.Position.x * cellSize.x);
        PlayerCamera2D.LimitLeft = Convert.ToInt32(mapLimits.Position.x * cellSize.x);
    }

//    public override void _Process(float delta)
//    {
//        // Called every frame. Delta is time since last frame.
//        // Update game logic here.
//        
//    }
}
