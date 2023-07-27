using Data.Models;

namespace ChatApi.Services.ChatService
{
	public interface IChat
	{
		List<tbChat> GetSpecificChatData(int fromuserid, int touserid);
		Task<tbChat> InsertChatData(string message, int fromuserid, int touserid);
		Task<tbChat> InsertChat(tbChat chat);
	}
}
