namespace _Project.CodeBase.Controllers.AI
{
    public class BotShootingController : ShootingController
    {
        private void FixedUpdate()
        {
            base.Update();

            if (CanShoot())
            {
                Shoot();
                CurrentTime = 0;
            }
        }

        protected override bool CanShoot() => 
            CurrentTime >= DelayBeforeShoot;
    }
}