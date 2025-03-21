using UnityEngine;

public class ButtonSizeLoader : MonoBehaviour
{
    public RectTransform leftButton, rightButton, downButton, jumpButton;
    private Vector2 defaultSizeLeft, defaultSizeRight, defaultSizeDown, defaultSizeJump;

    void Start()
    {
        defaultSizeLeft = leftButton.sizeDelta;
        defaultSizeRight = rightButton.sizeDelta;
        defaultSizeDown = downButton.sizeDelta;
        defaultSizeJump = jumpButton.sizeDelta;

        LoadChanges();
    }

    void LoadChanges()
    {
        float leftSizeMultiplier = PlayerPrefs.GetFloat("LeftButtonSize", 1f);
        float rightSizeMultiplier = PlayerPrefs.GetFloat("RightButtonSize", 1f);
        float downSizeMultiplier = PlayerPrefs.GetFloat("DownButtonSize", 1f);
        float jumpSizeMultiplier = PlayerPrefs.GetFloat("JumpButtonSize", 1f);

        leftButton.sizeDelta = defaultSizeLeft * leftSizeMultiplier;
        rightButton.sizeDelta = defaultSizeRight * rightSizeMultiplier;
        downButton.sizeDelta = defaultSizeDown * downSizeMultiplier;
        jumpButton.sizeDelta = defaultSizeJump * jumpSizeMultiplier;

        leftButton.anchoredPosition = new Vector2(PlayerPrefs.GetFloat("LeftPosX", leftButton.anchoredPosition.x), PlayerPrefs.GetFloat("LeftPosY", leftButton.anchoredPosition.y));
        rightButton.anchoredPosition = new Vector2(PlayerPrefs.GetFloat("RightPosX", rightButton.anchoredPosition.x), PlayerPrefs.GetFloat("RightPosY", rightButton.anchoredPosition.y));
        downButton.anchoredPosition = new Vector2(PlayerPrefs.GetFloat("DownPosX", downButton.anchoredPosition.x), PlayerPrefs.GetFloat("DownPosY", downButton.anchoredPosition.y));
        jumpButton.anchoredPosition = new Vector2(PlayerPrefs.GetFloat("JumpPosX", jumpButton.anchoredPosition.x), PlayerPrefs.GetFloat("JumpPosY", jumpButton.anchoredPosition.y));
    }
}
