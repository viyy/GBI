namespace Geekbrains
{
    public class PlayerController : BaseController<PlayerModel>, IFixedUpdatable
    {
        public float HorizontalAxis { get; set; }
        public float VerticalAxis { get; set; }
        public float MouseXAxis { get; set; }
        public float MouseYAxis { get; set; }

        private PlayerEventArgs _playerEventArgs;
        private PlayerView _view;

        public PlayerController(PlayerModel player, PlayerView view) : base(player)
        {
            _view = view;
            AddEventListener<PlayerEventArgs>(_view);
        }

        public void OnFixedUpdate(float deltaTime)
        {
            Dispatch(deltaTime);
        }

        private void Dispatch(float deltaTime)
        {
            _playerEventArgs = new PlayerEventArgs(HorizontalAxis, VerticalAxis, MouseXAxis, MouseYAxis, deltaTime);
            DispatchEvent(_playerEventArgs);
        }
    }
}
