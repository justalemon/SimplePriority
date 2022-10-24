using IPA;
using IPA.Logging;

namespace SimplePriority
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    public class SimplePriority
    {
        #region Properties
        
        /// <summary>
        /// The main logger.
        /// </summary>
        public static Logger Log { get; private set; }
        
        #endregion
        
        #region Constructors

        /// <summary>
        /// Creates a new instance of the logger mod.
        /// </summary>
        /// <param name="logger">The logger mod.</param>
        [Init]
        public SimplePriority(Logger logger)
        {
            Log = logger;
        }
        
        #endregion
        
        #region Functions

        /// <summary>
        /// Function triggered when the mod is started.
        /// </summary>
        [OnStart]
        public void OnStart()
        {
        }
        /// <summary>
        /// Function triggered when the game is exiting.
        /// </summary>
        [OnExit]
        public void OnExit()
        {
        }
        
        #endregion
    }
}
