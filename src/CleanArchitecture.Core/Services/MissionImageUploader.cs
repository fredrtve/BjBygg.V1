using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Services
{
    public class MissionImageUploader : IMissionImageUploader
    {
        private readonly IAsyncRepository<MissionImage> _imageRepository;
        private readonly IBlobStorageService _storageService;

        public MissionImageUploader(
            IAsyncRepository<MissionImage> imageRepository,
            IBlobStorageService storageService)
        {
            _imageRepository = imageRepository;
            _storageService = storageService;
        }
        public async Task UploadCollection(IFormFileCollection files, int missionId)
        {
            try
            {
                var imageURIs = await _storageService.UploadAsync(files);
                var images = new List<MissionImage>();
                foreach (var uri in imageURIs)
                {
                    images.Add(new MissionImage() { MissionId = missionId, FileURL = uri });
                }
                await _imageRepository.AddRangeAsync(images);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
