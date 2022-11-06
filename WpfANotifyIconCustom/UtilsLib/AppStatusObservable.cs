using System;
using System.Collections.Generic;
using System.Text;

namespace UtilsLib
{
    public class AppStatusObservable : IObservable<AppStatusObservable>
    {
        private List<IObserver<AppStatusObservable>> _observers = new List<IObserver<AppStatusObservable>>();
        public AppStatus AppCurrentStatus { get; private set; }

        public static AppStatusObservable Instance = new AppStatusObservable();

        private AppStatusObservable()
        {

        }

        public void SetCurrentState(AppStatus currentState)
        {
            AppCurrentStatus = currentState;
            NotifyObsevers();
        }

        public IDisposable Subscribe(IObserver<AppStatusObservable> observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);

                NotifyObsevers();
            }
            return new UnSubscribe(_observers, observer);
        }

        private void NotifyObsevers()
        {
            foreach (var observer in _observers)
            {
                observer.OnNext(this);
            }
        }
    }

    internal class UnSubscribe : IDisposable
    {
        private List<IObserver<AppStatusObservable>> _observers;
        private IObserver<AppStatusObservable> _observer;

        public UnSubscribe(List<IObserver<AppStatusObservable>> observers, IObserver<AppStatusObservable> observer)
        {
            this._observers = observers;
            this._observer = observer;
        }

        public void Dispose()
        {
            if (_observers.Contains(_observer))
            {
                _observers.Remove(_observer);

                if(_observer is IDisposable)
                {
                    (_observer as IDisposable).Dispose();
                }
            }
        }
    }
}
