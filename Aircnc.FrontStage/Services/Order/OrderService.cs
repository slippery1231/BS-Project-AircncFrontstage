using Aircnc.FrontStage.Models.Dtos.Order;
using Aircnc.FrontStage.Models.Entities;
using AircncFrontStage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aircnc.FrontStage.Services
{
    public class OrderService
    {
        public readonly DBRepository _dbRepository;
        public OrderService(DBRepository dBRepository)
        {
            _dbRepository = dBRepository;
        }

        public IEnumerable<OrderDto> GetAllOrderDtoByUserId(int userId) //撈使用者所有的訂單(包含過去現在取消)
        {
            return _dbRepository.GetAll<Order>().Where(order => order.UserId == userId).Select(order => new OrderDto
            {
                OrderId = order.OrderId,
                RoomId = order.RoomId,
                RoomName = order.RoomName,
                CkeckIn = order.CkeckIn,
                CkeckOut = order.CkeckOut,
                Country = order.Country,
                City = order.City,
                District = order.District,
                Street = order.Street,
                RoomImg = _dbRepository.GetAll<RoomImg>()
                .Where(x => x.RoomId == order.RoomId).OrderBy(x => x.Sort).Select(x => x.ImageUrl).FirstOrDefault(),
                RoomOwnerName = (_dbRepository.GetAll<User>().FirstOrDefault(x => x.UserId == order.Room.UserId)).Name,
                Status = order.Status
            });
        }


        //public void UpdateOrderStatus(int )
        //{
        //    var target = _dbRepository.GetAll<Order>().Where(x => x.OrderId == orderid).Select(x=>x);
        //    var today = DateTime.Now;
        //    var timeCompare = DateTime.Compare(today, target.CkeckIn);
        //    if(timeCompare > 0)
        //    {
        //        target.Status = OrderStatusEnum.Past;
        //        _dbRepository.Update<Order>(target);
        //    }
        //    //else
        //    //{
        //    //    target.Status = OrderStatusEnum.Future;
        //    //    _dbRepository.Update<Order>(target);
        //    //}
        //    _dbRepository.Save();
        //}

        //更改訂單狀態
        public void UpdateOrderStatus(IEnumerable<Order> orders)
        {
            var today = DateTime.UtcNow.AddHours(8);
            foreach (var order in orders)
            {
                var timeCompare = DateTime.Compare(today, order.CkeckOut);
                if (timeCompare > 0)
                {

                    order.Status = OrderStatusEnum.Past;
                    _dbRepository.Update<Order>(order);
                }
            }
            _dbRepository.Save();

        }
        public IEnumerable<Order> GetAllOrderByUserId(int userId) //撈使用者所有的訂單
        {
            return _dbRepository.GetAll<Order>().Where(order => order.UserId == userId);

        }

    }
}
