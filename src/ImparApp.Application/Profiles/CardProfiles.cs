using AutoMapper;
using ImparApp.Application.ViewModels.Card;
using ImparApp.Domain.Models;

namespace ImparApp.Application.Profiles
{
    public sealed class CardProfiles : Profile
    {
        public CardProfiles()
        {
            CreateMap<Card, CardViewModel>();
            CreateMap<CardPostViewModel, Card>();
            CreateMap<CardPutViewModel, Card>();
        }
    }
}
