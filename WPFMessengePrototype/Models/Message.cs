using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFMessengePrototype.Models;

public class Message
{
    public string? Sender { get; set; }
    public string? Text { get; set; }
    public DateTime SendDate { get; set; }
    public int AppearanceAlignment { get; set; }


    public Message() => SendDate = DateTime.Now;

    public Message(string sender, string text, int appearanceAlignment = 1)
        : this()
    {
        Sender = sender;
        Text = text;
        AppearanceAlignment = appearanceAlignment;
    }

}
