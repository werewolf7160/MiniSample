using MiniSample.UWP;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Core;
using Windows.System;
using Xamarin.Forms;

[assembly: Dependency(typeof(WindowManager))]
namespace MiniSample.UWP
{
    class WindowManager : IWindowManager
    {
        public async void Maximize()
        {
            try
            {
                IEnumerable<AppListEntry> appListEntries = await Package.Current.GetAppListEntriesAsync();
                await appListEntries.First().LaunchAsync();
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
            }
        }

        public async void Minimize()
        {
            try
            {
                IList<AppDiagnosticInfo> infos = await AppDiagnosticInfo.RequestInfoForAppAsync();
                IList<AppResourceGroupInfo> resourceInfos = infos[0].GetResourceGroups();
                resourceInfos[0].StartSuspendAsync();
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
            }
        }
    }
}
