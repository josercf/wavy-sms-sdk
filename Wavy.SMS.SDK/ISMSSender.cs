using System.Threading.Tasks;

namespace Wavy.SMS.SDK
{
    public interface ISMSSender
    {
        /// <summary>
        /// Send a text message
        /// </summary>
        /// <param name="phoneNumber">Phone number with DDI, DDD and phone number</param>
        /// <param name="message">Text message</param>
        /// <returns>Id from message sent</returns>
        Task<string> Send(string phoneNumber, string message);
    }
}
