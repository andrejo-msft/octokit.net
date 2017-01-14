using System;
using System.Diagnostics;
using System.Globalization;
using Octokit.Internal;

namespace Octokit
{
    /// <summary>
    /// Used to filter a request to list changed Issue comments.
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class IssueCommentRequest : RequestParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IssueCommentRequest"/> class.
        /// </summary>
        public IssueCommentRequest()
        {
            SortProperty = IssueCommentSort.Created;
            SortDirection = SortDirection.Ascending;
        }

        /// <summary>
        /// Gets or sets the <see cref="IssueCommentSort"/> property to sort the returned issues by.
        /// Combine this with <see cref="SortDirection"/> to specify sort direction.
        /// </summary>
        /// <value>
        /// The sort property.
        /// </value>
        [Parameter(Key = "sort")]
        public IssueCommentSort SortProperty { get; set; }

        /// <summary>
        /// Gets or sets the sort direction.
        /// </summary>
        /// <value>
        /// The sort direction.
        /// </value>
        [Parameter(Key = "direction")]
        public SortDirection SortDirection { get; set; }

        /// <summary>
        /// Gets or sets the date for which only comments updated at or after this time are returned.
        /// </summary>
        /// <remarks>
        /// This is sent as a timestamp in ISO 8601 format: YYYY-MM-DDTHH:MM:SSZ.
        /// </remarks>
        /// <value>
        /// The since.
        /// </value>
        public DateTimeOffset? Since { get; set; }

        internal string DebuggerDisplay
        {
            get { return string.Format(CultureInfo.InvariantCulture, "Sort: {0}, Direction: {1}, Since: {2}", SortProperty, SortDirection, Since); }
        }
    }

    /// <summary>
    /// The available properties to sort issue comments by.
    /// </summary>
    public enum IssueCommentSort
    {
        /// <summary>
        /// Sort by create date (default)
        /// </summary>
        Created,

        /// <summary>
        /// Sort by the date of the last update
        /// </summary>
        Updated,
    }
}
