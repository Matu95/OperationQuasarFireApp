using OperationQuasarFireApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OperationQuasarFireApp.Services
{
    public interface IMainService
    {
        TopSecretResponseModel TopSecret(TopSecretRequestModel request);
        SatelliteModel TopSecretSplitPost(string satelliteName, SatelliteModel request);
        TopSecretResponseModel TopSecretSplit();
    }
}
