using Godot;

public class EnemyTank : Tank
{

    public Node Parent;
    public PathFollow2D Path;
    
    public override void _Ready()
    {
        Parent = GetParent();
    }

    public override void _PhysicsProcess(float delta)
    {
        base._PhysicsProcess(delta);
        Control(delta);
        MoveAndSlide(Velocity);
    }

    public new void Control(float delta)
    {
        if (Parent.Name == "PathFollow2D")
        {
            Path = (PathFollow2D) GetParent();
            Path.SetOffset(Path.GetOffset() + Speed * delta);
        }
    }
    
}