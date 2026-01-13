namespace RedCardinal.Compliance.Abstractions.Ccpa;

/// <summary>
/// CCPA/CPRA consumer rights.
/// </summary>
public enum CcpaRight
{
    /// <summary>
    /// Right to know what personal information is being collected (§1798.110).
    /// </summary>
    RightToKnow,

    /// <summary>
    /// Right to delete personal information (§1798.105).
    /// </summary>
    RightToDelete,

    /// <summary>
    /// Right to opt-out of sale/sharing of personal information (§1798.120).
    /// </summary>
    RightToOptOut,

    /// <summary>
    /// Right to non-discrimination for exercising rights (§1798.125).
    /// </summary>
    RightToNonDiscrimination,

    /// <summary>
    /// Right to correct inaccurate personal information (CPRA - §1798.106).
    /// </summary>
    RightToCorrect,

    /// <summary>
    /// Right to limit use of sensitive personal information (CPRA - §1798.121).
    /// </summary>
    RightToLimitUse,

    /// <summary>
    /// Right to access personal information (§1798.110).
    /// </summary>
    RightToAccess,

    /// <summary>
    /// Right to data portability (§1798.130).
    /// </summary>
    RightToPortability
}