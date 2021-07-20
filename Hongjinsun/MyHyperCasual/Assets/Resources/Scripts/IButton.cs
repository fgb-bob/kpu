
public interface IButton
{
    public enum BTN { playBTN, quitBTN, resumeBTN };

    public void OnClick(BTN btn);
}
