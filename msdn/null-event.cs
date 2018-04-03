using System;

class T
{
    class Inner
    {
        event EventHandler _stateChanged;

        public void OnStateChanged(EventArgs e)
        {
            // POI: [[NullReferenceException]] No Event handler had been set to _stateChanged event
            _stateChanged(this, e);
        }
    }

    public static void Main()
    {
        new Inner().OnStateChanged(new EventArgs());
    }
}