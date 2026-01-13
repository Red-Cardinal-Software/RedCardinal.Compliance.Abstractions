namespace RedCardinal.Compliance.Abstractions.Hipaa;

/// <summary>
/// HIPAA Security Rule safeguard categories.
/// </summary>
public enum HipaaSafeguard
{
    /// <summary>
    /// Administrative Safeguards (§164.308).
    /// Policies and procedures for managing security measures.
    /// </summary>
    Administrative,

    /// <summary>
    /// Physical Safeguards (§164.310).
    /// Physical measures to protect electronic information systems.
    /// </summary>
    Physical,

    /// <summary>
    /// Technical Safeguards (§164.312).
    /// Technology and policies for controlling access to ePHI.
    /// </summary>
    Technical,

    /// <summary>
    /// Organizational Requirements (§164.314).
    /// Business associate contracts and requirements.
    /// </summary>
    Organizational,

    /// <summary>
    /// Policies and Procedures (§164.316).
    /// Documentation requirements.
    /// </summary>
    PoliciesAndProcedures
}