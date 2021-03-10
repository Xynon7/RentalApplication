using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace RentalApp
{
    interface IPhotoPickerService
    {
        Task<Stream> GetImageStreamAsync();
    }
}
