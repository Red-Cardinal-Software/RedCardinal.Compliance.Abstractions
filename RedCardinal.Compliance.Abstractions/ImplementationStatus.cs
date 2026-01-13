namespace RedCardinal.Compliance.Abstractions;

/// <summary>
/// Represents the implementation status of a compliance control.
/// </summary>
public enum ImplementationStatus
{
    /// <summary>
    /// The control is not yet implemented.
    /// </summary>
    NotImplemented,

    /// <summary>
    /// The control implementation is in progress.
    /// </summary>
    InProgress,

    /// <summary>
    /// The control is partially implemented.
    /// </summary>
    PartiallyImplemented,

    /// <summary>
    /// The control is fully implemented.
    /// </summary>
    Implemented,

    /// <summary>
    /// The control is not applicable to this code element.
    /// </summary>
    NotApplicable
}