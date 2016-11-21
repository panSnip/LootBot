using Discord;
using Discord.Commands;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LootBot
{
    class MyBot
    {
        DiscordClient discord;
        CommandService commands;

        Random rand;

        string[] shareMemes;
        string[] randomQuote;

        public MyBot()
        {
            rand = new Random();

            // Pictures/memes to pull for "!meme" 
            shareMemes = new string[]
            {
                "Pictures/meme1.png",
                "Pictures/meme2.png",
                "Pictures/meme3.png",
                "Pictures/meme4.jpg",
                "Pictures/meme5.png",
                "Pictures/meme6.jpg",
                "Pictures/meme7.png",
                "Pictures/meme8.jpg",
                "Pictures/meme9.jpg",
                "Pictures/meme10.jpg",
                "Pictures/meme11.jpg",
                "Pictures/meme12.jpg",
                "Pictures/meme13.jpg",
                "Pictures/meme14.jpg",
                "Pictures/meme15.jpg",
                "Pictures/meme16.jpg",
                "Pictures/meme17.jpg",
                "Pictures/meme18.jpg",
                "Pictures/meme19.jpg",
                "Pictures/meme20.jpg",
                "Pictures/meme21.png",
                "Pictures/meme22.png",
                "Pictures/meme23.jpg",
                "Pictures/meme24.png",
                "Pictures/meme25.png",
                "Pictures/meme26.jpg",
                "Pictures/meme27.png",
                "Pictures/meme28.jpg",
                "Pictures/meme29.png",
                "Pictures/meme30.jpg",
                "Pictures/meme31.jpg",
                "Pictures/meme32.jpg",
                "Pictures/meme33.png",
                "Pictures/meme34.jpg",
                "Pictures/meme35.jpg",
                "Pictures/meme36.jpg",
                "Pictures/meme37.jpg",
                "Pictures/meme38.jpg",
                "Pictures/meme39.jpg",
                "Pictures/meme40.png",
                "Pictures/meme41.png",
                "Pictures/meme42.png",
                "Pictures/meme43.jpg",
                "Pictures/meme44.jpg",
                "Pictures/meme45.jpg"
            };

            // Quotes to pull for "!quote"
            randomQuote = new string[]
            {
                "'Fear is a place where you just tell the truth.'\n-Clive Barker",
                "'Wasted youth is better by far the a wise and productive old age.'\n-Meatloaf",
                "'Seek the truth, no matter where it lies.',\n-Metallica",
                "'The foolish man think with narrow mind and speak with wide mouth.'\n-Charlie Chin",
                "'There is no knowledge that is not power.'\n-Mortal Kombat 3",
                "'We've got far too many hung juries and not enough hung defendants.'\n-Dennis Miller",
                "'Conservatives want live babies so they can raise them to be dead soldiers.'\n-George Carlin'",
                "'The strength of the Constitution lies entirely in the determination of each citizen to defend it.'\n-Albert Einstein",
                "'Any plan, no matter how poorly conceived, if boldly executed, is better than inaction.'\n-U.S. Infantry Manual"
            };

            discord = new DiscordClient(x =>
            {
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = Log;
            });

            discord.UsingCommands(x =>
            {
                x.PrefixChar = '!';
                x.AllowMentionPrefix = true;
            });

            commands = discord.GetService<CommandService>();

            // Command runs on entry of "hello" and replies with "Hi!"
            commands.CreateCommand("hello")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("Hi!");
                });

            // Commmand runs on entry of "!meme" and displays a random meme from the "Pictures" folder
            RegisterPictureCommand();

            // Command runs on entry of "!quote" and replies with a random quote from the array "randomQuote"
            RegisterQuoteCommand();

            // Mass deletes/purges messages from the chat
            RegisterPurgeCommand();

            discord.ExecuteAndWait(async () =>
            {
                await discord.Connect("MjUwMjY4Mzc2Njc5NTc5NjQ4.CxScQg.Ff1HBP8pQ-35Y1q1JIq0oz2OUzY", TokenType.Bot);
            });
        }

        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.Write(e.Message);
        }

        private void RegisterPictureCommand()
        {
            commands.CreateCommand("meme")
                .Do(async (e) =>
                {
                    int randomIndex = rand.Next(shareMemes.Length);
                    string pictureToPost = shareMemes[randomIndex];
                    await e.Channel.SendFile(pictureToPost);
                });
        }

        private void RegisterQuoteCommand()
        {
            commands.CreateCommand("quote")
                .Do(async (e) =>
                {
                    int randomIndex = rand.Next(randomQuote.Length);
                    string pictureToPost = shareMemes[randomIndex];
                    await e.Channel.SendMessage(pictureToPost);
                });
        }

        private void RegisterPurgeCommand()
        {
            commands.CreateCommand("purge")
                .Do(async (e) =>
                {
                    Message[] messagesToDelete;
                    messagesToDelete = await e.Channel.DownloadMessages(100);

                    await e.Channel.DeleteMessages(messagesToDelete);
                });
        }
    }
}
