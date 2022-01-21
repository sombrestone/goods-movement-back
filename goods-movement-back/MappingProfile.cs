using AutoMapper;
using goods_movement_back.Model;
using goods_movement_back.ModelView;
using goods_movement_back.ModelView.Department;
using goods_movement_back.ModelView.Operations.Arrival;
using goods_movement_back.ModelView.Shop;
using goods_movement_back.ModelView.Supplier;
using goods_movement_back.ModelView.Unit;
using goods_movement_back.ModelView.VAT;
using goods_movement_back.ModelView.Worker;

namespace goods_movement_back
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<UnitSaveModel, Unit>().ReverseMap();
            CreateMap<UnitUpdateModel, Unit>().ReverseMap();

            CreateMap<ProductSaveModel, Product>().ReverseMap();
            CreateMap<ProductUpdateModel, Product>().ReverseMap();
            CreateMap<ProductModel, Product>().ReverseMap();
            
            CreateMap<ShopSaveModel, Shop>().ReverseMap();
            CreateMap<ShopUpdateModel, Shop>().ReverseMap();
            CreateMap<ShopModel, Shop>().ReverseMap();
            
            CreateMap<DepartmentSaveModel, Department>().ReverseMap();
            CreateMap<DepartmentUpdateModel, Department>().ReverseMap();
            CreateMap<DepartmentModel, Department>().ReverseMap();
            
            CreateMap<SupplierSaveModel, Supplier>().ReverseMap();
            CreateMap<SupplierUpdateModel, Supplier>().ReverseMap();
            CreateMap<SupplierModel, Supplier>().ReverseMap();
            
            CreateMap<VatSaveModel, VAT>().ReverseMap();
            CreateMap<VatUpdateModel, VAT>().ReverseMap();
            
            CreateMap<ArrivalSaveModel, Consignment>();

            CreateMap<Worker, WorkerModel>().ReverseMap();
        }
    }
}