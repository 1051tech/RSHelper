using System.Threading.Tasks;

namespace RSHelperLib
{
    /// <summary>
    /// Encapsulates required properties and run method for all scripts.
    /// </summary>
    public interface IScript
    {
        /// <summary>Executed for all scripts.</summary>
        /// <returns>Returns what will be ScriptTask.</returns>
        Task Run();
    }
}
