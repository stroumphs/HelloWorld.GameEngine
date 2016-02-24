using System.Collections.Generic;
using Zero.Bus;
using Zero.Core.Serialization;

namespace HelloWorld.GameEngine
{
    public class BaseMessages
    {
        public BaseMessages(CompactSerializer cs)
        {
            cs.Add(new SchemaBuilder<Channel>().
                       Id(2).
                       Add(m => m.Id, 0).
                       Add(m => m.BaseUnits, 1).
                       Add(m => m.UsersCount, 2).
                       Add(m => m.Capacity, 3).
                       Add(m => m.Required, 4).
                       Add(m => m.RequiredRate, 5).
                       Add(m => m.Name, 6).
                       Done());

            cs.Add(new SchemaBuilder<User>().
                       Id(3).
                       Add(m => m.Id, 0).
                       Add(m => m.UserName, 1).
                       Add(m => m.FirstName, 2).
                       Add(m => m.LastName, 3).
                       Add(m => m.Avatar, 4).
                       Done());

            //            cs.Add(new SchemaBuilder<OpenSessionSlim>()
            //                       .Id(4)
            //                       .Add(m => m.Id, 0)
            //                       .Add(m => m.Title, 1)
            //                       .Add(m => m.Owner, 2)
            //                       .Add(m => m.UsersCount, 3)
            //                       .Add(m => m.MaxUsers, 4)
            //                       .Add(m => m.IsPlaying, 5)
            //                       .Add(m => m.IsPrivate, 6)
            //                       .Add(m => m.Level, 7)
            //                       .Add(m => m.BaseUnit, 8)
            //                       .Add(m => m.Users, 9)
            //                       .Done());
            //
            //            cs.Add(new SchemaBuilder<OpenSession>()
            //                       .Id(5)
            //                       .Add(m => m.Users, 0)
            //                       .Add(m => m.Ready, 1)
            //                       .Add(m => m.Password, 2)
            //                       .Add(m => m.IsPrivate, 3)
            //                       .Add(m => m.ThemeId, 4)
            //                       .Add(m => m.BaseUnit, 5)
            //                       .Add(m => m.Viewers, 6)
            //                       .Add(m => m.MaxUsers, 7)
            //                       .Add(m => m.Owner, 8)
            //                       .Add(m => m.RawUsers, 9)
            //                       .Add(m => m.Id, 10)
            //                       .Add(m => m.Title, 11)
            //                       .Add(m => m.UsersCount, 12)
            //                       .Add(m => m.IsPlaying, 13)
            //                       .Add(m => m.Chips, 14)
            //                       .Add(m => m.Level, 15)
            //                       .Add(m => m.PendingUsers, 16)
            //                       .Done());
            //
            //            cs.Add(new SchemaBuilder<UserLevel>()
            //                       .Id(6)
            //                       .Add(m => m.Application, 0)
            //                       .Add(m => m.UserId, 1)
            //                       .Add(m => m.Level, 2)
            //                       .Add(m => m.CurrentExperience, 3)
            //                       .Add(m => m.NextRequiredExperience, 4)
            //                       .Done());
            //
            //            cs.Add(new SchemaBuilder<Sms>()
            //                       .Id(7)
            //                       .Add(m => m.Code, 0)
            //                       .Add(m => m.Number, 1)
            //                       .Add(m => m.Spent, 2)
            //                       .Add(m => m.ReceivedAmount, 3)
            //                       .Done());
            //
            //            cs.Add(new SchemaBuilder<Cards>()
            //                       .Id(8)
            //                       .Add(m => m.Code, 0)
            //                       .Add(m => m.PinOnly, 1)
            //                       .Done());
            //
            //            cs.Add(new SchemaBuilder<SaleOff>()
            //                       .Id(9)
            //                       .Add(m => m.Percent, 0)
            //                       .Add(m => m.Spend, 1)
            //                       .Done());

            //            cs.Add(new SchemaBuilder<IMessage>().Id(10).Done());

            //            cs.Add(new SchemaBuilder<GameAction>().
            //                       Id(11)
            //                       .Add(m => m.Type, 0)
            //                       .Add(m => m.Message, 1)
            //                       .Done());
            //
            //            cs.Add(new SchemaBuilder<ChangeTurnAction>().
            //                       Id(12)
            //                       .Add(m => m.Type, 0)
            //                       .Add(m => m.Message, 1)
            //                       .Done());
            //
            //            cs.Add(new SchemaBuilder<LeaveGameAction>().
            //                       Id(13)
            //                       .Add(m => m.Type, 0)
            //                       .Add(m => m.Message, 1)
            //                       .Done());
            //
            //            cs.Add(new SchemaBuilder<Mail>().
            //                       Id(14)
            //                       .Add(m => m.Date, 0)
            //                       .Add(m => m.CreateAt, 1)
            //                       .Add(m => m.Id, 2)
            //                       .Add(m => m.From, 3)
            //                       .Add(m => m.Sender, 4)
            //                       .Add(m => m.To, 5)
            //                       .Add(m => m.Readed, 6)
            //                       .Add(m => m.Message, 7)
            //                       .Add(m => m.Label, 8)
            //                       .Done());



            cs.Add(
                new SchemaBuilder<ChannelListRequest>().
                    Id(103).
                    Add(m => m.Application, 0).
                    Done());

            cs.Add(
                new SchemaBuilder<ChannelListResponse>().
                    Id(104).
                    Add(m => m.Channels, 0).
                    Done());

            cs.Add(
                new SchemaBuilder<LoginRequest>().
                    Id(105).
                    Add(m => m.UserName, 0).
                    Add(m => m.Password, 1).
                    Done());

            cs.Add(
                new SchemaBuilder<LoginResponse>().
                    Id(106).
                    Add(m => m.Error, 0).
                    Add(m => m.User, 1).
                    Done());

            //            cs.Add(
            //                new SchemaBuilder<UsersMoneyRequest>().
            //                    Id(107).
            //                    Add(m => m.UserIds, 0).
            //                    Done());
            //
            //            cs.Add(
            //                new SchemaBuilder<UsersMoneyResponse>().
            //                    Id(108).
            //                    Add(m => m.UserIds, 0).
            //                    Add(m => m.Money, 1).
            //                    Done());
            //
            //            cs.Add(
            //                new SchemaBuilder<SessionListRequest>().
            //                    Id(109).
            //                    Add(m => m.Min, 0).
            //                    Done());
            //
            //            cs.Add(
            //                new SchemaBuilder<SessionListResponse>().
            //                    Id(110).
            //                    Add(m => m.Sessions, 0).
            //                    Done());
            //
            //            cs.Add(
            //                new SchemaBuilder<UserLevelInfoRequest>().
            //                    Id(111).
            //                    Add(m => m.Application, 0).
            //                    Add(m => m.UserIds, 1).
            //                    Done());
            //
            //            cs.Add(
            //                new SchemaBuilder<UserLevelInfoResponse>().
            //                    Id(112).
            //                    Add(m => m.UserLevels, 0).
            //                    Done());
            //
            //            cs.Add(
            //                new SchemaBuilder<JoinChannelRequest>().
            //                    Id(113).
            //                    Add(m => m.ChannelId, 0).
            //                    Done());
            //
            //            cs.Add(
            //                new SchemaBuilder<JoinChannelResponse>().
            //                    Id(114).
            //                    Add(m => m.Error, 0).
            //                    Done());
            //
            //            cs.Add(
            //                new SchemaBuilder<ChangeHost>().
            //                    Id(115).
            //                    Add(m => m.NewHost, 0).
            //                    Done());
            //
            //            cs.Add(
            //                new SchemaBuilder<ClientLogoutRequest>().
            //                    Id(116).
            //                    Done());
            //
            //            cs.Add(
            //                new SchemaBuilder<SessionChickenInfo>().
            //                    Id(117).
            //                    Add(m => m.Age, 0).
            //                    Add(m => m.Balance, 1).
            //                    Add(m => m.BaseUnit, 2).
            //                    Add(m => m.Users, 3).
            //                    Done());
            //
            //            cs.Add(
            //                new SchemaBuilder<ChickenDead>().
            //                    Id(118).
            //                    Add(m => m.Killer, 0).
            //                    Add(m => m.Amount, 1).
            //                    Done());
            //
            //
            //            cs.Add(
            //                new SchemaBuilder<CreateSessionRequest>().
            //                    Id(119).
            //                    Add(m => m.Session, 0).
            //                    Done());
            //
            //            cs.Add(
            //                new SchemaBuilder<CreateSessionResponse>().
            //                    Id(120).
            //                    Add(m => m.Error, 0).
            //                    Add(m => m.Session, 1).
            //                    Add(m => m.SlotIndex, 2).
            //                    Done());
            //
            //
            //            cs.Add(
            //                new SchemaBuilder<JoinSessionRequest>()
            //                    .Id(121)
            //                    .Add(m => m.Password, 0)
            //                    .Add(m => m.SessionId, 1)
            //                    .Add(m => m.IsMobile, 2)
            //                    .Done());
            //
            //            cs.Add(
            //                new SchemaBuilder<JoinSessionResponse>()
            //                    .Id(122)
            //                    .Add(m => m.Session, 0)
            //                    .Add(m => m.Error, 1)
            //                    .Add(m => m.Slot, 2)
            //                    .Done());
            //
            //            cs.Add(
            //                new SchemaBuilder<ViewSessionRequest>()
            //                    .Id(123)
            //                    .Add(m => m.SessionId, 0)
            //                    .Add(m => m.SessionKey, 1)
            //                    .Add(m => m.Password, 2)
            //                    .Done());
            //
            //            cs.Add(
            //                new SchemaBuilder<ViewSessionResponse>()
            //                    .Id(124)
            //                    .Add(m => m.Error, 0)
            //                    .Add(m => m.OpenSession, 1)
            //                    .Add(m => m.Actions, 2)
            //                    .Done());
            //
            //            cs.Add(
            //                new SchemaBuilder<PlayerJoinOpenSession>()
            //                    .Id(125)
            //                    .Add(m => m.User, 0)
            //                    .Add(m => m.Slot, 1)
            //                    .Done());
            //
            //            cs.Add(
            //                new SchemaBuilder<ViewerJoin>()
            //                    .Id(126)
            //                    .Add(m => m.User, 0)
            //                    .Done());
            //
            //            cs.Add(
            //                new SchemaBuilder<ViewerLeave>()
            //                    .Id(127)
            //                    .Add(m => m.UserId, 0)
            //                    .Done());
            //
            //            cs.Add(
            //                new SchemaBuilder<ViewStart>()
            //                    .Id(128)
            //                    .Done());
            //
            //            cs.Add(
            //                new SchemaBuilder<ClientLeaveOpenSession>()
            //                    .Id(129)
            //                    .Add(m => m.SenderId, 0)
            //                    .Done());
            //
            //            cs.Add(
            //                new SchemaBuilder<StartGameRequest>()
            //                    .Id(130)
            //                    .Done());
            //
            //            cs.Add(
            //                new SchemaBuilder<StartGameResponse>()
            //                    .Id(131)
            //                    .Add(m => m.Error, 0)
            //                    .Done());
            //
            //            cs.Add(
            //                new SchemaBuilder<GameEnd>()
            //                    .Id(132)
            //                    .Add(m => m.Result, 0)
            //                    .Add(m => m.IsValid, 1)
            //                    .Done());
            //
            //            cs.Add(new SchemaBuilder<RewardMessage>()
            //                       .Id(133)
            //                       .Add(m => m.Amount, 0)
            //                       .Add(m => m.Reason, 1)
            //                       .Done());
            //
            //            cs.Add(new SchemaBuilder<ClientKick>()
            //                       .Id(134)
            //                       .Add(m => m.UserId, 0)
            //                       .Add(m => m.Reason, 1)
            //                       .Done());
            //
            //            cs.Add(new SchemaBuilder<ClientLeavePlaySession>()
            //                       .Id(135)
            //                       .Add(m => m.SenderId, 0)
            //                       .Done());
            //
            //            cs.Add(new SchemaBuilder<SessionClosedByServer>()
            //                       .Id(136)
            //                       .Done());
            //            cs.Add(new SchemaBuilder<PlayNow>()
            //                       .Id(137)
            //                       .Add(m => m.IsMobile, 0)
            //                       .Done());
            //
            //            cs.Add(new SchemaBuilder<ClientStandUp>()
            //                       .Id(138)
            //                       .Add(m => m.SenderId, 0)
            //                       .Add(m => m.Error, 1)
            //                       .Add(m => m.NewHost, 2)
            //                       .Done());
            //
            //            cs.Add(new SchemaBuilder<SmartPhoneTopupRequest>()
            //                       .Id(139)
            //                       .Add(m => m.CardPin, 0)
            //                       .Add(m => m.CardType, 1)
            //                       .Add(m => m.CardSerial, 2)
            //                       .Done());
            //
            //            cs.Add(new SchemaBuilder<SmartPhoneTopupResponse>()
            //                       .Id(140)
            //                       .Add(m => m.Ok, 0)
            //                       .Add(m => m.UserId, 1)
            //                       .Add(m => m.Amount, 2)
            //                       .Add(m => m.Application, 3)
            //                       .Done());
            //
            //            cs.Add(new SchemaBuilder<TopupInfoRequest>()
            //                       .Id(141)
            //                       .Add(m => m.PartnerId, 0)
            //                       .Done());
            //
            //            cs.Add(new SchemaBuilder<TopupInfoResponse>()
            //                       .Id(142)
            //                       .Add(m => m.Sms, 0)
            //                       .Add(m => m.Cards, 1)
            //                       .Add(m => m.SellOfs, 2)
            //                       .Add(m => m.Error, 3)
            //                       .Done());
            //
            //            cs.Add(new SchemaBuilder<YourTurn>()
            //                       .Id(143)
            //                       .Done());
            //
            //            cs.Add(new SchemaBuilder<ChangeTurn>()
            //                       .Id(144)
            //                       .Add(m => m.UserId, 0)
            //                       .Done());
            //
            //            cs.Add(new SchemaBuilder<ClientPassed>()
            //                       .Id(145)
            //                       .Add(m => m.SenderId, 0)
            //                       .Done());
            //
            //            cs.Add(new SchemaBuilder<TransactionEvent>()
            //                       .Id(146)
            //                       .Add(m => m.From, 0)
            //                       .Add(m => m.To, 1)
            //                       .Add(m => m.Amount, 2)
            //                       .Add(m => m.Reason, 3)
            //                       .Done());
            //
            //            cs.Add(new SchemaBuilder<ClientChatMessage>()
            //                       .Id(147)
            //                       .Add(m => m.UserName, 0)
            //                       .Add(m => m.Text, 1)
            //                       .Add(m => m.SenderId, 2)
            //                       .Done());
            //
            //            cs.Add(new SchemaBuilder<BaseGameMessage>()
            //                       .Id(148)
            //                       .Add(m => m.SenderId, 0)
            //                       .Done());
            //
            //            cs.Add(new SchemaBuilder<OpenIdUrlRequest>()
            //                       .Id(149)
            //                       .Add(m => m.Service, 0)
            //                       .Add(m => m.PartnerCode, 1)
            //                       .Done());
            //
            //            cs.Add(new SchemaBuilder<OpenIdUrlResponse>()
            //                       .Id(150)
            //                       .Add(m => m.Service, 0)
            //                       .Add(m => m.Url, 1)
            //                       .Done());
            //
            //            cs.Add(new SchemaBuilder<OpenIdLoginRequest>()
            //                       .Id(151)
            //                       .Add(m => m.Service, 0)
            //                       .Add(m => m.Code, 1)
            //                       .Add(m => m.PartnerCode, 2)
            //                       .Done());
            //
            //            cs.Add(new SchemaBuilder<SessionHashResponse>()
            //                       .Id(152)
            //                       .Add(m => m.SessionHash, 0)
            //                       .Done());
            //
            //            cs.Add(new SchemaBuilder<SessionHashVerify>()
            //                       .Id(153)
            //                       .Add(m => m.UserId, 0)
            //                       .Add(m => m.SessionHash, 1)
            //                       .Done());
            //
            //            cs.Add(new SchemaBuilder<RegisterRequest>()
            //                       .Id(154)
            //                       .Add(m => m.UserName, 0)
            //                       .Add(m => m.Password, 1)
            //                       .Add(m => m.PartnerId, 2)
            //                       .Add(m => m.Gsub, 3)
            //                       .Add(m => m.DeviceId, 4)
            //                       .Done());
            //
            //            cs.Add(new SchemaBuilder<RegisterResponse>()
            //                       .Id(155)
            //                       .Add(m => m.Error, 0)
            //                       .Done());
            //
            //            cs.Add(new SchemaBuilder<ChangePassRequest>()
            //                       .Id(156)
            //                       .Add(m => m.UserName, 0)
            //                       .Add(m => m.OldPass, 1)
            //                       .Add(m => m.NewPass, 2)
            //                       .Done());
            //
            //            cs.Add(new SchemaBuilder<ChangePassReponse>()
            //                       .Id(157)
            //                       .Add(m => m.Error, 0)
            //                       .Done());
            //
            //            cs.Add(new SchemaBuilder<ServerLeaveOpenSession>()
            //                       .Id(158)
            //                       .Add(m => m.SenderId, 0)
            //                       .Done());
            //
            //            cs.Add(new SchemaBuilder<FreeDailyTopup>()
            //                       .Id(159)
            //                       .Add(m => m.DeviceId, 0)
            //                       .Done());
            //
            //            cs.Add(new SchemaBuilder<MaybeLogout>()
            //                       .Id(160)
            //                       .Add(m => m.UserId, 0)
            //                       .Done());
            //
            //            cs.Add(new SchemaBuilder<Topup>()
            //                       .Id(161)
            //                       .Add(m => m.UserId, 0)
            //                       .Add(m => m.Application, 1)
            //                       .Add(m => m.Amount, 2)
            //                       .Add(m => m.Vnd, 3)
            //                       .Done());
            //
            //            cs.Add(new SchemaBuilder<ViewerJoinSessionRequest>()
            //                       .Id(162)
            //                       .Add(m => m.Password, 0)
            //                       .Add(m => m.SessionId, 1)
            //                       .Add(m => m.IsMobile, 2)
            //                       .Done());
            //
            //            cs.Add(new SchemaBuilder<LeavePlaySession>()
            //                       .Id(163)
            //                       .Add(m => m.SenderId, 0)
            //                       .Done());
            //
            //            cs.Add(new SchemaBuilder<InvitePlayResponse>()
            //                      .Id(164)
            //                      .Add(m => m.Application, 0)
            //                      .Add(m => m.ChannelId, 1)
            //                      .Add(m => m.SessionId, 2)
            //                      .Add(m => m.SessionKey, 3)
            //                      .Add(m => m.User, 4)
            //                      .Add(m => m.BaseUnit, 5)
            //                      .Done());
            //
            //            cs.Add(new SchemaBuilder<SessionChickenRequest>()
            //                       .Id(165)
            //                       .Done());
            //
            //            cs.Add(new SchemaBuilder<ForceKillChicken>()
            //                       .Id(166)
            //                       .Add(m => m.Amount, 0)
            //                       .Add(m => m.Users, 1)
            //                       .Done());
            //
            //            cs.Add(new SchemaBuilder<GlobalAlert>()
            //                       .Id(167)
            //                       .Add(m => m.Partner, 0)
            //                       .Add(m => m.Content, 1)
            //                       .Add(m => m.NewsType, 2)
            //                       .Add(m => m.Application, 3)
            //                       .Done());
            //
            //            cs.Add(new SchemaBuilder<GlobalAlertRequerst>()
            //                       .Id(168)
            //                       .Done());
            //
            //            cs.Add(new SchemaBuilder<GlobalAlertResponse>()
            //                       .Id(169)
            //                       .Add(m => m.News, 0)
            //                       .Done());
            //
            //            cs.Add(new SchemaBuilder<TopupAlert>()
            //                       .Id(170)
            //                       .Add(m => m.Content, 0)
            //                       .Add(m => m.SenderId, 1)
            //                       .Add(m => m.Amount, 2)
            //                       .Done());
            //
            //            cs.Add(new SchemaBuilder<EwaySmartPhoneSmsResponse>()
            //                       .Id(171)
            //                       .Add(m => m.Error, 0).Done());
            //
            //            cs.Add(new SchemaBuilder<BaseChatMessage>()
            //                       .Id(172)
            //                       .Add(m => m.Text, 0)
            //                       .Add(m => m.UserName, 1).Done());
            //
            //            cs.Add(new SchemaBuilder<ChannelChatHistoryRequest>()
            //                       .Id(173)
            //                       .Done());
            //
            //            cs.Add(new SchemaBuilder<ChannelChatHistoryResponse>()
            //                       .Id(174)
            //                       .Add(m => m.Messages, 0)
            //                       .Done());
            //
            //            cs.Add(new SchemaBuilder<InvitePlayRequest>()
            //                       .Id(175)
            //                       .Add(m => m.SessionId, 0)
            //                       .Add(m => m.SessionKey, 1)
            //                       .Add(m => m.BaseUnit, 2)
            //                       .Add(m => m.User, 3)
            //                       .Done());
            //
            //            cs.Add(
            //               new SchemaBuilder<FriendCheckRequest>().
            //                   Id(177).
            //                   Add(m => m.UserId, 0).
            //                   Add(m => m.FriendId, 1).
            //                   Done());
            //
            //            cs.Add(
            //              new SchemaBuilder<FriendCheckResponse>().
            //                  Id(178).
            //                  Add(m => m.UserId, 0).
            //                  Add(m => m.IsFriend, 1).
            //                  Done());
            //
            //            cs.Add(
            //                new SchemaBuilder<FriendsRequest>().
            //                    Id(179).
            //                    Add(m => m.UserId, 0).
            //                    Add(m => m.From, 1).
            //                    Add(m => m.Quantity, 2).
            //                    Done());
            //
            //            cs.Add(
            //                new SchemaBuilder<FriendsResponse>().
            //                    Id(180).
            //                    Add(m => m.UserId, 0).
            //                    Add(m => m.Total, 1).
            //                    Add(m => m.UserIds, 2).
            //                    Add(m => m.Friends, 3).
            //                    Done());
            //
            //            cs.Add(
            //                new SchemaBuilder<FriendsOnlineRequest>().
            //                    Id(181).
            //                    Add(m => m.UserId, 0).
            //                    Done());
            //
            //            cs.Add(
            //                new SchemaBuilder<FriendsOnlineResponse>().
            //                    Id(182).
            //                    Add(m => m.Users, 0).
            //                    Add(m => m.UserIds, 1).
            //                    Done());
            //
            //            cs.Add(
            //                new SchemaBuilder<ClientRemoveFriendRequest>().
            //                    Id(183).
            //                    Done());
            //
            //            cs.Add(
            //              new SchemaBuilder<ClientRemoveFriendResponse>().
            //                  Id(184).
            //                  Add(m => m.FriendId, 0).
            //                  Add(m => m.Error, 1).
            //                  Done());
            //
            //            cs.Add(
            //                new SchemaBuilder<ClientAddFriendRequest>().
            //                    Id(185).
            //                    Add(m => m.FriendId, 0).
            //                    Add(m => m.Requester, 1).
            //                    Done());
            //
            //            cs.Add(
            //                new SchemaBuilder<ServerAddFriendRequest>().
            //                    Id(186).
            //                    Add(m => m.Requester, 0).
            //                    Add(m => m.RequestId, 1).
            //                    Done());
            //
            //            cs.Add(
            //              new SchemaBuilder<ClientAddFriendResponse>().
            //                  Id(187).
            //                  Add(m => m.Agree, 0).
            //                  Add(m => m.RequestId, 1).
            //                   Add(m => m.Requested, 2).
            //                  Done());
            //
            //            cs.Add(
            //                new SchemaBuilder<ServerAddFriendResponse>().
            //                    Id(188).
            //                    Add(m => m.Requested, 0).
            //                    Add(m => m.Agree, 1).
            //                    Done());
            //
            //            cs.Add(
            //                new SchemaBuilder<MatchStatisticInfoRequest>().
            //                    Id(189).
            //                    Add(m => m.Application, 0).
            //                    Add(m => m.SenderId, 1).
            //                    Add(m => m.UserId, 2).
            //                    Done());
            //
            //            cs.Add(
            //                new SchemaBuilder<MatchStatisticInfoResponse>().
            //                    Id(190).
            //                    Add(m => m.Application, 0).
            //                    Add(m => m.WinMatches, 1).
            //                    Add(m => m.TotalMatches, 2).
            //                    Add(m => m.MaxWinAmount, 3).
            //                    Add(m => m.UserId, 4).
            //                    Add(m => m.Error, 5).
            //                    Done());
            //
            //            cs.Add(
            //                new SchemaBuilder<InviteToPlayRequest>().
            //                    Id(191).
            //                    Add(m => m.SessionId, 0).
            //                    Add(m => m.SessionKey, 1).
            //                    Add(m => m.BaseUnit, 2).
            //                    Add(m => m.User, 3).
            //                    Add(m => m.InvitedId, 4).
            //                    Add(m => m.Application, 5).
            //                    Add(m => m.ChannelId, 6).
            //                    Done());
            //
            //            cs.Add(
            //                new SchemaBuilder<InviteToPlayResponse>().
            //                    Id(192).
            //                    Done());
            //
            //            cs.Add(
            //              new SchemaBuilder<SentMail>().
            //                  Id(193).
            //                  Add(m => m.From, 0).
            //                  Add(m => m.To, 1).
            //                  Add(m => m.Text, 2).
            //                  Done());
            //
            //            cs.Add(
            //             new SchemaBuilder<NewMail>().
            //                 Id(194).
            //                 Add(m => m.Mail, 0).
            //                 Done());
            //
            //            cs.Add(
            //                new SchemaBuilder<InboxRequest>().
            //                    Id(195).
            //                    Add(m => m.From, 0).
            //                    Add(m => m.UserId, 0).
            //                    Add(m => m.Filter, 0).
            //                    Add(m => m.Label, 0).
            //                    Done());
            //
            //            cs.Add(
            //              new SchemaBuilder<InboxResponse>().
            //                  Id(196).
            //                  Add(m => m.Mails, 0).
            //                  Done());
            //
            //            cs.Add(
            //             new SchemaBuilder<MailReadedRequest>().
            //                 Id(197).
            //                 Add(m => m.MailIds, 0).
            //                  Add(m => m.UserId, 1).
            //                 Done());
            //
            //            cs.Add(
            //                new SchemaBuilder<MailReadedResponse>().
            //                    Id(198).
            //                    Add(m => m.MailIds, 0).
            //                    Add(m => m.Error, 1).
            //                    Done());
            //
            //            cs.Add(
            //              new SchemaBuilder<DeleteMailRequest>().
            //                  Id(199).
            //                  Add(m => m.MailIds, 0).
            //                  Add(m => m.UserId, 1).
            //                  Done());
            //
            //            cs.Add(
            //                new SchemaBuilder<DeleteMailResponse>().
            //                    Id(1000).
            //                    Add(m => m.MailIds, 0).
            //                    Add(m => m.Error, 1).
            //                    Done());
        }
    }
    public class CoreMessages
    {
        readonly CompactSerializer _serializer;

