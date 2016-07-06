using System.Collections.Generic;
using TPDev.SimpleReport.SharedLibrary.Services.Helper;

namespace TPDev.SimpleReport.SharedLibrary.Services.Viewer
{
    public class ViewerHelperService
    {
        public void CleanupCache(List<string> excludeFiles)
        {
            FileHelper.CleanupCacheFiles(excludeFiles);
        }
    }
}
