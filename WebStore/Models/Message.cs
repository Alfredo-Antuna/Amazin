using System.Text.Json.Serialization;

namespace WebStore
{
    public class Message
    {
        public int Id { get; set; }
        [JsonIgnore]
        public User FromUser { get; set; }
        [JsonIgnore]
        public User ToUser { get; set; }
        public string Text { get; set; }

        public Message() { }
        public Message(MessageDto messageDto)
        {
            Text = messageDto.Text;
        }
    }
}
