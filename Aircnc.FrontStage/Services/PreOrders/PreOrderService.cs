using Aircnc.FrontStage.Models.ViewModels;
using Aircnc.FrontStage.Models.Dtos.Guest;
using AircncFrontStage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aircnc.FrontStage.Models.ViewModels.PreOrder;
using Aircnc.FrontStage.Models.Entities;
using Aircnc.FrontStage.Models.DataModels.RoomOwner;
using Microsoft.AspNetCore.Http;

namespace Aircnc.FrontStage.Services.PreOrders
{
    public class PreOrderService
    {
        private readonly DBRepository _dbRepository;
        public PreOrderService(DBRepository dBRepository)
        {
            _dbRepository = dBRepository;
        }
        public void CreateTransaction(int orderId)
        {
            var order = GetOneOrder(orderId);

            //transaction的userID存的是房東的
            var userId = GetRoomOwnerUserId(order.RoomId);
            using(var transaction = _dbRepository._DbContext.Database.BeginTransaction())
            {
                try
                {
                    var transactionData = new TransactionStatus
                    {
                        UserId = userId,
                        OrderId = order.OrderId,
                        CreateTime = DateTime.UtcNow.AddHours(8),
                        AdminId = 1,
                        TotalAmount = order.OriginalPrice, //Order資料表命名問題這裡算出來是總價沒錯
                        StatusType = StatusTypeEnum.Pending
                    };
                    _dbRepository.Create(transactionData);
                    _dbRepository.Save();

                    transaction.Commit();
                }
                catch(Exception ex)
                {
                    transaction.Rollback();
                }
            }
        }
        public void CreateOrder(int preorderId, IFormCollection info)
        {
            var preOrder = GetOnePreOrder(preorderId);
            var room = GetOneRoom(preOrder.RoomId);
            using (var transaction = _dbRepository._DbContext.Database.BeginTransaction())
            {
                try
                {
                    var order = new Order
                    {
                        UserId = preOrder.UserId,
                        BookingDateTime = preOrder.BookingDateTime,
                        RoomId = preOrder.RoomId,
                        RoomName = preOrder.RoomName,
                        CkeckIn = preOrder.CkeckIn,
                        CkeckOut = preOrder.CkeckOut,
                        PaymentType = (PaymentTypeEnum)1,
                        Status = (OrderStatusEnum)3,
                        BedCount = room.BedCount,
                        RoomCount = room.RoomCount,
                        GuestCount = preOrder.GuestCount,
                        OriginalPrice = (decimal)(int.Parse(info["TradeAmt"])),
                        Country = room.Country,
                        City = room.City,
                        District = room.District,
                        Street = room.Street
                    };
                    _dbRepository.Create(order);
                    _dbRepository.Save();
                    //加入roomCalendar
                    for (int i = 0; i < preOrder.CkeckOut.Subtract(preOrder.CkeckIn).Days; i++)
                    {
                        ChangeRoomStatusDataModel roomCalendarData = new()
                        {
                            RoomId = preOrder.RoomId,
                            Date = preOrder.CkeckIn.Date.AddDays(i),
                        };

                        if (isDataExist(roomCalendarData))
                        {
                            //已有資料，變更狀態
                            var target = _dbRepository.GetAll<RoomCalendar>().First(x => x.RoomId == roomCalendarData.RoomId && x.Date == roomCalendarData.Date);
                            target.RoomCalendarStatus = RoomCalendarStatusEnum.Booked;
                            target.LastChangeTime = DateTime.UtcNow.AddHours(8);
                            _dbRepository.Update<RoomCalendar>(target);
                        }
                        else
                        {
                            //沒有資料，建立一筆
                            var roomt = _dbRepository.GetEntityById<Room>(preOrder.RoomId);
                            var target = new RoomCalendar()
                            {
                                RoomId = roomCalendarData.RoomId,
                                Date = roomCalendarData.Date,
                                LastChangeTime = DateTime.UtcNow.AddHours(8),
                                RoomCalendarStatus = RoomCalendarStatusEnum.Booked,
                                UnitPrice = roomt.UnitPrice
                            };
                            _dbRepository.Create<RoomCalendar>(target);
                        }
                        _dbRepository.Save();
                    }
                    transaction.Commit();
                    //return order.OrderId;
                    CreateTransaction(order.OrderId);
                }
                catch (Exception ex)
                {

                    transaction.Rollback();
                    //return default;
                    
                }
            }
        }
        public int CreatPreOrder(BookingDto request)
        {
            using (var transaction = _dbRepository._DbContext.Database.BeginTransaction())
            {
                try
                {
                    var preOrder = new Models.Entities.PreOrder()
                    {
                        BookingDateTime = request.BookingDateTime,
                        UserId = request.UserId,
                        RoomId = request.RoomId,
                        RoomName = request.RoomName,
                        CkeckIn = request.CkeckIn,
                        CkeckOut = request.CkeckOut,
                        GuestCount = request.GuestCount,
                        OriginalPrice = request.OriginalPrice,
                    };
                    _dbRepository.Create(preOrder);
                    _dbRepository.Save();


                    transaction.Commit();
                    return preOrder.PreOrderId;
                }
                catch (Exception ex)
                {

                    transaction.Rollback();
                    return default;
                }
            }
           
        }
        public bool isDataExist(ChangeRoomStatusDataModel input)
        {
            var isExit = _dbRepository.GetAll<RoomCalendar>().Any(x => x.RoomId == input.RoomId && x.Date == input.Date);
            return isExit;
        }

