using AutoMapper;
using ShareFlow.Domain.Entities;
using ShareFlow.Interface.Models;
using System.Collections.Generic;

namespace ShareFlow.Interface.AutoMapper
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