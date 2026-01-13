namespace RedCardinal.Compliance.Abstractions.Evidence;

/// <summary>
/// Priority levels for audit notes.
/// </summary>
public enum AuditPriority
{
    /// <summary>
    /// Informational note for context.
    /// </summary>
    Informational,

    /// <summary>
    /// Standard audit note.
    /// </summary>
    Standard,

    /// <summary>
    /// Important information that should be reviewed.
    /// </summary>
    Important,

    /// <summary>
    /// Critical information requiring attention.
    /// </summary>
    Critical
}