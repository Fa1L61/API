using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new TelegramBotClient("5644166395:AAEDMd035mHBIsgeNGodDgIL3X2SOoSD5Jw");
            client.StartReceiving(Update, Error);
            Console.ReadLine();
        }

        private static Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
        {
            throw new NotImplementedException();
        }

        async static Task Update(ITelegramBotClient botClient, Update update, CancellationToken token)
        {
            var message = update.Message;
         
            Console.WriteLine($"{message.Text} {message.Chat.Username} ({message.Chat.FirstName})");
            
            if(message.Text != null)
            {
                if (message.Text.ToLower().Contains("привет"))
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Здорова, заебал") ;
                    return; 
                }
                else
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "И чо и чо?");
                    return;
                }
                    
            }
           
        }

       
    }
}
