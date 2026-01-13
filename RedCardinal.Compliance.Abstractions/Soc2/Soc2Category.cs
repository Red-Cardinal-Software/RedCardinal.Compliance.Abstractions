namespace RedCardinal.Compliance.Abstractions.Soc2;

/// <summary>
/// SOC 2 Trust Service Categories.
/// </summary>
public enum Soc2Category
{
    /// <summary>
    /// Common Criteria - Security controls that apply across all categories.
    /// Controls: CC1.x through CC9.x
    /// </summary>
    Security,

    /// <summary>
    /// Availability - System availability and recovery controls.
    /// Controls: A1.x
    /// </summary>
    Availability,

    /// <summary>
    /// Processing Integrity - Accuracy and completeness of processing.
    /// Controls: PI1.x
    /// </summary>
    ProcessingIntegrity,

    /// <summary>
    /// Confidentiality - Protection of confidential information.
    /// Controls: C1.x
    /// </summary>
    Confidentiality,

    /// <summary>
    /// Privacy - Personal information collection, use, and disclosure.
    /// Controls: P1.x through P8.x
    /// </summary>
    Privacy
}