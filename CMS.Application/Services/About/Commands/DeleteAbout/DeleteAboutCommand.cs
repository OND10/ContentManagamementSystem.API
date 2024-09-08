using CMS.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Services.About.Commands.DeleteAbout
{
    public class DeleteAboutCommand : ICommand<bool>
    {
        public int Id {  get; set; }
    }
}
