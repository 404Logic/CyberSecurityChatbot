using System;
using System.Media;
using System.Threading;

class Program
{
    static string userName = "";

    static void Main()
    {
        // Play voice greeting
        PlayVoiceGreeting();

        // Display ASCII art logo
        DisplayLogo();

        // Get user's name
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("Please enter your name: ");
        Console.ResetColor();
        userName = Console.ReadLine();

        // Validate name input
        while (string.IsNullOrWhiteSpace(userName))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Name cannot be empty. Please try again.");
            Console.ResetColor();
            Console.Write("Please enter your name: ");
            userName = Console.ReadLine();
        }

        // Personalised welcome
        DisplayDivider();
        TypeEffect($"Welcome, {userName}! I'm your Cybersecurity Awareness Assistant.");
        TypeEffect("I'm here to help you stay safe online.\n");
        TypeEffect("You can ask me about: passwords, phishing, malware, safe browsing, and more.");
        TypeEffect("Type 'exit' to quit.\n");
        DisplayDivider();

        Chatbot bot = new Chatbot(userName);

        // Main conversation loop
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"\n{userName}: ");
            Console.ResetColor();
            string input = Console.ReadLine() ?? "";

            // Input validation
            if (string.IsNullOrWhiteSpace(input))
            {
                BotResponse("Please type something so I can help you!");
                continue;
            }

            input = input.ToLower().Trim();

            if (input == "exit")
            {
                BotResponse($"Goodbye, {userName}! Stay safe online!");
                break;
            }

            string response = bot.GetResponse(input);
            BotResponse(response);
        }
    }

    static void PlayVoiceGreeting()
    {
        try
        {
            // Make sure greeting.wav is in your project folder
            // Set its properties: Copy to Output Directory = "Copy always"
            SoundPlayer player = new SoundPlayer("greeting.wav");
            player.Play();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("(Audio greeting could not be played: " + ex.Message + ")");
            Console.ResetColor();
        }
    }

    static void DisplayLogo()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(@"
  ╔══════════════════════════════════════════════════╗
  ║                                                  ║
  ║        ░█▀▀░█░█░█▀▄░█▀▀░█▀▄░█▀▄░█▀█░▀█▀        ║
  ║        ░█░░░░█░░█▀▄░█▀▀░█▀▄░█▀▄░█░█░░█░        ║
  ║        ░▀▀▀░░▀░░▀▀░░▀▀▀░▀░▀░▀▀░░▀▀▀░░▀░        ║
  ║                                                  ║
  ║           🔒 CYBERSECURITY AWARENESS BOT 🔒      ║
  ║          Protecting You in the Digital World      ║
  ║                                                  ║
  ╚══════════════════════════════════════════════════╝
        ");
        Console.ResetColor();
    }

    static void DisplayDivider()
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("══════════════════════════════════════════════════");
        Console.ResetColor();
    }

    static void TypeEffect(string message)
    {
        Console.ForegroundColor = ConsoleColor.White;
        foreach (char c in message)
        {
            Console.Write(c);
            Thread.Sleep(20);
        }
        Console.WriteLine();
        Console.ResetColor();
    }

    static void BotResponse(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Bot: ");
        Console.ResetColor();
        TypeEffect(message);
    }
}