namespace RedCardinal.Compliance.Abstractions;

/// <summary>
/// Base class for compliance control attributes.
/// </summary>
[AttributeUsage(
    AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface |
    AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field |
    AttributeTargets.Event | AttributeTargets.Constructor | AttributeTargets.Assembly,
    AllowMultiple = true,
    Inherited = true)]
public abstract class ComplianceAttributeBase : Attribute, IComplianceAttribute
{
    /// <inheritdoc />
    public abstract ComplianceFramework Framework { get; }

    /// <inheritdoc />
    public string ControlId { get; }

    /// <inheritdoc />
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets the implementation status of this control.
    /// </summary>
    public ImplementationStatus Status { get; set; } = ImplementationStatus.Implemented;

    /// <summary>
    /// Gets or sets the person or team responsible for this control implementation.
    /// </summary>
    public string? Owner { get; set; }

    /// <summary>
    /// Gets or sets the date when this implementation was last reviewed.
    /// Format: ISO 8601 (YYYY-MM-DD).
    /// </summary>
    public string? LastReviewedDate { get; set; }

    /// <summary>
    /// Initializes a new instance of the compliance attribute.
    /// </summary>
    /// <param name="controlId">The control identifier within the framework.</param>
    protected ComplianceAttributeBase(string controlId)
    {
        ControlId = controlId ?? throw new ArgumentNullException(nameof(controlId));
    }
}