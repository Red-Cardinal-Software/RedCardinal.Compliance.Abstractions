namespace RedCardinal.Compliance.Abstractions.Evidence;

/// <summary>
/// Types of compliance justifications.
/// </summary>
public enum JustificationType
{
    /// <summary>
    /// Standard implementation that meets requirements.
    /// </summary>
    Implementation,

    /// <summary>
    /// Implementation that exceeds minimum requirements.
    /// </summary>
    ExceedsRequirement,

    /// <summary>
    /// Alternative implementation that achieves equivalent security.
    /// </summary>
    AlternativeControl,

    /// <summary>
    /// Compensating control when primary control cannot be implemented.
    /// </summary>
    CompensatingControl,

    /// <summary>
    /// Control is not applicable to this code element.
    /// </summary>
    NotApplicable,

    /// <summary>
    /// Accepted risk with documented approval.
    /// </summary>
    AcceptedRisk,

    /// <summary>
    /// Temporary exception with planned remediation.
    /// </summary>
    TemporaryException,

    /// <summary>
    /// Inherited control from another system or component.
    /// </summary>
    InheritedControl
}