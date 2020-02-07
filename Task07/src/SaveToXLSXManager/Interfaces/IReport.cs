using System.Collections.Generic;

namespace SaveToXLSXManager.Interfaces
{
    /// <summary>
    /// IReport interface.
    /// </summary>
    public interface IReport
    {
        /// <summary>
        /// Table header.
        /// </summary>
        /// <returns>Returns header.</returns>
        IEnumerable<string> GetDataHeader();

        /// <summary>
        /// Table data.
        /// </summary>
        /// <returns>Returns table data.</returns>
        IEnumerable<IEnumerable<string>> GetData();
    }
}
