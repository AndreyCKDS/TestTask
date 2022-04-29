using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class ChatManager : MonoBehaviourPunCallbacks
{
    
    private PhotonView PhotonView;
    private int MaxMessages = 20;
    private List<ChatMessage> ChatMessages = new List<ChatMessage>();
    private TMP_InputField ChatInput;
    private GameObject ChatPanel;
    [SerializeField] private GameObject TextObject;
    [SerializeField] private Color PlayerColor, InfoColor;
    private string Nickname = "Player";
    private AudioSource AudioSource;

    private void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        PhotonView = GetComponent<PhotonView>();
        Nickname = PhotonView.Owner.NickName;
        ChatInput = GameObject.FindWithTag("ChatInput").GetComponent<TMP_InputField>();
        ChatPanel = GameObject.FindWithTag("ChatPanel");
        SendMessage(Nickname + " has joined", ChatMessage.MessageType.Info);
    }

    void Update()
    {
        if (ChatInput.text != "")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                PhotonView.RPC("SendMessage", RpcTarget.All, Nickname + ":  " + ChatInput.text, ChatMessage.MessageType.Player);
                ChatInput.text = "";
                ChatInput.ActivateInputField();
            }
        }
    }
    
    [PunRPC]
    public void SendMessage(string text, ChatMessage.MessageType Type)
    {
        if (ChatMessages.Count >= MaxMessages)
        {
            Destroy(ChatMessages[0].TextObject.gameObject);
            ChatMessages.Remove(ChatMessages[0]);
        }

        ChatMessage NewMassage = new ChatMessage();
        NewMassage.Text = text;
        GameObject NewText = Instantiate(TextObject, ChatPanel.transform);

        NewMassage.TextObject = NewText.GetComponent<TMP_Text>();
        NewMassage.TextObject.text = NewMassage.Text;
        NewMassage.TextObject.color = MessageTypeColor(Type);

        ChatMessages.Add(NewMassage);
        AudioSource.Play();
    }

    Color MessageTypeColor(ChatMessage.MessageType Type)
    {
        Color TypeColor = InfoColor;
        switch(Type)
        {
            case ChatMessage.MessageType.Player:
                TypeColor = PlayerColor;
                break;
                
        }
        Debug.Log("he");
        return TypeColor;
    }
}

[System.Serializable]
public class ChatMessage
{
    public string Text;
    public TMP_Text TextObject;
    public MessageType Type;
    public enum MessageType
    {
        Player,
        Info
    }
}
