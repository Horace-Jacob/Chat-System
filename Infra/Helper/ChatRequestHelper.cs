using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Infra.Helper
{
	public static class ChatRequestHelper
	{
		public static async Task<List<tbChat>> GetSpecificChatData(int fromuserid, int touserid)
		{
			var url = string.Format("api/chat/getspecificchatdata?fromuserid={0}&touserid={1}", fromuserid, touserid);
			var result = await ApiRequest<List<tbChat>>.GetRequest(url.route(Request.chatappapi));
			return result;
		}

		public static async Task<tbChat> InsertChatData(string message, int fromuserid, int touserid)
		{
			var url = string.Format("api/chat/insertchatdata?message={0}&fromuserid={1}&touserid={2}", message, fromuserid, touserid);
			var result = await ApiRequest<tbChat>.GetRequest(url.route(Request.chatappapi));
			return result;
		}

		public static async Task<tbChat> InsertChat(tbChat chat)
		{
			var url = string.Format("api/chat/insertchat");
			var result = await ApiRequest<tbChat>.PostRequest(url.route(Request.chatappapi), chat);
			return result;
		}
	}
}
