using CMS.Application.Abstractions.Messaging;
using CMS.Application.DTOs.AboutDtos.Request;
using CMS.Application.DTOs.AboutDtos.Response;
using CMS.Application.DTOs.ContactDtos.Request;
using CMS.Application.DTOs.ContactDtos.Response;
using CMS.Application.DTOs.HomeDtos.Request;
using CMS.Application.DTOs.HomeDtos.Response;
using CMS.Application.DTOs.ProductDtos.Response;
using CMS.Application.Services.About.Commands.CreateAbout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Services.Contact.Commands.UpdateContact
{
    public class UpdateContactCommand : ICommand<ContactResponseDto>
    {
        public int Id { get; set; }
        public string EnglishTitle { get; set; }
        public string ArabicTitle { get; set; }
        public string EnglishDescription { get; set; }
        public string ArabicDescription { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ImageUrl { get; set; }
        public string ModifiedBy {  get; set; }

        public async Task<UpdateContactCommand> FromRequest(ContactRequestDto request)
        {
            return await Task.FromResult<UpdateContactCommand>(new UpdateContactCommand
            {
                ArabicTitle = request.ArabicTitle,
                EnglishTitle = request.EnglishTitle,
                ArabicDescription = request.ArabicDescription,
                EnglishDescription = request.EnglishDescription,
                ImageUrl = request.ImageUrl,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                Address = request.Address,
                
            });
        }
    }
}
