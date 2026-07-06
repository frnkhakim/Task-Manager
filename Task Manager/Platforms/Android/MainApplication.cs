using Android.App;
using Android.Runtime;

namespace Task_Manager
{
    [Application(Theme = "@style/Maui.MainTheme.NoActionBar")]
    public class MainApplication : MauiApplication
    {
        public MainApplication(IntPtr handle, JniHandleOwnership ownership)
            : base(handle, ownership)
        {
        }

        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}
