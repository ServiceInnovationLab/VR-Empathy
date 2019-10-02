﻿using UnityEngine;

public enum SocialMediaScenarioTextType
{
    Sender,
    Receiver,
    Friend
}

public enum SocialMediaScenatioMessageFeedType
{
    None,
    Default,
    Sender,
    Receiver,
    PileOn,
    Messenger,
    FourChan
}

public enum SocialMediaScenarioSMStype
{
    Initial,
    Support
}

[CreateAssetMenu(menuName = "SocialMediaScenario")]
public class SocialMediaScenario : ScriptableObject
{
    public MessageFeed messageFeed;


    public MessageFeed receiverMessageFeed;

    public MessageFeed senderMessageFeed;

    public MessageFeed pileOnMessageFeed;

    public MessageFeed messengerFeed;

    public MessageFeed smsMessageFeed;

    public MessageFeed supportSmsMessageFeed;

    public MessageFeed fourChan;

    public OnlineProfile receiverProfile;

    public OnlineProfile senderProfile;

    public OnlineProfile friendProfile;

    public string senderMessage;

    public string receiverMessage;

    public string friendMessage;

    public string GetText(SocialMediaScenarioTextType type)
    {
        switch (type)
        {
            case SocialMediaScenarioTextType.Receiver:
                return receiverMessage;

            case SocialMediaScenarioTextType.Sender:
                return senderMessage;

            case SocialMediaScenarioTextType.Friend:
                return friendMessage;
        }

        return "Unknown type";
    }

    public MessageFeed GetMessageFeed(SocialMediaScenatioMessageFeedType type)
    {
        switch (type)
        {
            case SocialMediaScenatioMessageFeedType.Sender:
                return senderMessageFeed;

            case SocialMediaScenatioMessageFeedType.Receiver:
                return receiverMessageFeed;

            case SocialMediaScenatioMessageFeedType.PileOn:
                return pileOnMessageFeed;

            case SocialMediaScenatioMessageFeedType.Messenger:
                return messengerFeed;

            case SocialMediaScenatioMessageFeedType.FourChan:
                return fourChan;
        }

        return null;
    }

    public OnlineProfile GetProfile(SocialMediaScenarioTextType type)
    {
        switch (type)
        {
            case SocialMediaScenarioTextType.Sender:
                return senderProfile;

            case SocialMediaScenarioTextType.Receiver:
                return receiverProfile;

            case SocialMediaScenarioTextType.Friend:
                return friendProfile;
            default:
                return null;
        }
    }

    public MessageFeed GetSMSMessageFeed(SocialMediaScenarioSMStype type)
    {
        switch (type)
        {
            case SocialMediaScenarioSMStype.Initial:
                return smsMessageFeed;

            case SocialMediaScenarioSMStype.Support:
                return supportSmsMessageFeed;
        }

        return null;
    }
}
