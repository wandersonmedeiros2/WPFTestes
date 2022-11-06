using System;

namespace UtilsLib
{
    public class AppStatusHandler
    {
        private AppStatus _appStatus;
        public AppStatus Status 
        {
            get { return _appStatus; }
            set { 
                _appStatus = value;
                AppStatusObservable.Instance.SetCurrentState(_appStatus);
            } 
        }

        public static AppStatusHandler Instance { get; private set; } = new AppStatusHandler();

        private AppStatusHandler()
        {
            _appStatus = AppStatus.Online;
        }

    }
}
