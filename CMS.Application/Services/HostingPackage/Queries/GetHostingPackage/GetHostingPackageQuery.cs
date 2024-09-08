using CMS.Application.Abstractions.Messaging;
using CMS.Application.DTOs.HostingPackageDtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Services.HostingPackage.Queries.GetHostingPackage
{
    public class GetHostingPackageQuery : IQuery<IEnumerable<HostingPackageResponseDto>>
    {
    }
}
