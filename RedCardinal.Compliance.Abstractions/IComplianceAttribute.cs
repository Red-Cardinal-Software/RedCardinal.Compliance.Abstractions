namespace RedCardinal.Compliance.Abstractions;

/// <summary>
/// Base interface for all compliance-related attributes.
/// Provides common properties for identifying and describing compliance controls.
/// </summary>
public interface IComplianceAttribute
{
    /// <summary>
    /// Gets the compliance framework this attribute belongs to.
    /// </summary>
    ComplianceFramework Framework { get; }

    /// <summary>
    /// Gets the control or requirement identifier within the framework.
    /// </summary>
    string ControlId { get; }

    /// <summary>
    /// Gets a description of how this code element satisfies the control.
    /// </summary>
    string? Description { get; }
}