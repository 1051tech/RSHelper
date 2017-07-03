namespace RSHelperLib
{
    /// <summary>
    /// Encapsulates the functionality for brining the RuneScape client into focus.
    /// </summary>
    public static class RSHelper
    {
        private static RSObj _rsClient;
        private static RSObj RSClient
        {
            get
            {
                if (_rsClient == null)
                    _rsClient = new RSObj();

                return _rsClient;
            }
        }

        /// <summary>Focuses the RuneScape client.</summary>
        public static void OpenClient()
        {
            RSClient.Open();
        }
    }
}
