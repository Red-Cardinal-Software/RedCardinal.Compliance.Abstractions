namespace RedCardinal.Compliance.Abstractions.Evidence;

/// <summary>
/// Adds an audit note or comment for compliance reviewers.
/// Use this to highlight important implementation details for auditors.
/// </summary>
/// <example>
/// <code>
/// [AuditNote("Session timeout is set to 15 minutes per security policy SP-001")]
/// public class SessionManager { }
///
/// [AuditNote("Rate limiting configured at infrastructure level via API Gateway", Priority = AuditPriority.Informational)]
/// public class ApiController { }
/// </code>
/// </example>
[AttributeUsage(
    AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface |
    AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field |
    AttributeTargets.Event | AttributeTargets.Constructor | AttributeTargets.Assembly,
    AllowMultiple = true,
    Inherited = true)]
public sealed class AuditNoteAttribute : Attribute
{
    /// <summary>
    /// Gets the audit note text.
    /// </summary>
    public string Note { get; }

    /// <summary>
    /// Gets or sets the priority/importance of this note.
    /// </summary>
    public AuditPriority Priority { get; set; } = AuditPriority.Standard;

    /// <summary>
    /// Gets or sets the author of this note.
    /// </summary>
    public string? Author { get; set; }

    /// <summary>
    /// Gets or sets when this note was added.
    /// Format: ISO 8601 (YYYY-MM-DD).
    /// </summary>
    public string? DateAdded { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="AuditNoteAttribute"/> class.
    /// </summary>
    /// <param name="note">The audit note text.</param>
    public AuditNoteAttribute(string note)
    {
        Note = note ?? throw new ArgumentNullException(nameof(note));
    }
}