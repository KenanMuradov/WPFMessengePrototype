using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NLipsum;
using Bogus;
using WPFMessengePrototype.Models;

namespace WPFMessengePrototype;
public partial class MainWindow : Window
{
    private static Faker _myFaker = new Faker();

    public string CompanionAvatar { get; set; } = _myFaker.Person.Avatar;
    public string CompanionName { get; set; } = _myFaker.Person.UserName;


    public List<Message> Messages { get; set; }
    public List<string> AnswerWords = FakeData.FakeDatas.LoremIpsum.Replace('\n',' ').Split(' ').ToList();

    public MainWindow()
    {
        InitializeComponent();

        DataContext = this;

        Messages = new();
    }

    private async void btnSend_Click(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtMessage.Text))
            return;

        listViewMessages.ItemsSource = null;
        Messages.Add(new Message("You", txtMessage.Text));
        listViewMessages.ItemsSource = Messages;

        int messageSize = txtMessage.Text.Split(' ').Length;

        txtMessage.Text = string.Empty;

        StringBuilder sb = new();

        for (int i = 0; i < messageSize; i++)
            sb.Append($"{_myFaker.Lorem.Word()} ");

        lblTyping.Visibility= Visibility.Visible;

        await Task.Run(()=>{

            Thread.Sleep(messageSize * 700); 

            Messages.Add(new Message(CompanionName, sb.ToString()));
        }
        );

        lblTyping.Visibility = Visibility.Hidden;


        listViewMessages.ItemsSource = null;
        listViewMessages.ItemsSource = Messages;

    }

    private void txtMessage_KeyDown(object sender, KeyEventArgs e)
    {
        if(e.Key == Key.Enter)
        btnSend_Click(sender, e);
    }

    private void Button_Click(object sender, RoutedEventArgs e) => MessageBox.Show("Will be Updated Soon", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
}
