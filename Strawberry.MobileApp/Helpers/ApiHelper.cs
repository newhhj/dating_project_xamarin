using Newtonsoft.Json;
using Strawberry.MobileApp.DataModels;
using Strawberry.MobileApp.Pages.Option;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static Strawberry.MobileApp.Pages.Profile.ProfilePage_Dialog_AlertSelector;

namespace Strawberry.MobileApp.Helpers
{
    public class ApiHelper : IDisposable
    {
		private HttpClient Http { get; set; }

		public ApiHelper()
		{
			// HttpClient 인스턴스 생성 및 기본 주소 설정
			this.Http = new HttpClient
			{
				BaseAddress = new Uri(Settings.ServerUrl)
			};
		}

		// 추천 파트너 정보를 가져오는 메서드
		public async Task<T> GetRecommandPartners<T>(int datatype, int skipcount, T returnType)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");
				formData.Add(new StringContent(datatype.ToString()), "datatype");
				formData.Add(new StringContent(skipcount.ToString()), "skipcount");

				using (var res = await this.Http.PostAsync("/Main/GetRecommandPartners", formData))
				{
					return await GetContentString(res, returnType);
				}
			}
		}

		// 파트너 프로필을 가져오는 메서드
		public async Task<T> GetPartnerProfile<T>(int partnerId, T returnType)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");
				formData.Add(new StringContent(partnerId.ToString()), "partnerId");

				using (var res = await this.Http.PostAsync("/Main/GetPartnerProfile", formData))
				{
					return await GetContentString(res, returnType);
				}
			}
		}

		// 무료 공개 파트너 프로필을 가져오는 메서드
		public async Task<T> GetFreeViewPartnerProfile<T>(int partnerId, T returnType)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");
				formData.Add(new StringContent(partnerId.ToString()), "partnerId");

				using (var res = await this.Http.PostAsync("/Main/GetFreeViewPartnerProfile", formData))
				{
					return await GetContentString(res, returnType);
				}
			}
		}

		// 파트너 프로필에 대한 추가 정보를 가져오는 메서드
		public async Task<T> GetAppealOnPartnerProfile<T>(int id, int skipCount, T returnType)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");
				formData.Add(new StringContent(id.ToString()), "id");
				formData.Add(new StringContent(skipCount.ToString()), "skipCount");

				using (var res = await this.Http.PostAsync("/Main/GetAppealOnPartnerProfile", formData))
				{
					return await GetContentString(res, returnType);
				}
			}
		}

		// 파트너 선택을 수행하는 메서드
		public async Task<T> ExcuteChoice<T>(int partnerId, T returnType)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");
				formData.Add(new StringContent(partnerId.ToString()), "partnerId");

				using (var res = await this.Http.PostAsync("/Main/ExcuteChoice", formData))
				{
					return await GetContentString(res, returnType);
				}
			}
		}

		// 스마트 선택을 수행하는 메서드
		public async Task<T> ExcuteSmartChoice<T>(int partnerId, string message, T returnType)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");
				formData.Add(new StringContent(partnerId.ToString()), "partnerId");
				formData.Add(new StringContent(message), "message");

				using (var res = await this.Http.PostAsync("/Main/ExcuteSmartChoice", formData))
				{
					return await GetContentString(res, returnType);
				}
			}
		}

		// 파트너 프로필에 대한 알림을 수행하는 메서드
		public async Task ExcuteProfileAlert(int partnerId, int alertType, string alertMessage, bool isBlocked)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");
				formData.Add(new StringContent(partnerId.ToString()), "partnerId");
				formData.Add(new StringContent(alertType.ToString()), "alertType");
				if (!string.IsNullOrWhiteSpace(alertMessage))
					formData.Add(new StringContent(alertMessage), "alertMessage");
				formData.Add(new StringContent(isBlocked.ToString()), "isBlocked");

				using (var res = await this.Http.PostAsync("/Main/ExcuteProfileAlert", formData))
				{
					await GetContentString(res);
				}
			}
		}

		// 파트너 프로필 차단을 수행하는 메서드
		public async Task ExcuteProfileBlock(int partnerId)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");
				formData.Add(new StringContent(partnerId.ToString()), "partnerId");

				using (var res = await this.Http.PostAsync("/Main/ExcuteProfileBlock", formData))
				{
					await GetContentString(res);
				}
			}
		}

		// 포음폼 목록을 가져오는 메서드
		public async Task<T> GetPoomPooms<T>(Pages.Appeal.AppealPage_Data.ContentTypes contentType, int skipCount, T returnType)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");
				formData.Add(new StringContent(contentType.ToString()), "contentType");
				formData.Add(new StringContent(skipCount.ToString()), "skipCount");

				using (var res = await this.Http.PostAsync("/PoomPoom/GetPoomPooms", formData))
				{
					return await GetContentString(res, returnType);
				}
			}
		}

		// 특정 포음폼 정보를 가져오는 메서드
		public async Task<T> GetPoomPoom<T>(int contentId, T returnType)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");
				formData.Add(new StringContent(contentId.ToString()), "contentId");

				using (var res = await this.Http.PostAsync("/PoomPoom/GetPoomPoom", formData))
				{
					return await GetContentString(res, returnType);
				}
			}
		}

		// 포음폼을 등록하는 메서드
		public async Task ExcutePoomPoom(Pages.Appeal.AppealPage_Data.ContentTypes contentType, string content, string area, string time, bool useComment, params byte[][] imageBuffers)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");
				formData.Add(new StringContent(contentType.ToString()), "contentType");
				if (!string.IsNullOrWhiteSpace(content))
					formData.Add(new StringContent(content), "content");
				if (!string.IsNullOrWhiteSpace(area))
					formData.Add(new StringContent(area), "area");
				if (!string.IsNullOrWhiteSpace(time))
					formData.Add(new StringContent(time), "time");
				formData.Add(new StringContent(useComment.ToString()), "useComment");
				if (imageBuffers != null && imageBuffers.Length > 0)
				{
					foreach (var imageBuffer in imageBuffers)
						formData.Add(new ByteArrayContent(imageBuffer), "images", $"{Guid.NewGuid()}.jpg");
				}

				using (var res = await this.Http.PostAsync("/PoomPoom/ExcutePoomPoom", formData))
				{
					await GetContentString(res);
				}
			}
		}

		// 포음폼 좋아요를 수행하는 메서드
		public async Task<T> ExcutePoomPoomLike<T>(int contentId, T returnType)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");
				formData.Add(new StringContent(contentId.ToString()), "contentId");

				using (var res = await this.Http.PostAsync("/PoomPoom/ExcutePoomPoomLike", formData))
				{
					return await GetContentString(res, returnType);
				}
			}
		}

		// 포음폼에 댓글을 작성하는 메서드
		public async Task<T> ExcutePoomPoomComment<T>(int contentId, string comment, int? replyMemberId, T returnType)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");
				formData.Add(new StringContent(contentId.ToString()), "contentId");
				formData.Add(new StringContent(comment.ToString()), "comment");
				if (replyMemberId != null)
					formData.Add(new StringContent(replyMemberId.ToString()), "replyMemberId");

				using (var res = await this.Http.PostAsync("/PoomPoom/ExcutePoomPoomComment", formData))
				{
					return await GetContentString(res, returnType);
				}
			}
		}

		// 포음폼 알림을 수행하는 메서드
		public async Task ExcuteAlertPoomPoom(string title, string message, int poomPoomId, int alertMemberId)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");
				formData.Add(new StringContent(title.ToString()), "title");
				formData.Add(new StringContent(message.ToString()), "message");
				formData.Add(new StringContent(poomPoomId.ToString()), "poomPoomId");
				formData.Add(new StringContent(alertMemberId.ToString()), "alertMemberId");

				using (var res = await this.Http.PostAsync("/PoomPoom/ExcuteAlertPoomPoom", formData))
				{
					await GetContentString(res);
				}
			}
		}

		// 포음폼 댓글 알림을 수행하는 메서드
		public async Task ExcuteAlertPoomPoomComment(int alertCommentId, int alertMemberId, string title)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");
				formData.Add(new StringContent(alertCommentId.ToString()), "alertCommentId");
				formData.Add(new StringContent(alertMemberId.ToString()), "alertMemberId");
				formData.Add(new StringContent(title.ToString()), "title");

				using (var res = await this.Http.PostAsync("/PoomPoom/ExcuteAlertPoomPoomComment", formData))
				{
					await GetContentString(res);
				}
			}
		}

		// 포음폼 댓글을 삭제하는 메서드
		public async Task RemovePoomPoomComment(int commentId)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");
				formData.Add(new StringContent(commentId.ToString()), "commentId");

				using (var res = await this.Http.PostAsync("/PoomPoom/RemovePoomPoomComment", formData))
				{
					await GetContentString(res);
				}
			}
		}

		// 운세 파트너를 가져오는 메서드
		public async Task<T> GetFortunePartnet<T>(T returnType)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");

				using (var res = await this.Http.PostAsync("/Main/GetFortunePartnet", formData))
				{
					return await GetContentString(res, returnType);
				}
			}
		}

		// 근처 파트너를 가져오는 메서드
		public async Task<T> GetNearPartnets<T>(T returnType)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");

				using (var res = await this.Http.PostAsync("/Near/GetPartners", formData))
				{
					return await GetContentString(res, returnType);
				}
			}
		}

		public async Task<T> GetChoiceItems<T>(T returnType)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");

				using (var res = await this.Http.PostAsync("/Choice/GetItems", formData))
				{
					return await GetContentString(res, returnType);
				}
			}
		}

		/// <summary>
		/// 선택 항목을 가져오는 메서드입니다.
		/// </summary>
		/// <typeparam name="T">반환할 데이터의 형식을 지정하는 제네릭 매개변수입니다.</typeparam>
		/// <param name="returnType">반환할 데이터 형식을 지정합니다.</param>
		/// <returns>T 형식으로 지정된 선택 항목 데이터입니다.</returns>

		public async Task ExcuteChoiceConfirm(int id)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");
				formData.Add(new StringContent(id.ToString()), "id");

				using (var res = await this.Http.PostAsync("/Choice/ExcuteChoiceConfirm", formData))
				{
					await GetContentString(res);
				}
			}
		}

		/// <summary>
		/// 선택을 확인하는 메서드입니다.
		/// </summary>
		/// <param name="id">선택의 ID입니다.</param>

		public async Task ExcuteChoicePass(int id)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");
				formData.Add(new StringContent(id.ToString()), "id");

				using (var res = await this.Http.PostAsync("/Choice/ExcuteChoicePass", formData))
				{
					await GetContentString(res);
				}
			}
		}

		/// <summary>
		/// 선택을 거절하는 메서드입니다.
		/// </summary>
		/// <param name="id">선택의 ID입니다.</param>

		public async Task ExcuteStarPointPass(int id)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");
				formData.Add(new StringContent(id.ToString()), "id");

				using (var res = await this.Http.PostAsync("/Choice/ExcuteStarPointPass", formData))
				{
					await GetContentString(res);
				}
			}
		}

		/// <summary>
		/// 별점 거절을 수행하는 메서드입니다.
		/// </summary>
		/// <param name="id">선택의 ID입니다.</param>

		public async Task<T> ExcuteFeedbackChoice<T>(int id, int memberId, T returnType)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");
				formData.Add(new StringContent(id.ToString()), "id");
				formData.Add(new StringContent(memberId.ToString()), "memberId");

				using (var res = await this.Http.PostAsync("/Choice/ExcuteFeedbackChoice", formData))
				{
					return await GetContentString(res, returnType);
				}
			}
		}

		/// <summary>
		/// 선택 피드백을 수행하는 메서드입니다.
		/// </summary>
		/// <typeparam name="T">반환할 데이터의 형식을 지정하는 제네릭 매개변수입니다.</typeparam>
		/// <param name="id">선택의 ID입니다.</param>
		/// <param name="memberId">회원의 ID입니다.</param>
		/// <param name="returnType">반환할 데이터 형식을 지정합니다.</param>
		/// <returns>T 형식으로 지정된 피드백 결과 데이터입니다.</returns>

		public async Task RemoveMyStarPoint(int id)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");
				formData.Add(new StringContent(id.ToString()), "id");

				using (var res = await this.Http.PostAsync("/Choice/RemoveMyStarPoint", formData))
				{
					await GetContentString(res);
				}
			}
		}

		/// <summary>
		/// 별점을 제거하는 메서드입니다.
		/// </summary>
		/// <param name="id">별점의 ID입니다.</param>

		public async Task<T> ExcuteCreateChattingRoom<T>(int memberId, T returnType)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");
				formData.Add(new StringContent(memberId.ToString()), "partnerId");

				using (var res = await this.Http.PostAsync("/Chatting/ExcuteCreateChattingRoom", formData))
				{
					return await GetContentString(res, returnType);
				}
			}
		}

		/// <summary>
		/// 채팅방을 생성하는 메서드입니다.
		/// </summary>
		/// <typeparam name="T">반환할 데이터의 형식을 지정하는 제네릭 매개변수입니다.</typeparam>
		/// <param name="memberId">상대 회원의 ID입니다.</param>
		/// <param name="returnType">반환할 데이터 형식을 지정합니다.</param>
		/// <returns>T 형식으로 지정된 생성된 채팅방 데이터입니다.</returns>

		public async Task<T> GetChattingInfo<T>(int roomId, T returnType)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");
				formData.Add(new StringContent(roomId.ToString()), "roomId");

				using (var res = await this.Http.PostAsync("/Chatting/GetChattingInfo", formData))
				{
					return await GetContentString(res, returnType);
				}
			}
		}

		/// <summary>
		/// 채팅방 정보를 가져오는 메서드입니다.
		/// </summary>
		/// <typeparam name="T">반환할 데이터의 형식을 지정하는 제네릭 매개변수입니다.</typeparam>
		/// <param name="roomId">채팅방의 ID입니다.</param>
		/// <param name="returnType">반환할 데이터 형식을 지정합니다.</param>
		/// <returns>T 형식으로 지정된 채팅방 정보 데이터입니다.</returns>

		public async Task ExcuteOpenChatting(int id)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");
				formData.Add(new StringContent(id.ToString()), "id");

				using (var res = await this.Http.PostAsync("/Chatting/ExcuteOpenChatting", formData))
				{
					await GetContentString(res);
				}
			}
		}

		/// <summary>
		/// 채팅방을 열기 위해 실행하는 메서드입니다.
		/// </summary>
		/// <param name="id">채팅방의 ID입니다.</param>

		public async Task<T> ExcuteSendTextMessage<T>(int roomId, int partnerId, string message, T returnType)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");
				formData.Add(new StringContent(roomId.ToString()), "roomId");
				formData.Add(new StringContent(partnerId.ToString()), "partnerId");
				formData.Add(new StringContent(message), "message");

				using (var res = await this.Http.PostAsync("/Chatting/ExcuteSendTextMessage", formData))
				{
					return await GetContentString(res, returnType);
				}
			}
		}

		/// <summary>
		/// 채팅방에서 텍스트 메시지를 전송하는 메서드입니다.
		/// </summary>
		/// <typeparam name="T">반환할 데이터의 형식을 지정하는 제네릭 매개변수입니다.</typeparam>
		/// <param name="roomId">채팅방의 ID입니다.</param>
		/// <param name="partnerId">상대 회원의 ID입니다.</param>
		/// <param name="message">메시지 내용입니다.</param>
		/// <param name="returnType">반환할 데이터 형식을 지정합니다.</param>
		/// <returns>T 형식으로 지정된 메시지 전송 결과 데이터입니다.</returns>

		public async Task<T> ExcuteSendImageMessage<T>(int roomId, int partnerId, string filename, byte[] buffer, T returnType)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");
				formData.Add(new StringContent(roomId.ToString()), "roomId");
				formData.Add(new StringContent(partnerId.ToString()), "partnerId");
				formData.Add(new ByteArrayContent(buffer), "file", filename);

				using (var res = await this.Http.PostAsync("/Chatting/ExcuteSendImageMessage", formData))
				{
					return await GetContentString(res, returnType);
				}
			}
		}

		/// <summary>
		/// 채팅방에서 이미지 메시지를 전송하는 메서드입니다.
		/// </summary>
		/// <typeparam name="T">반환할 데이터의 형식을 지정하는 제네릭 매개변수입니다.</typeparam>
		/// <param name="roomId">채팅방의 ID입니다.</param>
		/// <param name="partnerId">상대 회원의 ID입니다.</param>
		/// <param name="filename">이미지의 파일명입니다.</param>
		/// <param name="buffer">이미지 데이터를 나타내는 바이트 배열입니다.</param>
		/// <param name="returnType">반환할 데이터 형식을 지정합니다.</param>
		/// <returns>T 형식으로 지정된 이미지 메시지 전송 결과 데이터입니다.</returns>

		public async Task<T> GetChattingRooms<T>(int skipCount, T returnType)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");
				formData.Add(new StringContent(skipCount.ToString()), "skipCount");

				using (var res = await this.Http.PostAsync("/Chatting/GetChattingRooms", formData))
				{
					return await GetContentString(res, returnType);
				}
			}
		}

		/// <summary>
		/// 채팅방 목록을 가져오는 메서드입니다.
		/// </summary>
		/// <typeparam name="T">반환할 데이터의 형식을 지정하는 제네릭 매개변수입니다.</typeparam>
		/// <param name="skipCount">건너뛸 항목 수입니다.</param>
		/// <param name="returnType">반환할 데이터 형식을 지정합니다.</param>
		/// <returns>T 형식으로 지정된 채팅방 목록 데이터입니다.</returns>

		public async Task ExcuteRemoveChattingRoom(int id)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");
				formData.Add(new StringContent(id.ToString()), "roomId");

				using (var res = await this.Http.PostAsync("/Chatting/ExcuteRemoveChattingRoom", formData))
				{
					await GetContentString(res);
				}
			}
		}

		/// <summary>
		/// 채팅방을 제거하는 메서드입니다.
		/// </summary>
		/// <param name="id">채팅방의 ID입니다.</param>

		public async Task ExcuteShowChattingMessage(int messageId)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");
				formData.Add(new StringContent(messageId.ToString()), "messageId");

				using (var res = await this.Http.PostAsync("/Chatting/ExcuteShowChattingMessage", formData))
				{
					await GetContentString(res);
				}
			}
		}

		/// <summary>
		/// 채팅 메시지를 표시하는 메서드입니다.
		/// </summary>
		/// <param name="messageId">메시지의 ID입니다.</param>

		public async Task ExcuteRoomStarPoint(int roomId, int starPoint)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");
				formData.Add(new StringContent(roomId.ToString()), "roomId");
				formData.Add(new StringContent(starPoint.ToString()), "starPoint");

				using (var res = await this.Http.PostAsync("/Chatting/ExcuteRoomStarPoint", formData))
				{
					await GetContentString(res);
				}
			}
		}

		/// <summary>
		/// 채팅방에 별점을 부여하는 메서드입니다.
		/// </summary>
		/// <param name="roomId">채팅방의 ID입니다.</param>
		/// <param name="starPoint">별점입니다.</param>

		public async Task ExcuteBlockAndRemoveChattingRoom(int id)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");
				formData.Add(new StringContent(id.ToString()), "roomId");

				using (var res = await this.Http.PostAsync("/Chatting/ExcuteBlockAndRemoveChattingRoom", formData))
				{
					await GetContentString(res);
				}
			}
		}

		/// <summary>
		/// 채팅방을 차단하고 제거하는 메서드입니다.
		/// </summary>
		/// <param name="id">채팅방의 ID입니다.</param>

		public async Task<T> GetOptionData<T>(T returnType)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");

				using (var res = await this.Http.PostAsync("/Option/GetOptionData", formData))
				{
					return await GetContentString(res, returnType);
				}
			}
		}

		/// <summary>
		/// 옵션 데이터를 가져오는 메서드입니다.
		/// </summary>
		/// <typeparam name="T">반환할 데이터의 형식을 지정하는 제네릭 매개변수입니다.</typeparam>
		/// <param name="returnType">반환할 데이터 형식을 지정합니다.</param>
		/// <returns>T 형식으로 지정된 옵션 데이터입니다.</returns>

		public async Task<T> GetSettingPageData<T>(T returnType)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");

				using (var res = await this.Http.PostAsync("/Option/GetSettingPageData", formData))
				{
					return await GetContentString(res, returnType);
				}
			}
		}

		/// <summary>
		/// 설정 페이지 데이터를 가져오는 메서드입니다.
		/// </summary>
		/// <typeparam name="T">반환할 데이터의 형식을 지정하는 제네릭 매개변수입니다.</typeparam>
		/// <param name="returnType">반환할 데이터 형식을 지정합니다.</param>
		/// <returns>T 형식으로 지정된 설정 페이지 데이터입니다.</returns>

		public async Task ExcuteToggleUseNotiRecommand(bool use)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");
				formData.Add(new StringContent(use.ToString()), "use");

				using (var res = await this.Http.PostAsync("/Option/ExcuteToggleUseNotiRecommand", formData))
				{
					await GetContentString(res);
				}
			}
		}

		/// <summary>
		/// 추천 알림 사용 여부를 전환하는 메서드입니다.
		/// </summary>
		/// <param name="use">사용 여부를 나타내는 값입니다.</param>

		public async Task ExcuteToggleUseNotiReceiveChoice(bool use)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");
				formData.Add(new StringContent(use.ToString()), "use");

				using (var res = await this.Http.PostAsync("/Option/ExcuteToggleUseNotiReceiveChoice", formData))
				{
					await GetContentString(res);
				}
			}
		}

		/// <summary>
		/// 선택 수신 알림 사용 여부를 전환하는 메서드입니다.
		/// </summary>
		/// <param name="use">사용 여부를 나타내는 값입니다.</param>

		public async Task ExcuteToggleUseNotiSendChoiceConfirm(bool use)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");
				formData.Add(new StringContent(use.ToString()), "use");

				using (var res = await this.Http.PostAsync("/Option/ExcuteToggleUseNotiSendChoiceConfirm", formData))
				{
					await GetContentString(res);
				}
			}
		}

		/// <summary>
		/// 선택 확인 알림 사용 여부를 전환하는 메서드입니다.
		/// </summary>
		/// <param name="use">사용 여부를 나타내는 값입니다.</param>

		public async Task ExcuteToggleUseNotiReceiveFavorite(bool use)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");
				formData.Add(new StringContent(use.ToString()), "use");

				using (var res = await this.Http.PostAsync("/Option/ExcuteToggleUseNotiReceiveFavorite", formData))
				{
					await GetContentString(res);
				}
			}
		}

		/// <summary>
		/// 즐겨찾기 수신 알림 사용 여부를 전환하는 메서드입니다.
		/// </summary>
		/// <param name="use">사용 여부를 나타내는 값입니다.</param>

		public async Task ExcuteToggleUseNotiConnect(bool use)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");
				formData.Add(new StringContent(use.ToString()), "use");

				using (var res = await this.Http.PostAsync("/Option/ExcuteToggleUseNotiConnect", formData))
				{
					await GetContentString(res);
				}
			}
		}

		/// <summary>
		/// 연결 알림 사용 여부를 전환하는 메서드입니다.
		/// </summary>
		/// <param name="use">사용 여부를 나타내는 값입니다.</param>

		public async Task ExcuteToggleUseNotiChattingMessage(bool use)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");
				formData.Add(new StringContent(use.ToString()), "use");

				using (var res = await this.Http.PostAsync("/Option/ExcuteToggleUseNotiChattingMessage", formData))
				{
					await GetContentString(res);
				}
			}
		}

		/// <summary>
		/// 채팅 메시지 알림 사용 여부를 전환하는 메서드입니다.
		/// </summary>
		/// <param name="use">사용 여부를 나타내는 값입니다.</param>

		public async Task ExcuteToggleUseNotiAppeal(bool use)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");
				formData.Add(new StringContent(use.ToString()), "use");

				using (var res = await this.Http.PostAsync("/Option/ExcuteToggleUseNotiAppeal", formData))
				{
					await GetContentString(res);
				}
			}
		}

		/// <summary>
		/// 항소 알림 사용 여부를 전환하는 메서드입니다.
		/// </summary>
		/// <param name="use">사용 여부를 나타내는 값입니다.</param>


		public async Task ExcuteToggleUseNotiMarketing(bool use)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");
				formData.Add(new StringContent(use.ToString()), "use");

				using (var res = await this.Http.PostAsync("/Option/ExcuteToggleUseNotiMarketing", formData))
				{
					await GetContentString(res);
				}
			}
		}

		/// <summary>
		/// 특정 반환 형식으로 프로필 레벨 페이지 데이터를 가져오는 메서드입니다.
		/// </summary>
		/// <typeparam name="T">반환할 데이터의 형식을 지정하는 제네릭 매개변수입니다.</typeparam>
		/// <param name="returnType">반환할 데이터 형식을 지정합니다.</param>
		/// <returns>T 형식으로 지정된 프로필 레벨 페이지 데이터입니다.</returns>
		public async Task<T> GetProfileLevelPageData<T>(T returnType)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");

				using (var res = await this.Http.PostAsync("/Option/GetProfileLevelPageData", formData))
				{
					return await GetContentString(res, returnType);
				}
			}
		}

		/// <summary>
		/// 멤버 레벨을 다시 확인하는 메서드입니다.
		/// </summary>
		public async Task ExcuteMemberLevelReCheck()
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");

				using (var res = await this.Http.PostAsync("/Option/ExcuteMemberLevelReCheck", formData))
				{
					await GetContentString(res);
				}
			}
		}

		/// <summary>
		/// 프로필 다시 확인 로그가 있는지 여부를 가져오는 메서드입니다.
		/// </summary>
		/// <typeparam name="T">반환할 데이터의 형식을 지정하는 제네릭 매개변수입니다.</typeparam>
		/// <param name="returnType">반환할 데이터 형식을 지정합니다.</param>
		/// <returns>T 형식으로 지정된 프로필 다시 확인 로그 데이터입니다.</returns>
		public async Task<T> GetHasProfileRecheckLog<T>(T returnType)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");

				using (var res = await this.Http.PostAsync("/Option/GetHasProfileRecheckLog", formData))
				{
					return await GetContentString(res, returnType);
				}
			}
		}

		/// <summary>
		/// 지정된 개수만큼의 포인트 로그 데이터를 가져오는 메서드입니다.
		/// </summary>
		/// <typeparam name="T">반환할 데이터의 형식을 지정하는 제네릭 매개변수입니다.</typeparam>
		/// <param name="skipCount">건너뛸 포인트 로그 개수를 지정합니다.</param>
		/// <param name="returnType">반환할 데이터 형식을 지정합니다.</param>
		/// <returns>T 형식으로 지정된 포인트 로그 데이터입니다.</returns>
		public async Task<T> GetPointLogs<T>(int skipCount, T returnType)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");
				formData.Add(new StringContent(skipCount.ToString()), "skipCount");

				using (var res = await this.Http.PostAsync("/Option/GetPointLogs", formData))
				{
					return await GetContentString(res, returnType);
				}
			}
		}

		/// <summary>
		/// 구매를 실행하고 결과를 반환하는 메서드입니다.
		/// </summary>
		/// <typeparam name="T">반환할 데이터의 형식을 지정하는 제네릭 매개변수입니다.</typeparam>
		/// <param name="platform">구매 플랫폼을 지정합니다.</param>
		/// <param name="productId">제품 ID를 지정합니다.</param>
		/// <param name="purchaseId">구매 ID를 지정합니다.</param>
		/// <param name="purchaseToken">구매 토큰을 지정합니다.</param>
		/// <param name="purchaseTime">구매 시간을 지정합니다.</param>
		/// <param name="returnType">반환할 데이터 형식을 지정합니다.</param>
		/// <returns>T 형식으로 지정된 구매 결과 데이터입니다.</returns>
		public async Task<T> ExcutePurchase<T>(string platform, string productId, string purchaseId, string purchaseToken, DateTime purchaseTime, T returnType)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");
				formData.Add(new StringContent(platform), "platform");
				formData.Add(new StringContent(productId), "productId");
				formData.Add(new StringContent(purchaseId), "purchaseId");
				formData.Add(new StringContent(purchaseToken), "purchaseToken");
				formData.Add(new StringContent(purchaseTime.ToString()), "purchaseTime");

				using (var res = await this.Http.PostAsync("/Authentication/ExcutePurchase", formData))
				{
					return await GetContentString(res, returnType);
				}
			}
		}

		/// <summary>
		/// 구매를 실행하고 결과를 처리하는 메서드입니다.
		/// </summary>
		/// <param name="platform">구매 플랫폼을 지정합니다.</param>
		/// <param name="productId">제품 ID를 지정합니다.</param>
		/// <param name="purchaseId">구매 ID를 지정합니다.</param>
		/// <param name="purchaseToken">구매 토큰을 지정합니다.</param>
		/// <param name="purchaseTime">구매 시간을 지정합니다.</param>
		public async Task ExcutePurchase(string platform, string productId, string purchaseId, string purchaseToken, DateTime purchaseTime)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");
				formData.Add(new StringContent(platform), "platform");
				formData.Add(new StringContent(productId), "productId");
				formData.Add(new StringContent(purchaseId), "purchaseId");
				formData.Add(new StringContent(purchaseToken), "purchaseToken");
				formData.Add(new StringContent(purchaseTime.ToString()), "purchaseTime");

				using (var res = await this.Http.PostAsync("/Authentication/ExcutePurchase", formData))
				{
					var result = await GetContentString(res, new
					{
						Point = default(int),
						FreeChoiceCount = default(int),
						FreeChattingCount = default(int),
						FreeChattingTime = default(DateTime?),
						FreeChoiceTime = default(DateTime?),
						FreeSmartChoiceTime = default(DateTime?),
						IsVIP = default(bool)
					});

					App.Instance.Member.Point = result.Point;
					App.Instance.Member.FreeChoiceCount = result.FreeChoiceCount;
					App.Instance.Member.FreeChattingCount = result.FreeChattingCount;
					App.Instance.Member.FreeChattingTime = result.FreeChattingTime;
					App.Instance.Member.FreeChoiceTime = result.FreeChoiceTime;
					App.Instance.Member.FreeSmartChoiceTime = result.FreeSmartChoiceTime;
					App.Instance.Member.IsVIP = result.IsVIP;
				}
			}
		}

		/// <summary>
		/// 로열 센터 요청 페이지 데이터를 가져오는 메서드입니다.
		/// </summary>
		/// <typeparam name="T">반환할 데이터의 형식을 지정하는 제네릭 매개변수입니다.</typeparam>
		/// <param name="returnType">반환할 데이터 형식을 지정합니다.</param>
		/// <returns>T 형식으로 지정된 로열 센터 요청 페이지 데이터입니다.</returns>
		public async Task<T> GetRoyalCenterRequestPageData<T>(T returnType)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");

				using (var res = await this.Http.PostAsync("/Option/GetRoyalCenterRequestPageData", formData))
				{
					return await GetContentString(res, returnType);
				}
			}
		}

		/// <summary>
		/// 로열 요청이 있는지 여부를 가져오는 메서드입니다.
		/// </summary>
		/// <typeparam name="T">반환할 데이터의 형식을 지정하는 제네릭 매개변수입니다.</typeparam>
		/// <param name="returnType">반환할 데이터 형식을 지정합니다.</param>
		/// <returns>T 형식으로 지정된 로열 요청 데이터입니다.</returns>
		public async Task<T> GetHasRequestRoyal<T>(T returnType)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");

				using (var res = await this.Http.PostAsync("/Option/GetHasRequestRoyal", formData))
				{
					return await GetContentString(res, returnType);
				}
			}
		}

		/// <summary>
		/// 공유 코드를 가져오는 메서드입니다.
		/// </summary>
		/// <typeparam name="T">반환할 데이터의 형식을 지정하는 제네릭 매개변수입니다.</typeparam>
		/// <param name="returnType">반환할 데이터 형식을 지정합니다.</param>
		/// <returns>T 형식으로 지정된 공유 코드 데이터입니다.</returns>
		public async Task<T> GetShareCode<T>(T returnType)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");

				using (var res = await this.Http.PostAsync("/Option/GetShareCode", formData))
				{
					return await GetContentString(res, returnType);
				}
			}
		}

		/// <summary>
		/// 첫 번째 메시지 페이지 데이터를 가져오는 메서드입니다.
		/// </summary>
		/// <typeparam name="T">반환할 데이터의 형식을 지정하는 제네릭 매개변수입니다.</typeparam>
		/// <param name="returnType">반환할 데이터 형식을 지정합니다.</param>
		/// <returns>T 형식으로 지정된 첫 번째 메시지 페이지 데이터입니다.</returns>
		public async Task<T> GetFirstMessagePageData<T>(T returnType)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");

				using (var res = await this.Http.PostAsync("/Option/GetFirstMessagePageData", formData))
				{
					return await GetContentString(res, returnType);
				}
			}
		}

		/// <summary>
		/// 첫 번째 메시지를 실행하는 메서드입니다.
		/// </summary>
		/// <param name="firstMessage">첫 번째 메시지 내용을 지정합니다.</param>
		/// <param name="isRemoveVoice">음성을 제거할지 여부를 지정합니다.</param>
		/// <param name="buffer">음성 파일의 바이트 배열을 지정합니다.</param>
		/// <param name="filename">음성 파일의 이름을 지정합니다.</param>
		public async Task ExcuteFirstMessage(string firstMessage, bool isRemoveVoice, byte[] buffer, string filename)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");

				if (!string.IsNullOrWhiteSpace(firstMessage))
					formData.Add(new StringContent(firstMessage), "firstMessage");

				if (buffer != null && !string.IsNullOrWhiteSpace(filename))
					formData.Add(new ByteArrayContent(buffer), "voice", filename);

				formData.Add(new StringContent(isRemoveVoice.ToString()), "isRemoveVoice");

				using (var res = await this.Http.PostAsync("/Option/ExcuteFirstMessage", formData))
				{
					await GetContentString(res);
				}
			}
		}

		/// <summary>
		/// 지정된 개수만큼의 선택 보내기 페이지 데이터를 가져오는 메서드입니다.
		/// </summary>
		/// <typeparam name="T">반환할 데이터의 형식을 지정하는 제네릭 매개변수입니다.</typeparam>
		/// <param name="skipCount">건너뛸 선택 보내기 개수를 지정합니다.</param>
		/// <param name="returnType">반환할 데이터 형식을 지정합니다.</param>
		/// <returns>T 형식으로 지정된 선택 보내기 페이지 데이터입니다.</returns>
		public async Task<T> GetSendChoicesPageData<T>(int skipCount, T returnType)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");
				formData.Add(new StringContent(skipCount.ToString()), "skipCount");

				using (var res = await this.Http.PostAsync("/Option/GetSendChoicesPageData", formData))
				{
					return await GetContentString(res, returnType);
				}
			}
		}

		/// <summary>
		/// 선택을 제거하는 메서드입니다.
		/// </summary>
		/// <param name="choiceId">제거할 선택의 ID를 지정합니다.</param>
		/// <param name="partnerId">제거할 선택의 파트너 ID를 지정합니다.</param>
		public async Task ExcuteRemoveChoice(int choiceId, int partnerId)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");
				formData.Add(new StringContent(choiceId.ToString()), "choiceId");
				formData.Add(new StringContent(partnerId.ToString()), "partnerId");

				using (var res = await this.Http.PostAsync("/Option/ExcuteRemoveChoice", formData))
				{
					await GetContentString(res);
				}
			}
		}

		/// <summary>
		/// 관리자 이메일을 가져오는 메서드입니다.
		/// </summary>
		/// <typeparam name="T">반환할 데이터의 형식을 지정하는 제네릭 매개변수입니다.</typeparam>
		/// <param name="returnType">반환할 데이터 형식을 지정합니다.</param>
		/// <returns>T 형식으로 지정된 관리자 이메일 데이터입니다.</returns>
		public async Task<T> GetManagerEmail<T>(T returnType)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");

				using (var res = await this.Http.PostAsync("/Option/GetManagerEmail", formData))
				{
					return await GetContentString(res, returnType);
				}
			}
		}

		/// <summary>
		/// 도움말 페이지 데이터를 가져오는 메서드입니다.
		/// </summary>
		/// <typeparam name="T">반환할 데이터의 형식을 지정하는 제네릭 매개변수입니다.</typeparam>
		/// <param name="returnType">반환할 데이터 형식을 지정합니다.</param>
		/// <returns>T 형식으로 지정된 도움말 페이지 데이터입니다.</returns>
		public async Task<T> GetHelpPageData<T>(T returnType)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");

				using (var res = await this.Http.PostAsync("/Option/GetHelpPageData", formData))
				{
					return await GetContentString(res, returnType);
				}
			}
		}

		/// <summary>
		/// 로그인을 실행하고 결과를 반환하는 메서드입니다.
		/// </summary>
		/// <typeparam name="T">반환할 데이터의 형식을 지정하는 제네릭 매개변수입니다.</typeparam>
		/// <param name="email">이메일을 지정합니다.</param>
		/// <param name="password">비밀번호를 지정합니다.</param>
		/// <param name="returnType">반환할 데이터 형식을 지정합니다.</param>
		/// <returns>T 형식으로 지정된 로그인 결과 데이터입니다.</returns>
		public async Task<T> ExcuteLogin<T>(string email, string password, T returnType)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(email), "email");
				formData.Add(new StringContent(password), "password");

				using (var res = await this.Http.PostAsync("/Authentication/ExcuteLogin", formData))
				{
					return await GetContentString(res, returnType);
				}
			}
		}

		/// <summary>
		/// API 키로부터 멤버 데이터를 가져오는 메서드입니다.
		/// </summary>
		/// <typeparam name="T">반환할 데이터의 형식을 지정하는 제네릭 매개변수입니다.</typeparam>
		/// <param name="returnType">반환할 데이터 형식을 지정합니다.</param>
		/// <returns>T 형식으로 지정된 멤버 데이터입니다.</returns>
		public async Task<T> GetMemberFromApiKey<T>(T returnType)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");

				using (var res = await this.Http.PostAsync("/Authentication/GetMemberFromApiKey", formData))
				{
					return await GetContentString(res, returnType);
				}
			}
		}

		/// <summary>
		/// 포인트 정보를 가져오는 메서드입니다.
		/// </summary>
		/// <typeparam name="T">반환할 데이터의 형식을 지정하는 제네릭 매개변수입니다.</typeparam>
		/// <param name="returnType">반환할 데이터 형식을 지정합니다.</param>
		/// <returns>T 형식으로 지정된 포인트 정보 데이터입니다.</returns>
		public async Task<T> GetPointInfo<T>(T returnType)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");

				using (var res = await this.Http.PostAsync("/Authentication/GetPointInfo", formData))
				{
					return await GetContentString(res, returnType);
				}
			}
		}

		/// <summary>
		/// 포인트를 재충전하는 메서드입니다.
		/// </summary>
		/// <param name="roomId">방 ID를 지정합니다.</param>
		public async Task ExcuteRefeelPoint(int roomId)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");
				formData.Add(new StringContent(roomId.ToString()), "roomId");

				using (var res = await this.Http.PostAsync("/Chatting/ExcuteRefeelPoint", formData))
				{
					await GetContentString(res);
				}
			}
		}

		/// <summary>
		/// 카카오 로그인을 실행하고 결과를 반환하는 메서드입니다.
		/// </summary>
		/// <typeparam name="T">반환할 데이터의 형식을 지정하는 제네릭 매개변수입니다.</typeparam>
		/// <param name="kakaoKey">카카오 키를 지정합니다.</param>
		/// <param name="returnType">반환할 데이터 형식을 지정합니다.</param>
		/// <returns>T 형식으로 지정된 카카오 로그인 결과 데이터입니다.</returns>
		public async Task<T> ExcuteKakaoLogin<T>(long kakaoKey, T returnType)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(kakaoKey.ToString()), "kakaoKey");

				using (var res = await this.Http.PostAsync("/Authentication/ExcuteKakaoLogin", formData))
				{
					return await GetContentString(res, returnType);
				}
			}
		}

		/// <summary>
		/// 업데이트 프로필 페이지 데이터를 가져오는 메서드입니다.
		/// </summary>
		/// <typeparam name="T">반환할 데이터의 형식을 지정하는 제네릭 매개변수입니다.</typeparam>
		/// <param name="returnType">반환할 데이터 형식을 지정합니다.</param>
		/// <returns>T 형식으로 지정된 업데이트 프로필 페이지 데이터입니다.</returns>
		public async Task<T> GetUpdateProfilePageData<T>(T returnType)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");

				using (var res = await this.Http.PostAsync("/Option/GetUpdateProfilePageData", formData))
				{
					return await GetContentString(res, returnType);
				}
			}
		}

		/// <summary>
		/// 업데이트 멤버를 실행하고 결과를 반환하는 메서드입니다.
		/// </summary>
		/// <typeparam name="T">반환할 데이터의 형식을 지정하는 제네릭 매개변수입니다.</typeparam>
		/// <param name="newImageIds">새로운 이미지 ID 배열을 지정합니다.</param>
		/// <param name="newImageBuffers">새로운 이미지의 바이트 배열 배열을 지정합니다.</param>
		/// <param name="bodyStyle">신체 스타일을 지정합니다.</param>
		/// <param name="jobName">직업명을 지정합니다.</param>
		/// <param name="school">학교를 지정합니다.</param>
		/// <param name="schoolName">학교명을 지정합니다.</param>
		/// <param name="personality">성격을 지정합니다.</param>
		/// <param name="religion">종교를 지정합니다.</param>
		/// <param name="alcohol">음주 여부를 지정합니다.</param>
		/// <param name="smoking">흡연 여부를 지정합니다.</param>
		/// <param name="blood">혈액형을 지정합니다.</param>
		/// <param name="charmingPoints">매력 포인트 배열을 지정합니다.</param>
		/// <param name="interests">관심사 배열을 지정합니다.</param>
		/// <param name="returnType">반환할 데이터 형식을 지정합니다.</param>
		/// <returns>T 형식으로 지정된 업데이트 멤버 결과 데이터입니다.</returns>
		public async Task<T> ExcuteUpdateMember<T>(
			int[] newImageIds,
			byte[][] newImageBuffers,
			string bodyStyle,
			string jobName,
			string school,
			string schoolName,
			string personality,
			string religion,
			string alcohol,
			string smoking,
			string blood,
			string[] charmingPoints,
			string[] interests,
			T returnType)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");

				if (newImageIds != null)
				{
					for (int i = 0; i < newImageIds.Length; i++)
					{
						var id = newImageIds[i];
						var buffer = newImageBuffers[i];

						formData.Add(new StringContent(id.ToString()), "newImageIds");
						formData.Add(new ByteArrayContent(buffer), "newImages", "newimage.jpg");
					}
				}

				if (!string.IsNullOrWhiteSpace(bodyStyle))
					formData.Add(new StringContent(bodyStyle), "bodyStyle");
				if (!string.IsNullOrWhiteSpace(jobName))
					formData.Add(new StringContent(jobName), "jobName");
				if (!string.IsNullOrWhiteSpace(school))
					formData.Add(new StringContent(school), "school");
				if (!string.IsNullOrWhiteSpace(schoolName))
					formData.Add(new StringContent(schoolName), "schoolName");
				if (!string.IsNullOrWhiteSpace(personality))
					formData.Add(new StringContent(personality), "personality");
				if (!string.IsNullOrWhiteSpace(religion))
					formData.Add(new StringContent(religion), "religion");
				if (!string.IsNullOrWhiteSpace(alcohol))
					formData.Add(new StringContent(alcohol), "alcohol");
				if (!string.IsNullOrWhiteSpace(smoking))
					formData.Add(new StringContent(smoking), "smoking");
				if (!string.IsNullOrWhiteSpace(blood))
					formData.Add(new StringContent(blood), "blood");

				if (charmingPoints != null)
				{
					foreach (var item in charmingPoints)
					{
						formData.Add(new StringContent(item), "charmingPoints");
					}
				}

				if (interests != null)
				{
					foreach (var item in interests)
					{
						formData.Add(new StringContent(item), "interests");
					}
				}

				using (var res = await this.Http.PostAsync("/Option/ExcuteUpdateMember", formData))
				{
					return await GetContentString(res, returnType);
				}
			}
		}

		/// <summary>
		/// 업데이트 선호도 페이지 데이터를 가져오는 메서드입니다.
		/// </summary>
		/// <typeparam name="T">반환할 데이터의 형식을 지정하는 제네릭 매개변수입니다.</typeparam>
		/// <param name="returnType">반환할 데이터 형식을 지정합니다.</param>
		/// <returns>T 형식으로 지정된 업데이트 선호도 페이지 데이터입니다.</returns>
		public async Task<T> GetUpdatePreferencePageData<T>(T returnType)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");

				using (var res = await this.Http.PostAsync("/Option/GetUpdatePreferencePageData", formData))
				{
					return await GetContentString(res, returnType);
				}
			}
		}

		/// <summary>
		/// 계정 설정 페이지 데이터를 가져오는 메서드입니다.
		/// </summary>
		/// <typeparam name="T">반환할 데이터의 형식을 지정하는 제네릭 매개변수입니다.</typeparam>
		/// <param name="returnType">반환할 데이터 형식을 지정합니다.</param>
		/// <returns>T 형식으로 지정된 계정 설정 페이지 데이터입니다.</returns>
		public async Task<T> GetSettingAccountPageData<T>(T returnType)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");

				using (var res = await this.Http.PostAsync("/Option/GetSettingAccountPageData", formData))
				{
					return await GetContentString(res, returnType);
				}
			}
		}

		/// <summary>
		/// 선호도를 업데이트하는 메서드입니다.
		/// </summary>
		/// <param name="minAge">최소 연령을 지정합니다.</param>
		/// <param name="maxAge">최대 연령을 지정합니다.</param>
		/// <param name="range">연령 범위를 지정합니다.</param>
		/// <param name="minTall">최소 키를 지정합니다.</param>
		/// <param name="maxTall">최대 키를 지정합니다.</param>
		/// <param name="beautyOrWealth">외모 또는 재산을 지정합니다.</param>
		/// <param name="body">신체를 지정합니다.</param>
		/// <param name="religion">종교를 지정합니다.</param>
		/// <param name="alcohol">음주 여부를 지정합니다.</param>
		/// <param name="smoking">흡연 여부를 지정합니다.</param>
		/// <param name="priority">우선순위를 지정합니다.</param>
		public async Task ExcuteUpdatePreference(
			int minAge,
			int maxAge,
			int range,
			int minTall,
			int maxTall,
			bool beautyOrWealth,
			string body,
			string religion,
			string alcohol,
			string smoking,
			PriorityTypes priority)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");
				formData.Add(new StringContent(minAge.ToString()), "minAge");
				formData.Add(new StringContent(maxAge.ToString()), "maxAge");
				formData.Add(new StringContent(range.ToString()), "range");
				formData.Add(new StringContent(minTall.ToString()), "minTall");
				formData.Add(new StringContent(maxTall.ToString()), "maxTall");
				formData.Add(new StringContent(beautyOrWealth.ToString()), "beautyOrWealth");
				if (!string.IsNullOrWhiteSpace(body))
					formData.Add(new StringContent(body.ToString()), "body");
				if (!string.IsNullOrWhiteSpace(religion))
					formData.Add(new StringContent(religion.ToString()), "religion");
				if (!string.IsNullOrWhiteSpace(alcohol))
					formData.Add(new StringContent(alcohol.ToString()), "alcohol");
				if (!string.IsNullOrWhiteSpace(smoking))
					formData.Add(new StringContent(smoking.ToString()), "smoking");
				formData.Add(new StringContent(priority.ToString()), "priority");

				using (var res = await this.Http.PostAsync("/Option/ExcuteUpdatePreference", formData))
				{
					await GetContentString(res);
				}
			}
		}

		/// <summary>
		/// 알림 데이터를 가져오는 메서드입니다.
		/// </summary>
		/// <typeparam name="T">반환할 데이터의 형식을 지정하는 제네릭 매개변수입니다.</typeparam>
		/// <param name="returnType">반환할 데이터 형식을 지정합니다.</param>
		/// <returns>T 형식으로 지정된 알림 데이터입니다.</returns>
		public async Task<T> GetNotifications<T>(T returnType)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");

				using (var res = await this.Http.PostAsync("/Main/GetNotifications", formData))
				{
					return await GetContentString(res, returnType);
				}
			}
		}

		/// <summary>
		/// 새로운 알림 여부를 가져오는 메서드입니다.
		/// </summary>
		/// <typeparam name="T">반환할 데이터의 형식을 지정하는 제네릭 매개변수입니다.</typeparam>
		/// <param name="returnType">반환할 데이터 형식을 지정합니다.</param>
		/// <returns>T 형식으로 지정된 새로운 알림 여부 데이터입니다.</returns>
		public async Task<T> GetHasNewNotifications<T>(T returnType)
		{
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");

				using (var res = await this.Http.PostAsync("/Main/GetHasNewNotifications", formData))
				{
					return await GetContentString(res, returnType);
				}
			}
		}

		/// <summary>
		/// 메인 팝업 광고 데이터를 가져오는 메서드입니다.
		/// </summary>
		/// <typeparam name="T">반환할 데이터의 형식을 지정하는 제네릭 매개변수입니다.</typeparam>
		/// <param name="returnType">반환할 데이터 형식을 지정합니다.</param>
		/// <returns>T 형식으로 지정된 메인 팝업 광고 데이터입니다.</returns>
		public async Task<T> GetMainPopupAds<T>(T returnType)
		{
			using (var formData = new MultipartFormDataContent())
			{
				using (var res = await this.Http.PostAsync("/Main/GetMainPopupAds", formData))
				{
					return await GetContentString(res, returnType);
				}
			}
		}

		private async Task<T> GetContentString<T>(HttpResponseMessage res, T returnType)
		{
			if (!res.IsSuccessStatusCode)
				throw new Exception("잠시 후에 다시 시도해 주세요");

			var resText = await res.Content.ReadAsStringAsync();
			var resData = JsonConvert.DeserializeAnonymousType(resText, new { Message = default(string) });
			if (!string.IsNullOrWhiteSpace(resData.Message))
				throw new Exception(resData.Message);

			return JsonConvert.DeserializeAnonymousType(resText, returnType);
		}

		private async Task GetContentString(HttpResponseMessage res)
		{
			if (!res.IsSuccessStatusCode)
				throw new Exception("잠시 후에 다시 시도해 주세요");

			var resText = await res.Content.ReadAsStringAsync();
			var resData = JsonConvert.DeserializeAnonymousType(resText, new { Message = default(string) });
			if (!string.IsNullOrWhiteSpace(resData.Message))
				throw new Exception(resData.Message);
		}

		public void Dispose()
		{
			if (this.Http != null)
			{
				this.Http.Dispose();
				this.Http = null;
			}
		}

	}
}
