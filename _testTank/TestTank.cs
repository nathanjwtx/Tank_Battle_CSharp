using System;
using Godot;

public class TestTank : TestTankBase
{
    private void _on_Timer_timeout()
    {
        Position2D muzzle = (Position2D) GetNode("Body/Muzzle");
        ShootGun(muzzle);
        GunTimer.Start();
    }
}



