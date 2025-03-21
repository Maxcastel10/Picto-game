using UnityEngine;
using UnityEngine.UI;

public class CustomHUDLayout : MonoBehaviour
{
    public RectTransform leftButton, rightButton, downButton, jumpButton;
    public Slider leftSizeSlider, rightSizeSlider, downSizeSlider, jumpSizeSlider;
    public Button saveButton, resetButton;

    private Vector2 defaultSizeLeft, defaultSizeRight, defaultSizeDown, defaultSizeJump;
    private Vector2 defaultLeftPos, defaultRightPos, defaultDownPos, defaultJumpPos;

    void Start()
    {
        // Store Default Sizes
        defaultSizeLeft = leftButton.sizeDelta;
        defaultSizeRight = rightButton.sizeDelta;
        defaultSizeDown = downButton.sizeDelta;
        defaultSizeJump = jumpButton.sizeDelta;

        // Store Default Positions
        defaultLeftPos = leftButton.anchoredPosition;
        defaultRightPos = rightButton.anchoredPosition;
        defaultDownPos = downButton.anchoredPosition;
        defaultJumpPos = jumpButton.anchoredPosition;

        // Attach Slider Listeners
        leftSizeSlider.onValueChanged.AddListener(value => UpdateSize(leftButton, defaultSizeLeft, value));
        rightSizeSlider.onValueChanged.AddListener(value => UpdateSize(rightButton, defaultSizeRight, value));
        downSizeSlider.onValueChanged.AddListener(value => UpdateSize(downButton, defaultSizeDown, value));
        jumpSizeSlider.onValueChanged.AddListener(value => UpdateSize(jumpButton, defaultSizeJump, value));

        // Attach Button Listeners
        saveButton.onClick.AddListener(SaveChanges);
        resetButton.onClick.AddListener(ResetChanges);

        // Load previous settings
        LoadChanges();
    }

    void UpdateSize(RectTransform button, Vector2 defaultSize, float value)
    {
        button.sizeDelta = defaultSize * value;
    }

    void SaveChanges()
    {
        PlayerPrefs.SetFloat("LeftButtonSize", leftSizeSlider.value);
        PlayerPrefs.SetFloat("RightButtonSize", rightSizeSlider.value);
        PlayerPrefs.SetFloat("DownButtonSize", downSizeSlider.value);
        PlayerPrefs.SetFloat("JumpButtonSize", jumpSizeSlider.value);

        PlayerPrefs.SetFloat("LeftPosX", leftButton.anchoredPosition.x);
        PlayerPrefs.SetFloat("LeftPosY", leftButton.anchoredPosition.y);
        PlayerPrefs.SetFloat("RightPosX", rightButton.anchoredPosition.x);
        PlayerPrefs.SetFloat("RightPosY", rightButton.anchoredPosition.y);
        PlayerPrefs.SetFloat("DownPosX", downButton.anchoredPosition.x);
        PlayerPrefs.SetFloat("DownPosY", downButton.anchoredPosition.y);
        PlayerPrefs.SetFloat("JumpPosX", jumpButton.anchoredPosition.x);
        PlayerPrefs.SetFloat("JumpPosY", jumpButton.anchoredPosition.y);

        PlayerPrefs.Save();
    }

    void LoadChanges()
    {
        leftSizeSlider.value = PlayerPrefs.GetFloat("LeftButtonSize", 1f);
        rightSizeSlider.value = PlayerPrefs.GetFloat("RightButtonSize", 1f);
        downSizeSlider.value = PlayerPrefs.GetFloat("DownButtonSize", 1f);
        jumpSizeSlider.value = PlayerPrefs.GetFloat("JumpButtonSize", 1f);

        UpdateSize(leftButton, defaultSizeLeft, leftSizeSlider.value);
        UpdateSize(rightButton, defaultSizeRight, rightSizeSlider.value);
        UpdateSize(downButton, defaultSizeDown, downSizeSlider.value);
        UpdateSize(jumpButton, defaultSizeJump, jumpSizeSlider.value);

        leftButton.anchoredPosition = new Vector2(PlayerPrefs.GetFloat("LeftPosX", defaultLeftPos.x), PlayerPrefs.GetFloat("LeftPosY", defaultLeftPos.y));
        rightButton.anchoredPosition = new Vector2(PlayerPrefs.GetFloat("RightPosX", defaultRightPos.x), PlayerPrefs.GetFloat("RightPosY", defaultRightPos.y));
        downButton.anchoredPosition = new Vector2(PlayerPrefs.GetFloat("DownPosX", defaultDownPos.x), PlayerPrefs.GetFloat("DownPosY", defaultDownPos.y));
        jumpButton.anchoredPosition = new Vector2(PlayerPrefs.GetFloat("JumpPosX", defaultJumpPos.x), PlayerPrefs.GetFloat("JumpPosY", defaultJumpPos.y));
    }

    void ResetChanges()
    {
        leftSizeSlider.value = 1f;
        rightSizeSlider.value = 1f;
        downSizeSlider.value = 1f;
        jumpSizeSlider.value = 1f;

        UpdateSize(leftButton, defaultSizeLeft, 1f);
        UpdateSize(rightButton, defaultSizeRight, 1f);
        UpdateSize(downButton, defaultSizeDown, 1f);
        UpdateSize(jumpButton, defaultSizeJump, 1f);

        leftButton.anchoredPosition = defaultLeftPos;
        rightButton.anchoredPosition = defaultRightPos;
        downButton.anchoredPosition = defaultDownPos;
        jumpButton.anchoredPosition = defaultJumpPos;

        SaveChanges();
    }
}
