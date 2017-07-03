using System.Threading;
using System.Threading.Tasks;

namespace RSHelperLib
{
    /// <summary>
    /// Encapsulates required properties and run method for all scripts.
    /// </summary>
    public abstract class RSScript
    {
        public Thread ScriptThread; // thread of the script task for killing
        public Task ScriptTask; // script task itself for assignment and awaiting

        /// <summary>Executed for all scripts.</summary>
        /// <returns>Returns what will be ScriptTask.</returns>
        public abstract Task Run();
    }
}
