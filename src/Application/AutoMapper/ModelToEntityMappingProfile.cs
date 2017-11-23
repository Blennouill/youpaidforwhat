using AutoMapper;
using ShareFlow.Application.Models;
using ShareFlow.Domain.Entities;

namespace ShareFlow.Application.AutoMapper
{
    public class ModelToEntityMappingProfile : Profile
    {
        public ModelToEntityMappingProfile()
        {
            CreateMap<AccountModel, Account>();
            CreateMap<BalanceModel, Balance>();
            CreateMap<BeneficiaryModel, Beneficiary>();
            CreateMap<CategoryModel, Category>();
            CreateMap<EventModel, Event>();
            CreateMap<ExpenseModel, Expense>();
            CreateMap<ParticipantModel, Participant>();
            CreateMap<TransactionModel, Transaction>();
        }
    }
}