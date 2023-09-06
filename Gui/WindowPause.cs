public class WindowPause : Window
{
    public void ContinueGame()
    {
        GameManager.instance.UnPause();
        Close();
    }

    public void Options()
    {
        SceneMaster.instance.Options();
    }
}
