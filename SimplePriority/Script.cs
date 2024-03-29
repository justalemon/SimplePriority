﻿using System.Diagnostics;
using BeatSaberMarkupLanguage.Settings;
using IPA;
using IPA.Config;
using IPA.Config.Stores;
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
        public SimplePriority(Logger logger, Config config)
        {
            Log = logger;
            Configuration.Instance = config.Generated<Configuration>();
        }
        
        #endregion
        
        #region Tools

        internal static void SetPriority(ProcessPriorityClass priority)
        {
            Log.Info($"Setting Priority to {priority}...");
            Process process = Process.GetCurrentProcess();
            process.PriorityClass = priority;
            Log.Info($"Process Priority set to {priority}!");
        }
        
        #endregion
        
        #region Functions

        /// <summary>
        /// Function triggered when the mod is started.
        /// </summary>
        [OnStart]
        public void OnStart()
        {
            BSMLSettings.instance.AddSettingsMenu(nameof(SimplePriority), "SimplePriority.settings.bsml", new SettingsChanged());
            SetPriority(Configuration.Instance.Priority);
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
