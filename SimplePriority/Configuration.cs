using System.Diagnostics;

namespace SimplePriority
{
    /// <summary>
    /// The configuration of the mod.
    /// </summary>
    public class Configuration
    {
        #region Properties

        /// <summary>
        /// The mod configuration.
        /// </summary>
        public static Configuration Instance { get; internal set; }
        
        /// <summary>
        /// The Game's desired priority.
        /// </summary>
        public virtual ProcessPriorityClass Priority { get; set; } = ProcessPriorityClass.Normal;
        
        #endregion
        
        #region Functions

        protected virtual void Changed()
        {
            SimplePriority.Log.Info("Configuration changed, reapplying Process Priority...");
            SimplePriority.SetPriority(Instance.Priority);
        }
        
        #endregion
    }
}
