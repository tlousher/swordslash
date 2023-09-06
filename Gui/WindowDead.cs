public class WindowDead : Window
{
    public void RestartGame()
    {
        SceneMaster.instance.RestartScene();
        Close();
    }
}