        public CoreMessages(CompactSerializer serializer)
        {
            _serializer = serializer;

            var cs = _serializer;

            cs.Add(
                new SchemaBuilder<MessagePacket>().
                    Id(0).
                    Add(m => m.Application, 0).
                    Add(m => m.ConsumerId, 1).
                    Add(m => m.Message, 2).
                    Add(m => m.PublisherId, 3).
                    Done());

            cs.Add(new SchemaBuilder<GameProxyDetail>().
                       Id(1).
                       Add(m => m.IpAddress, 0).
                       Add(m => m.Port, 1).
                       Add(m => m.GameId, 2).
                       Add(m => m.IsUnderConstruction, 3).
                       Done());

            cs.Add(
                new SchemaBuilder<ProxyRequest>().
                    Id(100).
                    Add(m => m.ApplicationId, 0).
                    Add(m => m.CurrentVersion, 1).
                    Add(m => m.ParterId, 2).
                    Done());

            cs.Add(
                new SchemaBuilder<ProxyResponse>().
                    Id(101).
                    Add(m => m.ProxyDetails, 0).
                    Add(m => m.UpdateUrl, 1).
                    Done());

            cs.Add(new SchemaBuilder<Welcome>().
                       Id(102).
                       Done());

            cs.Add(
               new SchemaBuilder<Ping>().
               Id(1001).
               Done());
        }
    }

    public class LoginRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class LoginResponse
    {
        public const int Ok = 0;
        public const int InvalidUserNameOrPasswod = -1;

        public int Error { get; set; }
        public User User { get; set; }
    }

    public class User
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Avatar { get; set; }

        public override string ToString()
        {
            return string.Format("Id={0},UserName={1},Avatar={2}", Id, UserName, Avatar);
        }
    }

    public class ChannelListResponse
    {
        public List<Channel> Channels { get; set; }
    }

    public class ChannelListRequest
    {
        public int Application { get; set; }
    }


    public class Channel
    {
        public int Id { get; set; }

        public List<int> BaseUnits { get; set; }

        public int UsersCount { get; set; }
        public int Capacity { get; set; }
        public int Required { get; set; }
        public int RequiredRate { get; set; }
        public string Name { get; set; }
    }
}