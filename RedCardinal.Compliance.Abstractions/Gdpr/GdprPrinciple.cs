namespace RedCardinal.Compliance.Abstractions.Gdpr;

/// <summary>
/// GDPR data protection principles from Article 5.
/// </summary>
public enum GdprPrinciple
{
    /// <summary>
    /// Lawfulness, fairness, and transparency.
    /// Data must be processed lawfully, fairly, and in a transparent manner.
    /// </summary>
    LawfulnessFairnessTransparency,

    /// <summary>
    /// Purpose limitation.
    /// Data collected for specified, explicit, and legitimate purposes.
    /// </summary>
    PurposeLimitation,

    /// <summary>
    /// Data minimization.
    /// Data must be adequate, relevant, and limited to what is necessary.
    /// </summary>
    DataMinimisation,

    /// <summary>
    /// Accuracy.
    /// Data must be accurate and kept up to date.
    /// </summary>
    Accuracy,

    /// <summary>
    /// Storage limitation.
    /// Data kept no longer than necessary for purposes.
    /// </summary>
    StorageLimitation,

    /// <summary>
    /// Integrity and confidentiality (security of processing).
    /// Appropriate security measures to protect data.
    /// </summary>
    SecurityOfProcessing,

    /// <summary>
    /// Accountability.
    /// Controller responsible for and able to demonstrate compliance.
    /// </summary>
    Accountability
}