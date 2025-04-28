using DTOLayer.ReservationDTOs;
using EntityLayer.Entities.Concrete;
using FluentValidation;

namespace BusinessLogicLayer.ValidationRules.ReservationValidator
{
    public class CreateReservationValidator:AbstractValidator<CreateReservationDTO>
    {
        public CreateReservationValidator()
        {
            RuleFor(x => x.NameSurname).NotEmpty().WithMessage("Adı Soyadı Boş Bırakamazsın!");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon Numarasını Boş Bırakamazsın!");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("E-Mail Adresini Boş Bırakamazsın!");
            RuleFor(x => x.PersonCount).NotEmpty().WithMessage("Kişi Sayısını Boş Bırakamazsın!");
            RuleFor(x => x.NameSurname).MinimumLength(5)
            .WithMessage("Adı Soyadı En Az 5 Karakter Olmalı!")
            .MaximumLength(50)
            .WithMessage("Adı Soyadı En Fazla 50 Karakter Olmalı!");
            RuleFor(x => x.Phone)
            .MinimumLength(11)//05300211258
            .WithMessage("Telefon Numarası En Az 11 Karakter Olmalı!")
            .MaximumLength(11)
            .WithMessage("Telefon Numarası En Fazla 11 Karakter Olmalı!");
             RuleFor(x => x.Mail)
            .MinimumLength(15)//@gmail.com
            .WithMessage("Mail Adresi En Az 15 Karakter Olmalı!")
            .MaximumLength(30)
            .WithMessage("Mail Adresi En Fazla 30 Karakter Olmalı!");
        }
    }
}
