using _Project.CodeBase.Inputs;

namespace _Project.CodeBase.Controllers.Player
{
    public class PlayerShootingController : ShootingController
    {
        private PlayerInputRouter _playerInputRouter;

        private void Awake()
        {
            _playerInputRouter = new PlayerInputRouter();
            _playerInputRouter.OnEnable();
            _playerInputRouter.Initialize();
        }

        protected override void Update()
        {
            base.Update();

            if (CanShoot())
            {
                Shoot();
                CurrentTime = 0;
            }
        }

        protected override bool CanShoot() =>
            _playerInputRouter.IsFireButtonPressed() && CurrentTime >= DelayBeforeShoot;
    }
}