namespace greatnet8hack.ApiService
{
    public class OpenAiResponse
    {
        public string id { get; set; }
        public string _object { get; set; }
        public int created { get; set; }
        public string model { get; set; }
        public Prompt_Filter_Results[] prompt_filter_results { get; set; }
        public Choice[] choices { get; set; }
        public Usage usage { get; set; }
    }

    public class Usage
    {
        public int prompt_tokens { get; set; }
        public int completion_tokens { get; set; }
        public int total_tokens { get; set; }
    }

    public class Prompt_Filter_Results
    {
        public int prompt_index { get; set; }
        public Content_Filter_Results content_filter_results { get; set; }
    }

    public class Content_Filter_Results
    {
        public Hate hate { get; set; }
        public Self_Harm self_harm { get; set; }
        public Sexual sexual { get; set; }
        public Violence violence { get; set; }
    }

    public class Hate
    {
        public bool filtered { get; set; }
        public string severity { get; set; }
    }

    public class Self_Harm
    {
        public bool filtered { get; set; }
        public string severity { get; set; }
    }

    public class Sexual
    {
        public bool filtered { get; set; }
        public string severity { get; set; }
    }

    public class Violence
    {
        public bool filtered { get; set; }
        public string severity { get; set; }
    }

    public class Choice
    {
        public int index { get; set; }
        public string finish_reason { get; set; }
        public Message message { get; set; }
        public Content_Filter_Results1 content_filter_results { get; set; }
    }

    public class Message
    {
        public string role { get; set; }
        public string content { get; set; }
    }

    public class Content_Filter_Results1
    {
        public Hate1 hate { get; set; }
        public Self_Harm1 self_harm { get; set; }
        public Sexual1 sexual { get; set; }
        public Violence1 violence { get; set; }
    }

    public class Hate1
    {
        public bool filtered { get; set; }
        public string severity { get; set; }
    }

    public class Self_Harm1
    {
        public bool filtered { get; set; }
        public string severity { get; set; }
    }

    public class Sexual1
    {
        public bool filtered { get; set; }
        public string severity { get; set; }
    }

    public class Violence1
    {
        public bool filtered { get; set; }
        public string severity { get; set; }
    }
}
