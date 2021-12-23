using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using goods_movement_back.Enum;
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

        public IEnumerable<BalanceSmartModel> GetSmartBalance(Guid departmentId)
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
                        .Where(x=>x.ConsignmentId==consignment.Id &&
                                  x.DepartmentId==departmentId)
                        .Sum(x=>x.Number)
                }).ToList().GroupBy(x => x.ConsignmentId)
                .Select(group => group.First()).ToList();
        }

        public IEnumerable<BalanceModel> GetBalance(IEnumerable<Guid> depIds)
        {
            var result = (from deps in depIds
                join balance in _context.Balances on deps equals balance.DepartmentId
                group balance by balance.DepartmentId
                into g
                let dep = g.FirstOrDefault().DepartmentId
                select new BalanceModel
                {
                    Products = (from gr in g
                        group gr by gr.ConsignmentId
                        into gro
                        join con in _context.Consignments
                            on gro.FirstOrDefault().ConsignmentId equals con.Id
                        join product in _context.Products
                            on con.ProductId equals product.Id
                        join sup in _context.Suppliers
                            on con.SupplierId equals sup.Id
                        select new ProductItem
                        {
                            Number = gro.Sum(x => x.Number),
                            Price = con.Price,
                            ConsignmentId = con.Id,
                            ProductId = product.Id,
                            ProductName = product.Name,
                            SupplierId = sup.Id,
                            SupplierName = sup.Name
                        }).ToList(),
                    DepartmentId = dep,
                    DepartmentName = _context.Departments.FirstOrDefault(x => x.Id == dep).Name,
                    
                }).ToList();
            return result;
        }
        
        public IEnumerable<BalanceModel> GetBalance(Guid shopId)=>
            GetBalance(GetDepIds(shopId));

        public IEnumerable<MovementModel> GetMovement(IEnumerable<Guid> depIds)
        {
            var result = (from deps in depIds
                join dep in _context.Departments on deps equals dep.Id
                select new MovementModel
                {
                    DepartmentId = deps,
                    DepartmentName = dep.Name,
                    Products = (from balance in _context.Balances
                        join doc in _context.Docs on balance.DocId equals doc.Id
                        join con in _context.Consignments
                            on balance.ConsignmentId equals con.Id
                        join products in _context.Products on con.ProductId equals products.Id
                        join unit in _context.Units on products.UnitId equals unit.Id
                        where (balance.DepartmentId==deps)
                        select new
                        {
                            ProductId=products.Id,
                            ProductName = products.Name,
                            UnitName = unit.Name,
                            ConsignmentId=con.Id,
                            ConNumber=doc.Id,
                            Date=doc.Date,
                            Price=con.Price,
                            Number=balance.Number,
                            DocType=(DocType)doc.DocType,
                            DocName= GetDocName((DocType)doc.DocType),
                            DocNumber=doc.Number,
                            DocId=doc.Id
                        }).ToList()
                        .GroupBy(x=>x.ProductId).ToList()
                        .Select(x=>new ProductMovementModel
                        {
                            ProductId = x.Key,
                            ProductName = x.FirstOrDefault().ProductName,
                            UnitName = x.FirstOrDefault().UnitName,
                            Consignments = x.GroupBy(y=>y.ConsignmentId).ToList()
                                .Select(y=>new ConsignmentMovementModel
                                {
                                    ConsignmentId = y.Key,
                                    DocNumber = y.FirstOrDefault(s=>s.DocType==DocType.Arrival).DocNumber,
                                    Price = y.FirstOrDefault().Price,
                                    EndRemainder = y.Sum(s=>s.Number),
                                    Moves = y.Select(s=>new MovesModel
                                    {
                                        DocId = s.DocId,
                                        DocTypeName = s.DocName,
                                        Number = s.Number,
                                        Date = s.Date,
                                        DocNumber = s.DocNumber
                                    }).ToList()
                                }).ToList()
                        }).ToList()
                }).ToList();
            return result;
        }

        public IEnumerable<MovementModel> GetMovement(Guid shipId) =>
            GetMovement(GetDepIds(shipId));
        
        
        private IEnumerable<Guid> GetDepIds(Guid shopId)=>
            _context.Departments
            .Where(x => x.ShopId == shopId)
            .Select(x=>x.Id).ToList();

        private static string GetDocName(DocType type)
        {
            switch (type)
            {
                case DocType.Arrival: return "Поступление";
                case DocType.Move: return "Перемещение";
                case DocType.Return: return "Возврат";
                case DocType.Sale: return "Продажа";
                default: return "Error";
            }
        }
    }
}