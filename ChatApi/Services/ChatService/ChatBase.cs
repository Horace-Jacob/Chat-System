using Core.Extensions;
using Data.Models;
using Infra.UnitOfWork;

namespace ChatApi.Services.ChatService
{
	public class ChatBase : IChat
	{
		private DatabaseContext _dbContext;
		UnitOfWork _unitOfWork;

		public ChatBase(DatabaseContext dbContext)
		{
			_dbContext = dbContext;
			this._unitOfWork = new UnitOfWork(_dbContext);
		}

		public List<tbChat> GetSpecificChatData(int fromuserid, int touserid)
		{
			return _unitOfWork.ChatRepo.GetAll().Where(c => c.fromUserId == fromuserid && c.toUserId == touserid || c.fromUserId == touserid && c.toUserId == fromuserid).OrderBy(x => x.accesstime).ToList();
		}

		public async Task<tbChat> InsertChatData(string message, int fromuserid, int touserid)
		{
			tbChat chat = new tbChat();
			chat.message = message;
			chat.fromUserId = fromuserid;
			chat.toUserId = touserid;
			chat.accesstime = MyExtensions.getLocalTime();
			chat = await _unitOfWork.ChatRepo.InsertReturnAsync(chat);
			return chat;
		}

		public async Task<tbChat> InsertChat(tbChat chat)
		{
			chat.accesstime = MyExtensions.getLocalTime();
			chat = await _unitOfWork.ChatRepo.InsertReturnAsync(chat);
			return chat;
		}
	}
}
