using System.Collections.Generic;
using DF.ACE.Roles.Dto;

namespace DF.ACE.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}