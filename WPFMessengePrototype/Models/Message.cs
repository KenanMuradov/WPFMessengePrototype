using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFMessengePrototype.Models;

public class Message
{
    public string? SenderName { get; set; }
    public string? Text { get; set; }
    public DateTime SendDate { get; set; }


    public Message() => SendDate = DateTime.Now;

    public Message(string senderName, string text)
        : this()
    {
        SenderName = senderName;
        Text = text;
    }

}
