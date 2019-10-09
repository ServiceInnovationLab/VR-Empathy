﻿using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum MessageTimeFormat
{
    TimeSinceSend,
    TimeSent,
    None
}

public class ScreenMessage : MonoBehaviour
{
    public string from;
    public string fromTag;
    public string message;
    public Sprite profilePicture;
    public Sprite image;
    public bool sent = true;
    public bool moveFromTime = true;
    public bool highlight;
    public bool flash;
    public AnimatedImage animatedImage;

    [SerializeField] protected MessageTimeFormat timeFormat = MessageTimeFormat.TimeSinceSend;
    [SerializeField] protected bool showFromTag = true;
    [SerializeField] protected OnlineProfile profile;
    
    [SerializeField] protected Image profilePictureImage;
    [SerializeField] protected Image imageDisplay;
    [SerializeField] protected float moveLeftIfNoImage = 0;
    [SerializeField] protected bool imageAffectsHeight = true;
    [SerializeField] protected bool limitImageAdjustment = false;
    [SerializeField] protected float highlightAlpha = 0.2f;
    [SerializeField] protected Image highlightImage;
    [SerializeField] bool textCentered = false;
    [SerializeField] protected RectTransform textBackground;
    [SerializeField] AnimatedImageDisplay animatedImageDisplay;

    [SerializeField] protected Text messageText;
    [SerializeField] protected Text fromTime;
    [SerializeField] protected Text fromPersonText;

    [SerializeField] protected TextMeshProUGUI messageTextPro;

    float time = 0;
    protected RectTransform rectTransform;

    public Text MessageTextField
    {
        get { return messageText; }
    }

    public TextMeshProUGUI MessageTextFieldPro
    {
        get { return messageTextPro; }
    }

    public Text UsernameTextField
    {
        get { return fromPersonText; }
    }

    public Text TagAndTimeTextField
    {
        get { return fromTime; }
    }

    public RectTransform TextBackground
    {
        get { return textBackground; }
    }

    protected virtual void Awake()
    {
        rectTransform = ((RectTransform)transform);

        if (profile)
        {
            from = profile.username;
            profilePicture = profile.picture;
            fromTag = profile.tag;
        }

        if (animatedImageDisplay && animatedImage)
        {
            animatedImageDisplay.animatedImage = animatedImage;
            animatedImageDisplay.enabled = true;
        }

        if (fromPersonText)
        {
            fromPersonText.text = from;
        }

        if (messageText)
        {
            messageText.text = message;
        }

        if (messageTextPro)
        {
            messageTextPro.text = message;
        }

        if (profilePictureImage)
        {
            profilePictureImage.sprite = profilePicture;
        }

        if (fromTime && showFromTag)
        {
            fromTime.text = fromTag;

            if (timeFormat == MessageTimeFormat.None && sent)
            {
                enabled = false;
            }
        }

        if (fromTime && sent && timeFormat == MessageTimeFormat.TimeSent)
        {
            fromTime.text = "4 Aug, 2:38 PM";
            enabled = false;
        }


        if (!fromTime)
        {
            enabled = false;
        }

        if (imageDisplay)
        {
            if (image)
            {
                imageDisplay.sprite = image;
            }
            else if (!(animatedImageDisplay && animatedImage))
            {
                if (imageAffectsHeight)
                {
                    var heightAdjustment = imageDisplay.rectTransform.rect.height;

                    if (limitImageAdjustment && textBackground)
                    {
                        float textHeight = Mathf.Max(Mathf.Abs(textBackground.rect.yMin), Mathf.Abs(textBackground.rect.yMax));

                        if (rectTransform.rect.height - heightAdjustment < textHeight)
                        {
                            heightAdjustment = rectTransform.rect.height - textHeight - 80;

                            if (heightAdjustment < 0)
                            {
                                heightAdjustment = 0;
                            }
                        }
                    }

                    rectTransform.sizeDelta -= new Vector2(0, heightAdjustment);

                    if (textCentered)
                    {
                        messageText.rectTransform.anchoredPosition -= new Vector2(0, heightAdjustment);
                    }
                }

                imageDisplay.gameObject.SetActive(false);

                if (!Mathf.Approximately(moveLeftIfNoImage, 0))
                {
                    rectTransform.SetLeft(moveLeftIfNoImage);
                }
            }
        }

        if (highlight)
        {
            if (!highlightImage)
            {
                highlightImage = GetComponent<Image>();
            }

            if (highlightImage)
            {
                var newColour = highlightImage.color;
                newColour.a = highlightAlpha;
                highlightImage.color = newColour;
            }
        }

        if (flash)
        {
            var script = GetComponent<FlashingImage>();
            if (script)
            {
                script.enabled = true;
            }
        }
    }

    private void OnEnable()
    {
        Awake();
    }

    protected virtual void FixedUpdate()
    {
        if (!sent)
            return;

        time += Time.deltaTime;

        if (time < 1)
        {
            fromTime.text = fromTag + " - < 1s";
        }
        else
        {
            int seconds = Mathf.FloorToInt(time);
            int minutes = seconds / 60;

            if (minutes > 0)
            {
                fromTime.text = fromTag + " - " + minutes + "m";
            }
            else
            {
                fromTime.text = fromTag + " - " + seconds + "s";
            }
        }
    }

    public void Send(InputField input)
    {
        transform.Find("Icons").gameObject.SetActive(true);
        messageText.text = input.text;
        input.gameObject.SetActive(false);

        messageText.gameObject.SetActive(true);

        sent = true;
    }
}