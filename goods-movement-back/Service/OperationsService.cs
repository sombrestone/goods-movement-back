using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using goods_movement_back.Enum;
using goods_movement_back.Model;
using goods_movement_back.ModelView.Operations.Arrival;
using goods_movement_back.QueryService;
using Microsoft.CodeAnalysis;
using AppContext = goods_movement_back.Model.AppContext;

namespace goods_movement_back.Service
{
    public class OperationsService
    {
        private readonly AppContext _context;
        private readonly OperationsQueryService _queryService;
        private readonly IMapper _mapper;

        public OperationsService(AppContext context,
            OperationsQueryService queryService,
            IMapper mapper)
        {
            _context = context;
            _queryService = queryService;
            _mapper = mapper;
        }

        public Guid Arrival(ArrivalSaveModel model)
        {
            var docId = SaveDoc(DocType.Arrival);
            var consignmentId = SaveConsignment(model);
            var balanceId=SaveBalance(consignmentId,docId,model.DepartmentId,model.Number);
            _context.SaveChanges();
            return balanceId;
        }

        public Guid Sale(SaleSaveModel model, 
            DocType docType=DocType.Sale, 
            Guid? depId=null)
        {
            var docId = SaveDoc(docType);
            var departmentId =depId ?? _context.Balances
                .Where(x => x.ConsignmentId == model.ConsignmentId)
                .Select(x=>x.DepartmentId).FirstOrDefault();
            var balanceId=SaveBalance(model.ConsignmentId,docId,
                departmentId,depId==null?-Math.Abs(model.Number):Math.Abs(model.Number));
            _context.SaveChanges();
            return balanceId;
        }

        public Guid Move(MoveSaveModel model)
        {
            return new Guid();
        }

        public IEnumerable<BalanceSmartModel> GetBalance(Guid departmentId) =>
            _queryService.GetBalance(departmentId);

        private Guid SaveBalance(Guid consignmentId, Guid docId,Guid departmentId, int number)
        {
            var balance = new Balance
            {
                Id=Guid.NewGuid(),
                ConsignmentId = consignmentId,
                DepartmentId = departmentId,
                DocId = docId,
                Number = number
            };
            _context.Balances.Add(balance);
            return balance.Id;
        }

        private Guid SaveConsignment(ArrivalSaveModel model)
        {
            var consignment = _mapper.Map<Consignment>(model);
            var id = Guid.NewGuid();
            consignment.Id = id;
            _context.Consignments.Add(consignment);
            return id;
        }

        private Guid SaveDoc(DocType type)
        {
            var id = Guid.NewGuid();
            _context.Docs.Add(new Doc
            {
                Id = id,
                Date = DateTime.Now,
                DocType = (int) type,
                Number = id.ToString()
            });
            return id;
        }
    }
}