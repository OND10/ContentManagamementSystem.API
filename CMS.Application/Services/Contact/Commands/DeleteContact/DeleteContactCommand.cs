using CMS.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Services.Contact.Commands.DeleteContact
{
    public class DeleteContactCommand : ICommand<bool>
    {
        public int Id {  get; set; }
    }
}
