using BookingManagementSystem.DAL.Dtos;
using FluentValidation;

namespace BookingManagementSystem.API.Validation
{
    public class HotelValidator:AbstractValidator<HotelDto>
    {
        public HotelValidator()
        {
            RuleFor(h=>h.Name).NotEmpty().MaximumLength(50);  
        }
    }
}