        public bool isCreated(int roomId, DateTime checkIn, DateTime checkOut)
        {
            var created = _dbRepository.GetAll<Order>().Any(x => x.RoomId == roomId && x.CkeckIn == checkIn && x.CkeckOut == checkOut);
            return created;
        }

        /// <summary>
        /// 撈preOrder資料表資料要傳給綠界
        /// </summary>
        /// <returns></returns>
        public Dictionary<string,string> GetPreOrderInfoToEcPay(int preOrderId)
        {
            var preorderEN = _dbRepository.GetEntityById<PreOrder>(preOrderId);
            var orderId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 15);
            //var website = "https://2a5a-220-129-15-3.jp.ngrok.io";
            var website = "https://aircnctest420.azurewebsites.net/";

            var order = new Dictionary<string, string>
            {
                //特店交易編號
                { "MerchantTradeNo",  orderId},

                //特店交易時間 yyyy/MM/dd HH:mm:ss
                { "MerchantTradeDate",  DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")},

                //交易金額
                { "TotalAmount",  $"{(int)preorderEN.OriginalPrice}"},

                //交易描述
                { "TradeDesc",  "Aircnc"},

                //商品名稱
                { "ItemName",  preorderEN.RoomName},

                //綠界回傳付款資訊的至 此URL
                //{ "ReturnURL",  $"{website}/PreOrder/CreateOrder?preOrderId={preorderEN.PreOrderId}"},
                { "ReturnURL",  $"{website}PreOrder/CreateOrder?preOrderId={preorderEN.PreOrderId}"},

                //使用者於綠界 付款完成後，綠界將會轉址至 此URL
                //{ "OrderResultURL",  $"{website}/PreOrder/AfterEcpay"},
                { "OrderResultURL",  $"{website}PreOrder/AfterEcpay"},


                //特店編號， 2000132 測試綠界編號
                { "MerchantID",  "2000132"},


                //交易類型 固定填入 aio
                { "PaymentType",  "aio"},

                //選擇預設付款方式 固定填入 ALL
                { "ChoosePayment",  "ALL"},

                 //自訂名稱欄位1:這裡放preOrderId
                { "CustomField1",  preorderEN.PreOrderId.ToString()},

                //自訂名稱欄位2:這裡放UserId
                { "CustomField2",  preorderEN.UserId.ToString()},


                //CheckMacValue 加密類型 固定填入 1 (SHA256)
                { "EncryptType",  "1"},
            };

            return order;

        }


        /// <summary>
        /// 取得一筆preoder的資料
        /// </summary>
        /// <returns></returns>
        public PreOrder GetOnePreOrder(int preOrderId)
        {
            return _dbRepository.GetEntityById<PreOrder>(preOrderId);
        }

        public Room GetOneRoom(int roomId)
        {
            return _dbRepository.GetEntityById<Room>(roomId);

        }

        public Order GetOneOrder(int orderId)
        {
            return _dbRepository.GetEntityById<Order>(orderId);
        }

        public int GetRoomOwnerUserId(int roomdId)
        {
            return _dbRepository.GetEntityById<Room>(roomdId).UserId;
        }

    }
}
