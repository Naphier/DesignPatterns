namespace Assets.Scripts
{
    /// <summary>
    ///     This is your service locator. It should be the ONLY static class in your whole project.
    ///     Anything else you deem static should be interfaced and added to this.
    ///     That way in the event that service changes to another, breaks or needs updating every
    ///     single reference throughout your game does not have to change.
    ///     There is a more powerful and complicated version of this with a syntax similar to unitys component system
    ///     via Services.Get
    ///     <ISomeServiceContract>
    ///         () making it infinitely and runtime extensible but this is the simplest
    ///         and most invisible version.
    /// </summary>
    public static class Services
    {
        /// <summary>
        ///     If nobody assigned a custom Logger, default to the unity console.
        /// </summary>
        static Services()
        {
            Logger = new LoggerConsole();
        }

        public static ILogger Logger { get; set; }
    }
}