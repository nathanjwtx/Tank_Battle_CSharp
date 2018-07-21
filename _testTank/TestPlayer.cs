using Godot;

public class TestPlayer : TestTankBase
{
    public override void _PhysicsProcess(float delta)
    {
        base._PhysicsProcess(delta);
        Control(delta);
        MoveAndSlide(Velocity);
    }
    
    public new void Control(float delta)
    {
        const float speed = 120;
        const int rotationSpeed = 10;
        var rotDir = 0;
//        Turret = (Sprite) GetNode("Turret");
//        Turret.LookAt(GetGlobalMousePosition());
        if (Input.IsActionPressed("turn_right"))
        {
            rotDir += 1;
        }

        if (Input.IsActionPressed("turn_left"))
        {
            rotDir -= 1;
        }

        Rotation += rotationSpeed * rotDir * delta;
        
        // this line resets the vector and is v important. Needed because Velocity is declared at instance level
        Velocity = Vector2.Zero;
        if (Input.IsActionPressed("forward"))
        {
            Velocity = new Vector2(speed, 0).Rotated(Rotation);
        }

        if (Input.IsActionPressed("back"))
        {
            // ReSharper disable once PossibleLossOfFraction
            Velocity = new Vector2(-speed/2, 0).Rotated(Rotation);
        }

//        if (Input.IsActionJustPressed("shoot"))
//        {
//            GD.Print("click");
//            ShootGun();
    }
}