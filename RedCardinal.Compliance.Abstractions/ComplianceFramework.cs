namespace RedCardinal.Compliance.Abstractions;

/// <summary>
/// Identifies the compliance framework a control belongs to.
/// </summary>
public enum ComplianceFramework
{
    /// <summary>
    /// Service Organization Control 2 - Trust Service Criteria.
    /// </summary>
    Soc2,

    /// <summary>
    /// ISO/IEC 27001 - Information Security Management System.
    /// </summary>
    Iso27001,

    /// <summary>
    /// General Data Protection Regulation (EU).
    /// </summary>
    Gdpr,

    /// <summary>
    /// Payment Card Industry Data Security Standard.
    /// </summary>
    PciDss,

    /// <summary>
    /// Health Insurance Portability and Accountability Act.
    /// </summary>
    Hipaa,

    /// <summary>
    /// California Consumer Privacy Act.
    /// </summary>
    Ccpa,

    /// <summary>
    /// Cybersecurity Maturity Model Certification (DoD).
    /// </summary>
    Cmmc,

    /// <summary>
    /// Sarbanes-Oxley Act - IT controls for financial reporting.
    /// </summary>
    Sox,

    /// <summary>
    /// NIST Cybersecurity Framework.
    /// </summary>
    NistCsf
}