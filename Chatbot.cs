using System;

public class Chatbot
{
    private string userName = "";

    // Auto-implemented properties
    public string BotName { get; set; } = "CyberBot";
    public string BotVersion { get; set; } = "1.0";

    public Chatbot(string name)
    {
        userName = name;
    }

    public string GetResponse(string input)
    {
        // General conversation
        if (input.Contains("how are you"))
            return "I'm just a bot, but I'm running smoothly! How can I help you stay safe online?";

        if (input.Contains("what's your purpose") || input.Contains("what is your purpose"))
            return $"I'm {BotName}, designed to help people like you, {userName}, learn about cybersecurity and stay safe online.";

        if (input.Contains("what can i ask") || input.Contains("help"))
            return "You can ask me about:\n  • Password safety\n  • Phishing scams\n  • Malware protection\n  • Safe browsing\n  • Social engineering\n  • Two-factor authentication";

        // Cybersecurity topics
        if (input.Contains("password"))
            return $"Great question, {userName}! Use strong passwords with uppercase, lowercase, numbers, and symbols. Never reuse passwords across accounts.";

        if (input.Contains("phishing"))
            return "Phishing scams try to trick you into giving personal information. Always verify the sender before clicking links in emails or messages.";

        if (input.Contains("malware") || input.Contains("virus"))
            return "Malware is harmful software that can damage your device. Install reputable antivirus software and avoid downloading files from untrusted sources.";

        if (input.Contains("safe browsing") || input.Contains("https"))
            return "Always check for HTTPS in the URL and look for the padlock icon. Avoid clicking on suspicious links or pop-ups.";

        if (input.Contains("social engineering"))
            return "Social engineering tricks people into revealing confidential information. Be cautious of unexpected requests, even from people you think you know.";

        if (input.Contains("two-factor") || input.Contains("2fa") || input.Contains("authentication"))
            return "Two-factor authentication adds an extra layer of security. Even if someone gets your password, they can't access your account without the second factor.";

        if (input.Contains("scam"))
            return $"Stay alert, {userName}! Scammers often create urgency to pressure you. Take your time and verify before acting on any suspicious message.";

        if (input.Contains("privacy"))
            return "Protect your privacy by reviewing app permissions, using strong passwords, and being careful about what you share on social media.";

        // Default response
        return $"I didn't quite understand that, {userName}. Could you rephrase? You can ask me about passwords, phishing, malware, safe browsing, or type 'help' for a full list.";
    }
}