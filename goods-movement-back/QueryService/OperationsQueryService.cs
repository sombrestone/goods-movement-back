using System;
using System.Collections.Generic;
using System.Linq;
using goods_movement_back.Model;
using goods_movement_back.ModelView.Operations.Arrival;
using AppContext = goods_movement_back.Model.AppContext;

namespace goods_movement_back.QueryService
{
    public class OperationsQueryService
    {
        private readonly AppContext _context;

        public OperationsQueryService(AppContext context)
        {
            _context = context;
        }

        public IEnumerable<BalanceSmartModel> GetBalance(Guid departmentId)
        {
            return (from balance in _context.Balances
                join consignment in _context.Consignments
                    on balance.ConsignmentId equals consignment.Id
                join product in _context.Products
                    on consignment.ProductId equals product.Id
                where (balance.DepartmentId == departmentId)
                select new BalanceSmartModel
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    Price=consignment.Price,
                    ConsignmentId = consignment.Id,
                    Number = _context.Balances
                        .Where(x=>x.ConsignmentId==consignment.Id)
                        .Sum(x=>x.Number)
                }).ToList().GroupBy(x => x.ConsignmentId)
                .Select(group => group.First()).ToList();
        }
    }
}