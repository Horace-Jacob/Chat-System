using ChatApi.Services.ChatService;
using Microsoft.AspNetCore.Mvc;
using Data.Models;
using Microsoft.AspNetCore.SignalR;
using ChatApi.Hub;

namespace ChatApi.Controllers
{
	public class ChatController : Controller
	{
		private IHubContext<ChatHub, IChatHub> _chatContext;
		IChat _iChat;
		public ChatController(IChat iChat, IHubContext<ChatHub, IChatHub> chatContext)
		{
			_iChat = iChat;
			_chatContext = chatContext;
		}

		[HttpGet("api/chat/getspecificchatdata")]
		public List<tbChat> GetSpecificChatData(int fromuserid, int touserid) 
		{ 
			return this._iChat.GetSpecificChatData(fromuserid, touserid);
		}

		[HttpGet("api/chat/insertchatdata")]
		public async Task<tbChat> InsertChatData(string message, int fromUserId, int toUserId)
		{
			
			await _chatContext.Clients.All.SendMessage(message, fromUserId, toUserId);
			return await this._iChat.InsertChatData(message, fromUserId, toUserId);
		}

		[HttpPost("api/chat/insertchat")]
		public async Task<tbChat> InsertChat(tbChat chat)
		{
			var message = chat.message;
			var fromUserId = chat.fromUserId; 
			var toUserId = chat.toUserId;
			await _chatContext.Clients.All.SendMessage(message, fromUserId, toUserId);
			return await this._iChat.InsertChat(chat);
		}
	}
}
