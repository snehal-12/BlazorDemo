namespace BlazorDemoApp.StateStore
{
    public class DecaturOnlineServerStore : Observer
    {
        private int _numServersOnline;
        public int GetNumberServersOnline()
        {
            return _numServersOnline;
        }
        public void SetNumberServersOnline(int number)
        {
            _numServersOnline = number;
            base.BroadcastStateChange();
        }
    }
}
