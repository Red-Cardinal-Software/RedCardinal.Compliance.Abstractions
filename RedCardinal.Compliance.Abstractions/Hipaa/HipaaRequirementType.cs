namespace RedCardinal.Compliance.Abstractions.Hipaa;

/// <summary>
/// HIPAA implementation specification types.
/// </summary>
public enum HipaaRequirementType
{
    /// <summary>
    /// Required implementation specification - must be implemented.
    /// </summary>
    Required,

    /// <summary>
    /// Addressable implementation specification - must assess and implement if reasonable.
    /// </summary>
    Addressable
}