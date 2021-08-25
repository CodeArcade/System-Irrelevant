namespace Bliss.States.GameOver
{
    public partial class MenuState : State
    {
        public static string Name = "GameOver";

        protected override void OnLoad(params object[] parameter)
        {
            AudioManager.ChangeSong(ContentManager.UpbeatSong, true);
        }
    }
}
