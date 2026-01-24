namespace RedCardinal.Compliance.Abstractions.Evidence;

/// <summary>
/// Provides justification for why a control is implemented in a specific way,
/// or why a control is not applicable.
/// </summary>
/// <example>
/// <code>
/// [ComplianceJustification(
///     "PCI-DSS 3.5.1",
///     "Using AES-256-GCM as it exceeds the minimum AES-128 requirement",
///     JustificationType.ExceedsRequirement)]
/// public void EncryptCardData() { }
///
/// [ComplianceJustification(
///     "HIPAA",
///     "This service does not process PHI - it only handles anonymized statistics",
///     JustificationType.NotApplicable)]
/// public class AnonymousAnalyticsService { }
/// </code>
/// </example>
[AttributeUsage(
    AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface |
    AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field |
    AttributeTargets.Event | AttributeTargets.Constructor | AttributeTargets.Assembly,
    AllowMultiple = true,
    Inherited = true)]
public sealed class ComplianceJustificationAttribute : Attribute
{
    /// <summary>
    /// Gets the control or framework this justification relates to.
    /// </summary>
    public string ControlReference { get; }

    /// <summary>
    /// Gets the justification text explaining the implementation decision.
    /// </summary>
    public string Justification { get; }

    /// <summary>
    /// Gets or sets the type of justification.
    /// </summary>
    public JustificationType Type { get; set; } = JustificationType.Implementation;

    /// <summary>
    /// Gets or sets who approved this justification.
    /// </summary>
    public string? ApprovedBy { get; set; }

    /// <summary>
    /// Gets or sets when this justification was approved.
    /// Format: ISO 8601 (YYYY-MM-DD).
    /// </summary>
    public string? ApprovalDate { get; set; }

    /// <summary>
    /// Gets or sets when this justification should be reviewed.
    /// Format: ISO 8601 (YYYY-MM-DD).
    /// </summary>
    public string? ReviewByDate { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ComplianceJustificationAttribute"/> class.
    /// </summary>
    /// <param name="controlReference">The control or framework reference.</param>
    /// <param name="justification">The justification text.</param>
    public ComplianceJustificationAttribute(string controlReference, string justification)
    {
        ControlReference = controlReference ?? throw new ArgumentNullException(nameof(controlReference));
        Justification = justification ?? throw new ArgumentNullException(nameof(justification));
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ComplianceJustificationAttribute"/> class.
    /// </summary>
    /// <param name="controlReference">The control or framework reference.</param>
    /// <param name="justification">The justification text.</param>
    /// <param name="type">The type of justification.</param>
    public ComplianceJustificationAttribute(string controlReference, string justification, JustificationType type)
        : this(controlReference, justification)
    {
        Type = type;
    }
}