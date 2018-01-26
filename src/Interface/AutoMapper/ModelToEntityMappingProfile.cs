using AutoMapper;
using ShareFlow.Domain.Entities;
using ShareFlow.Interface.Models;
using System.Collections.Generic;

namespace ShareFlow.Interface.AutoMapper
{
    public class ModelToEntityMappingProfile : Profile
    {
        public ModelToEntityMappingProfile()
        {
            CreateMap<AccountModel, Account>();
            CreateMap<BeneficiaryModel, Beneficiary>();
            CreateMap<CategoryModel, Category>();
            CreateMap<EventModel, Event>();
            CreateMap<ExpenseModel, Expense>();
            CreateMap<ParticipantModel, Participant>();
            CreateMap<TransactionModel, Transaction>();
        }
    }
}