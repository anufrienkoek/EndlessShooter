namespace _Project.CodeBase.Controllers.AI
{
    public class BotShootingController : ShootingController
    {
        protected override bool CanShoot() => 
            TimeSinceLastShot >= ShootCooldown;
    }
}