using System.Collections.Generic;

namespace CleanArc.Common.JsonResponseModels
{
    /// <summary>
    /// The class representing the Data Table JSON response object.
    /// For more information, see <see href="https://datatables.net/manual/server-side"/>
    /// </summary>
    /// <typeparam name="TRecord">The record type.</typeparam>
    public class DataTableJsonResponse<TRecord>
    {
        /// <summary>
        /// Gets or sets the draw counter.
        /// The draw counter that this object is a response to - from the draw 
        /// parameter sent as part of the data request. Note that it is 
        /// <b>strongly recommended for security reasons</b> that you cast this 
        /// parameter to an integer, rather than simply echoing back to the client 
        /// what it sent in the draw parameter, in order to prevent Cross Site 
        /// Scripting (XSS) attacks.
        /// </summary>
        public int Draw { get; set; }

        /// <summary>
        /// Gets or sets rthe total records, before filtering 
        /// (i.e. the total number of records in the database).
        /// </summary>
        public int RecordsTotal { get; set; }

        /// <summary>
        /// Gets or sets the total records, after filtering 
        /// (i.e. the total number of records after filtering has 
        /// been applied - not just the number of records being 
        /// returned for this page of data).
        /// </summary>
        public int RecordsFiltered { get; set; }

        /// <summary>
        /// Gets or sets the data to be displayed in the table. 
        /// This is an array of data source objects, one for 
        /// each row, which will be used by DataTables. 
        /// Note that this parameter's name can be changed 
        /// using the <c>ajax</c> option's <c>dataSrc</c> property.
        /// </summary>
        public IEnumerable<TRecord> Data { get; set; }

        /// <summary>
        /// Gets or sets the error.
        /// Optional: If an error occurs during the running of the 
        /// server-side processing script, you can inform the 
        /// user of this error by passing back the error message to be 
        /// displayed using this parameter. Do not include if there is no error.
        /// </summary>
        public string Error { get; set; }
    }
}
