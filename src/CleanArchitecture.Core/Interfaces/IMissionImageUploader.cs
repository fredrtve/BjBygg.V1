using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Interfaces
{
    public interface IMissionImageUploader
    {
        Task UploadCollection(IFormFileCollection files, int missionId);
    }
}
