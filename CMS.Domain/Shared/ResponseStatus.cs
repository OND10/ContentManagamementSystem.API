﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Shared
{
    public static class ResponseStatus
    {
        public const string Success = "Operation Executed Successfully";
        public const string GetAllSuccess = "Viewd Successfully";
        public const string GetSuccess = "Found Successfully";
        public const string CreateSuccess = "Created Successfully";
        public const string UpdateSuccess = "Update Successfully";
        public const string DeletedSuccess = "Deleted Successfully";
        public const string Faild = "Operation Faild";
        public const string UploadedSuccess = "File is Uploaded Successfully";
    }
}
