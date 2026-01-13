namespace RedCardinal.Compliance.Abstractions.DataClassification;

/// <summary>
/// Data sensitivity classification levels.
/// </summary>
public enum DataSensitivity
{
    /// <summary>
    /// Public data with no restrictions.
    /// </summary>
    Public,

    /// <summary>
    /// Internal data not meant for public disclosure.
    /// </summary>
    Internal,

    /// <summary>
    /// Confidential business data requiring protection.
    /// </summary>
    Confidential,

    /// <summary>
    /// Personally Identifiable Information (PII).
    /// Data that can identify an individual (name, email, SSN, etc.).
    /// </summary>
    Pii,

    /// <summary>
    /// Sensitive Personally Identifiable Information.
    /// Higher-risk PII such as SSN, passport numbers, biometrics.
    /// </summary>
    SensitivePii,

    /// <summary>
    /// Protected Health Information (PHI) under HIPAA.
    /// Health-related data linked to an individual.
    /// </summary>
    Phi,

    /// <summary>
    /// Payment Card Industry data (credit card numbers, CVV, etc.).
    /// Subject to PCI DSS requirements.
    /// </summary>
    Pci,

    /// <summary>
    /// Financial data requiring special protection.
    /// Account numbers, financial records, etc.
    /// </summary>
    Financial,

    /// <summary>
    /// Authentication credentials (passwords, tokens, keys).
    /// </summary>
    Credentials,

    /// <summary>
    /// Highly restricted data requiring maximum protection.
    /// </summary>
    Restricted
}