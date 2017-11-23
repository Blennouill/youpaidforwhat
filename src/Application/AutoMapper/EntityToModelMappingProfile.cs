using AutoMapper;
using ShareFlow.Application.Models;
using ShareFlow.Domain.Entities;

namespace ShareFlow.Application.AutoMapper
{
    public class EntityToModelMappingProfile : Profile
    {
        public EntityToModelMappingProfile()
        {
            CreateMap<Account, AccountModel>();
            CreateMap<Balance, BalanceModel>();
            CreateMap<Beneficiary, BeneficiaryModel>();
            CreateMap<Category, CategoryModel>();
            CreateMap<Event, EventModel>();
            CreateMap<Expense, ExpenseModel>();
            CreateMap<Participant, ParticipantModel>();
            CreateMap<Transaction, TransactionModel>();
        }
    }
}