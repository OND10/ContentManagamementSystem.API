using CMS.Application.Abstractions.Messaging;
using CMS.Application.DTOs.HomeDtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Services.Home.Queries.GetHomeBasedonLang
{
    public class GetHomeBasedonLangQuery : IQuery<IEnumerable<HomeResponseDto>>
    {
        public string lang {  get; set; }
    }
}
